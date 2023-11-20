using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MineSweeperPro
{

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
