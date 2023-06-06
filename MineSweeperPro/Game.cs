namespace MineSweeperPro
{
    public class Game
    {
        private int bbbv = 0;

        public MineField? MineField { get; set; }
        public int HintCount { get; set; }
        public int HintCounter { get; set; }
        public bool IsGameStarted { get; set; }
        public bool IsGameOver { get; set; }
        public bool IsWin
        {
            get
            {
                return ValidateWin();
            }
        }

        public int BBBV
        {
            get
            {
                return Get3BV();
            }
        }
        public double BBBVS
        {
            get
            {
                return Get3BVS();
            }
        }
        public int BBBVTotal
        {
            get
            {
                return Get3BVTotal();
            }
        }
        public Player Player { get; set; }
        public List<Telemetry> Telemetry { get; set; }

        public Game(Player player, int width, int height, int mineCount, int hintCount)
        {
            Telemetry = new List<Telemetry>();
            MineField = new MineField(width, height, mineCount);
            Player = player;
            HintCount = hintCount;
            HintCounter = 0;
            IsGameStarted = false;
        }

        private bool ValidateWin()
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

        private int Get3BV()
        {
            if (bbbv == 0)
            {
                HashSet<MineCell> visitedCells = new HashSet<MineCell>();

                if (MineField != null && MineField.SortedClusterCollection != null)
                {
                    foreach (var mineCell in MineField.SortedClusterCollection)
                    {
                        if (mineCell.Type == MineCellTypeEnum.Land && mineCell.Status != MineCellStatusEnum.Revealed && !visitedCells.Contains(mineCell))
                        {
                            if (mineCell.ClusterSize > 1)
                            {
                                bbbv++;
                                visitedCells.UnionWith(MineField.GetClusterCells(mineCell));
                            }
                        }
                    }

                    for (int x = 0; x < MineField.Width; x++)
                    {
                        for (int y = 0; y < MineField.Height; y++)
                        {
                            if (MineField.MineCellCollection != null)
                            {
                                MineCell cell = MineField.MineCellCollection[x, y];
                                if (cell.Type == MineCellTypeEnum.Land && cell.Status != MineCellStatusEnum.Revealed && !visitedCells.Contains(cell))
                                {
                                    bbbv++;
                                }
                            }
                        }
                    }

                }
            }

            return bbbv;
        }

        private double Get3BVS()
        {
            int leftClickCount = 0;

            if (Telemetry != null && Telemetry.Count > 0)
            {
                double durationInSeconds = Telemetry[Telemetry.Count - 1].Timestamp.TotalSeconds;

                foreach (Telemetry telemetry in Telemetry)
                {
                    if ((telemetry.Event == EventEnum.CellReveal || telemetry.Event == EventEnum.ChordReveal) && telemetry.Cell != null && telemetry.Cell.Status == MineCellStatusEnum.Revealed)
                    {
                        leftClickCount++;
                    }
                }

                return leftClickCount / durationInSeconds;
            }

            return leftClickCount;
        }

        private int Get3BVTotal()
        {
            int leftClickCount = 0;

            if (Telemetry != null && Telemetry.Count > 0)
            {
                foreach (Telemetry telemetry in Telemetry)
                {
                    if ((telemetry.Event == EventEnum.CellReveal || telemetry.Event == EventEnum.ChordReveal) && telemetry.Cell != null && telemetry.Cell.Status == MineCellStatusEnum.Revealed)
                    {
                        leftClickCount++;
                    }
                }
            }

            return leftClickCount;
        }
    }
}
