using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace MineSweeperPro       
{
    public class Game
    {
        public MineField? MineField { get; set; }
        public int HintCount { get; set; }
        public int HintCounter { get; set; }
        public bool IsGameStarted { get; set; }
        public bool IsGameOver { get; set; }
        public int EndTimeCounter { get; set; }
        public int BBBV
        {
            get
            {
                return Get3BV();
            }
        }
        public Player Player { get; set; }
        public List<Telemetry> Telemetry { get; set; } 

        public Game(int width, int height, int mineCount, int hintCount) 
        {
            Telemetry = new List<Telemetry>();
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

        public void AddTelemetry(Telemetry telemetry)
        {
            Telemetry.Add(telemetry);
        }

        public int Get3BV()
        {
            int BBBV = 0;
            HashSet<MineCell> visitedCells = new HashSet<MineCell>();

            if (MineField != null)
            {
                for (int x = 0; x < MineField.Width; x++)
                {
                    for (int y = 0; y < MineField.Height; y++)
                    {
                        if (MineField.MineCellCollection != null)
                        {
                            MineCell cell = MineField.MineCellCollection[x, y];
                            if (cell.Type == MineCellTypeEnum.Land && cell.Status != MineCellStatusEnum.Revealed && !visitedCells.Contains(cell))
                            {
                                BBBV++;

                                if (cell.ClusterSize > 1)
                                {
                                    visitedCells.UnionWith(MineField.GetClusterCells(cell));
                                }
                            }
                        }
                    }
                }
            }

            return BBBV;
        }

        public double Get3BVS()
        {
            int leftClickCount = 0;

            if (Telemetry != null && Telemetry.Count > 0)
            {
                double durationInSeconds = Telemetry[Telemetry.Count - 1].Timestamp.TotalSeconds;

                foreach (Telemetry telemetry in Telemetry)
                {
                    if (telemetry.Action == UserActionEnum.LeftClick && telemetry.Cell != null && telemetry.Cell.Status == MineCellStatusEnum.Revealed)
                    {
                        leftClickCount++;
                    }
                }

                return leftClickCount / durationInSeconds;
            }

            return leftClickCount;
        }
    }
}
