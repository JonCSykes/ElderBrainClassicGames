using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace MineSweeperPro
{
    [Serializable]
    public class LeaderBoard
    {
        private readonly string SCORES_FILE = "App.dat";
        private string? HOME_FOLDER;
        private static readonly byte[] Key = Encoding.UTF8.GetBytes("!9MineCellsLife!");
        private static readonly byte[] IV = Encoding.UTF8.GetBytes("FlaggingIsAVerb!");

        private List<GameEntry> gameEntries = new List<GameEntry>();
        private Game Game;

        public LeaderBoard(Game game) 
        {
            gameEntries = new List<GameEntry>();

            Game = game;

            LoadData();
        }

        public void AddGameEntry(TimeSpan timestamp)
        {
            if (Game != null && Game.MineField != null) 
            {
                string searchKey = string.Concat(Game.MineField.Width, Game.MineField.Height, Game.MineField.MineCount, Game.HintCount);

                GameEntry entry = new GameEntry(searchKey, Game.Player.Username, timestamp, Game, 0, Game.IsWin);

                gameEntries.Add(entry);

                SortGameEntries(searchKey);

                SaveData();
            }
        }

        public List<GameEntry> GetLeaderBoard() 
        {
            List<GameEntry> scores = new List<GameEntry>();

            if (Game != null && Game.MineField != null)
            {
                string searchKey = string.Concat(Game.MineField.Width, Game.MineField.Height, Game.MineField.MineCount, Game.HintCount);
                scores = gameEntries.FindAll(e => e.Key == searchKey && e.Win == true);
            }

            return scores;
        }

        private void SortGameEntries(string searchKey)
        {
            gameEntries.Sort((e1, e2) => 
             {
                 int result = e2.Win.CompareTo(e1.Win);  
                 if (result == 0)  
                     result = e1.Timestamp.CompareTo(e2.Timestamp);
                 return result;
             });

            int i = 0;

            foreach (var gameEntry in gameEntries)
            {
                if (gameEntry.Key == searchKey)
                {
                    gameEntry.Rank = i + 1;
                    i++;
                }
            }
        }

        public void LoadData()
        {
            string assemblyPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

            if (!string.IsNullOrEmpty(assemblyPath))
            {
                HOME_FOLDER = Path.Combine(assemblyPath, "Data");
            }

            if (!string.IsNullOrEmpty(HOME_FOLDER))
            {
                string scoresFilePath = Path.Combine(HOME_FOLDER, SCORES_FILE);
                if (!Directory.Exists(HOME_FOLDER))
                {
                    Directory.CreateDirectory(HOME_FOLDER);
                }
                else
                {
                    if (File.Exists(scoresFilePath))
                    {
                        try
                        {
                            string encryptedData = File.ReadAllText(scoresFilePath);
                            string jsonData = Decrypt(encryptedData);

                            if (!string.IsNullOrEmpty(jsonData))
                            {
                                gameEntries = JsonConvert.DeserializeObject<List<GameEntry>>(jsonData);
                            }
                        }
                        catch (Exception)
                        {
                            // Handle exceptions
                        }
                    }
                }
            }
        }

        private void SaveData()
        {
            string assemblyPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

            if (!string.IsNullOrEmpty(assemblyPath))
            {
                HOME_FOLDER = Path.Combine(assemblyPath, "Data");
            }

            if (!string.IsNullOrEmpty(HOME_FOLDER))
            {
                string scoresFilePath = Path.Combine(HOME_FOLDER, SCORES_FILE);
                
                if (!Directory.Exists(HOME_FOLDER))
                {
                    Directory.CreateDirectory(HOME_FOLDER);
                }

                try
                {
                    string jsonData = JsonConvert.SerializeObject(gameEntries);
                    string encryptedData = Encrypt(jsonData);
                    File.WriteAllText(scoresFilePath, encryptedData);
                }
                catch (Exception)
                {
                    // Handle exceptions
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
    public class GameEntry
    {
        public string? Key { get; set; }
        public string? Username { get; set; }
        public TimeSpan Timestamp { get; set; }
        public Game Game { get; set; }
        public int Rank { get; set; }
        public bool Win { get; set; }

        public GameEntry(string? key, string? username, TimeSpan timestamp, Game game, int rank, bool win)
        {
            Key = key;
            Username = username;
            Timestamp = timestamp;
            Game = game;
            Rank = rank;
            Win = win;
        }

        public override string ToString()
        {
            return $"Rank: {Rank}, Username: {Username}, Timestamp: {Timestamp}";
        }
    }


}
