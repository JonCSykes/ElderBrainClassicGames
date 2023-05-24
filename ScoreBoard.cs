using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace MineSweeper
{
    [Serializable]
    public class ScoreBoard
    {
        private List<ScoreEntry> scoreEntries = new List<ScoreEntry>();

        public ScoreBoard() { }

        private void SortScoreBoard()
        {
            scoreEntries.Sort((e1, e2) => e1.Timestamp.CompareTo(e2.Timestamp));

            for (int i = 0; i < scoreEntries.Count; i++)
            {
                scoreEntries[i].Rank = i + 1;
            }
        }

        public List<ScoreEntry> GetScoresByGameType(Game game) 
        {
            List<ScoreEntry> scores = new List<ScoreEntry>();

            if (game != null && game.MineField != null)
            {
                string searchKey = string.Concat(game.MineField.Width, game.MineField.Height, game.MineField.MineCount, game.HintCount);
                scores = scoreEntries.FindAll(e => e.Key == searchKey);
            }

            return scores;
        }

        private void LoadData()
        {
            if (File.Exists(filePath))
            {
                try
                {
                    using (FileStream stream = File.OpenRead("scores.bin"))
                    {
                        BinaryFormatter formatter = new BinaryFormatter();
                        scoreEntries = (Dictionary<string, ScoreEntry>)formatter.Deserialize(stream);
                    }
                }
                catch (FileNotFoundException)
                {
                    // Handle file not found exception
                }
                catch (Exception ex)
                {
                    // Handle other exceptions
                }
            }
        }

        private void SaveData()
        {
            try
            {
                using (FileStream stream = File.OpenWrite("scores.bin"))
                {
                    BinaryFormatter formatter = new BinaryFormatter();
                    formatter.Serialize(stream, scoreEntries);
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions
            }
        }
    }

    [Serializable]
    public class ScoreEntry
    {
        public string Key { get; set; }
        public string Username { get; set; }
        public DateTime Timestamp { get; set; }
        public int Rank { get; set; }

        public override string ToString()
        {
            return $"Rank: {Rank}, Username: {Username}, Timestamp: {Timestamp}";
        }
    }


}
