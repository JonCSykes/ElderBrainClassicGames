using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace MineSweeper
{
    public class Game
    {
        public MineField? MineField { get; set; }
        public int HintCount { get; set; }
        public int HintCounter { get; set; }
        public bool IsGameStarted { get; set; }
        public bool IsGameOver { get; set; }
        public int EndTimeCounter { get; set; }
        public Player Player { get; set; }
        public Metrics Metrics { get; set; }

        public Game(int width, int height, int mineCount, int hintCount) 
        {
            MineField = new MineField(width, height, mineCount);
            HintCount = hintCount;
            HintCounter = 0;
            IsGameStarted = false;
        }

        public bool ValidateWin()
        {
            if (MineField != null)
            {
                if (MineField.MineCellsRevealedCounter == MineField.Height * MineField.Width - MineField.MineCount)
                {
                    IsGameOver = true;
                    return true;
                }
            }

            return false;
        }


    }
}
