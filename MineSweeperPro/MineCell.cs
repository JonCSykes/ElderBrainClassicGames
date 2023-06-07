namespace MineSweeperPro
{
    // Import libraries

    public class MineCell
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int SurroundingMineCount { get; set; }
        public int ClusterSize { get; set; }
        public MineCellStatusEnum Status { get; set; }
        public MineCellTypeEnum Type { get; set; }

        public MineCell(int x, int y)
        {
            X = x;
            Y = y;
            SurroundingMineCount = 0;
            ClusterSize = 0;
            Status = MineCellStatusEnum.Default;
            Type = MineCellTypeEnum.Land;
        }
    }



}