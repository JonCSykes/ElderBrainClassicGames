using Newtonsoft.Json;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;

namespace MineSweeperPro
{
    [Serializable]
    public class GameEntryCollection
    {
        private readonly string SCORES_FILE = "App.dat";
        private string? HOME_FOLDER;
        private static readonly byte[] Key = Encoding.UTF8.GetBytes("!9MineCellsLife!");
        private static readonly byte[] IV = Encoding.UTF8.GetBytes("FlaggingIsAVerb!");
        private List<GameEntry> gameEntries;

        public GameEntryCollection()
        {
            gameEntries = new List<GameEntry>();

            LoadData();
        }

        public void AddGameEntry(Game game, TimeSpan timestamp)
        {
            if (game != null && game.GameType != null)
            {
                string searchKey = string.Concat(game.GameType.Width, game.MineField.Height, game.MineField.MineCount, game.HintCount);

                GameEntry entry = new GameEntry(searchKey, game.Player.Username, timestamp, game, 0, game.IsWin);

                gameEntries.Add(entry);

                SortGameEntries(searchKey);

                SaveData();
            }
        }

        public List<GameEntry> GetEntries(GameTypeEnum gameTypeEnum)
        {
            GameType gameType = new GameType(GameType.GetGameType((int)gameTypeEnum));
            List<GameEntry> scores = new List<GameEntry>();

            if (gameType != null)
            {
                string searchKey = string.Concat(gameType.Width, gameType.Height, gameType.MineCount, gameType.HintCount);
                scores = gameEntries.FindAll(e => e.Key == searchKey && e.Win == true);
            }

            return scores;
        }
        
        public double GetAverageTime() 
        { 
            double average = 0;
            int winCount = 0;

            foreach (GameEntry entry in gameEntries)
            {
                if (entry.Win)
                {
                    average += entry.Timestamp.TotalMilliseconds;
                    winCount++;
                }
            }

            average = average / winCount;

            return average;
        } 

        public double GetAverageTime(GameTypeEnum gameTypeEnum)
        {
            GameType gameType = new GameType(GameType.GetGameType((int)gameTypeEnum));
            
            double average = 0;
            int winCount = 0;

            if (gameType != null)
            {
                string searchKey = string.Concat(gameType.Width, gameType.Height, gameType.MineCount, gameType.HintCount);

                foreach (GameEntry entry in gameEntries)
                {
                    if (entry.Game == null || entry.Game.GameType == null || !entry.Win || entry.Key != searchKey)
                        continue;

                    average += entry.Timestamp.TotalMilliseconds;
                    winCount++;
                }
            
                average = average / winCount;
            }

            return average;
        }

        public double GetAverageEfficiency()
        {
            double averageEfficiency = 0;

            foreach (GameEntry entry in gameEntries)
            {
                if (!entry.Win)
                    continue;

                int bbbv = entry.Game.BBBV;
                int bbbvTotal = entry.Game.BBBVTotal;
                double efficiency = 0;

                if (bbbv > 0 && bbbvTotal > 0)
                {
                    efficiency = bbbv / (double)(bbbvTotal) * 100;
                }

                averageEfficiency += efficiency;
            }

            averageEfficiency = averageEfficiency / gameEntries.Count;

            return averageEfficiency;
        }

        public double GetAverageEfficiency(GameTypeEnum gameTypeEnum)
        {
            GameType gameType = new GameType(GameType.GetGameType((int)gameTypeEnum));

            double averageEfficiency = 0;

            foreach (GameEntry entry in gameEntries)
            {
                if (entry.Game == null || entry.Game.GameType == null || entry.Game.GameType != gameType || !entry.Win)
                    continue;

                int bbbv = entry.Game.BBBV;
                int bbbvTotal = entry.Game.BBBVTotal;
                double efficiency = 0;

                if (bbbv > 0 && bbbvTotal > 0)
                {
                    efficiency = bbbv / (double)(bbbvTotal) * 100;
                }

                averageEfficiency += efficiency;
            }

            averageEfficiency = averageEfficiency / gameEntries.Count;

            return averageEfficiency;
        }

        public int GetTotalWins()
        {
            int totalWins = 0;

            foreach (GameEntry entry in gameEntries)
            {
                if (!entry.Win)
                    continue;

                totalWins++;
            }

            return totalWins;
        }
        public int GetTotalWins(GameTypeEnum gameTypeEnum)
        {
            GameType gameType = new GameType(GameType.GetGameType((int)gameTypeEnum));
            int totalWins = 0;

            foreach (GameEntry entry in gameEntries)
            {
                if (entry.Game == null || entry.Game.GameType == null || entry.Game.GameType != gameType || !entry.Win)
                    continue;

                totalWins++;
            }

            return totalWins;
        }

        public int GetTotalLosses()
        {
            int totalLosses = 0;

            foreach (GameEntry entry in gameEntries)
            {
                if (entry.Win)
                    continue;

                totalLosses++;
            }

            return totalLosses;
        }
        public int GetTotalLosses(GameTypeEnum gameTypeEnum)
        {
            GameType gameType = new GameType(GameType.GetGameType((int)gameTypeEnum));
            int totalLosses = 0;

            foreach (GameEntry entry in gameEntries)
            {
                if (entry.Game == null || entry.Game.GameType == null || entry.Game.GameType != gameType || entry.Win)
                    continue;

                totalLosses++;
            }

            return totalLosses;
        }


        public List<GameEntry> GetEntries()
        {
            return gameEntries;
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
}
