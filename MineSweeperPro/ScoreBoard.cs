using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace MineSweeperPro
{
    [Serializable]
    public class ScoreBoard
    {
        private readonly string SCORES_FILE = "App.dat";
        private string? HOME_FOLDER;
        private static readonly byte[] Key = Encoding.UTF8.GetBytes("!LiveLife9MineCellsAtATime!");
        private static readonly byte[] IV = Encoding.UTF8.GetBytes("?FlaggingMinesIsNotAEuphemism?");

        private List<ScoreEntry> scoreEntries = new List<ScoreEntry>();
        private Game ScoredGame;

        public ScoreBoard(Game game) 
        {
            
            scoreEntries = new List<ScoreEntry>();
            ScoredGame = game;

            LoadData();
        }

        public void AddScoreEntry(ScoreEntry entry)
        {
            scoreEntries.Add(entry);

            SortScoreBoard();

            SaveData();
        }

        public List<ScoreEntry> GetScores() 
        {
            List<ScoreEntry> scores = new List<ScoreEntry>();

            if (ScoredGame != null && ScoredGame.MineField != null)
            {
                string searchKey = string.Concat(ScoredGame.MineField.Width, ScoredGame.MineField.Height, ScoredGame.MineField.MineCount, ScoredGame.HintCount);
                scores = scoreEntries.FindAll(e => e.Key == searchKey);
            }

            return scores;
        }

        private void SortScoreBoard()
        {
            scoreEntries.Sort((e1, e2) => e1.Timestamp.CompareTo(e2.Timestamp));

            for (int i = 0; i < scoreEntries.Count; i++)
            {
                scoreEntries[i].Rank = i + 1;
            }
        }

        private void LoadData()
        {
            string assemblyPath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);

            if (!string.IsNullOrEmpty(assemblyPath))
            {
                HOME_FOLDER = Path.Combine(assemblyPath, "MineSweeperPro");
            }

            if (!string.IsNullOrEmpty(HOME_FOLDER))
            {
                string scoresFilePath = Path.Combine(HOME_FOLDER, SCORES_FILE);

                if (File.Exists(scoresFilePath))
                {
                    try
                    {
                        string encryptedData = File.ReadAllText(scoresFilePath);
                        string jsonData = Decrypt(encryptedData);

                        if (!string.IsNullOrEmpty(jsonData))
                        {
                            scoreEntries = JsonConvert.DeserializeObject<List<ScoreEntry>>(jsonData);
                        }
                    }
                    catch (Exception)
                    {
                        // Handle exceptions
                    }
                }
            }
        }

        private void SaveData()
        {
            string assemblyPath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);

            if (!string.IsNullOrEmpty(assemblyPath))
            {
                HOME_FOLDER = Path.Combine(assemblyPath, "MineSweeperPro");
            }

            if (!string.IsNullOrEmpty(HOME_FOLDER))
            {
                string scoresFilePath = Path.Combine(HOME_FOLDER, SCORES_FILE);

                if (File.Exists(scoresFilePath))
                {
                    try
                    {
                        string jsonData = JsonConvert.SerializeObject(scoreEntries);
                        string encryptedData = Encrypt(jsonData);
                        File.WriteAllText(scoresFilePath, encryptedData);
                    }
                    catch (Exception)
                    {
                        // Handle exceptions
                    }
                }
            }
        }

        public static string Encrypt(string plainText)
        {
            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = Key;
                aesAlg.IV = IV;

                ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

                using (MemoryStream memoryStream = new MemoryStream())
                {
                    using (CryptoStream cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter streamWriter = new StreamWriter(cryptoStream))
                        {
                            streamWriter.Write(plainText);
                        }
                        byte[] encryptedBytes = memoryStream.ToArray();
                        string encryptedText = Convert.ToBase64String(encryptedBytes);
                        return encryptedText;
                    }
                }
            }
        }

        public static string Decrypt(string encryptedText)
        {
            byte[] encryptedBytes = Convert.FromBase64String(encryptedText);

            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = Key;
                aesAlg.IV = IV;

                ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

                using (MemoryStream memoryStream = new MemoryStream(encryptedBytes))
                {
                    using (CryptoStream cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader streamReader = new StreamReader(cryptoStream))
                        {
                            string decryptedText = streamReader.ReadToEnd();
                            return decryptedText;
                        }
                    }
                }
            }
        }
    }

    [Serializable]
    public class ScoreEntry
    {
        public string? Key { get; set; }
        public string? Username { get; set; }
        public DateTime Timestamp { get; set; }
        public int Rank { get; set; }

        public override string ToString()
        {
            return $"Rank: {Rank}, Username: {Username}, Timestamp: {Timestamp}";
        }
    }


}
