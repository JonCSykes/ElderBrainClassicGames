using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MineSweeperPro
{
    public class MineField
    {
        public int Width { get; set; } 
        public int Height { get; set; }
        public int MineCount { get; set; }
        public int MineCellsFlaggedCounter { get; set; }
        public int MineCellsRevealedCounter { get; set; }
        public MineCell[,]? MineCellCollection { get; set; }
        public List<MineCell> MineCollection { get; set; }
        public MineCell[]? SortedClusterCollection { get; set; }

        // MineField - Initialize the MineField object.
        public MineField(int width, int height, int mineCount)
        {
            Width = width;
            Height = height;
            MineCount = mineCount;
            MineCellsFlaggedCounter = 0;
            MineCellsRevealedCounter = 0;
            MineCellCollection = new MineCell[Width, Height];
            MineCollection = new List<MineCell>(mineCount);

            InitializeMineField();

            DistributeMines();

            GetAllMineCounts();

            GetAllClusterSizes();
        }

        public void InitializeMineField()
        {
            if (MineCellCollection != null)
            {
                for (var x = 0; x < Width; x++)
                {
                    for (var y = 0; y < Height; y++)
                    {
                        MineCellCollection[x, y] = new MineCell(x, y);
                    }
                }
            }
        }

        // DistributeMines - Randomly sets the Mine type on each mine cell within the minefield until it reaches the total mine count.
        public void DistributeMines()
        {
            int minesPlaced = 0;

            while (minesPlaced < MineCount)
            {
                Random random = new(Guid.NewGuid().GetHashCode());
                int x = random.Next(Width);
                int y = random.Next(Height);

                if (MineCellCollection != null)
                {
                    if (MineCellCollection[x, y].Type != MineCellTypeEnum.Mine)
                    {
                        MineCellCollection[x, y].Type = MineCellTypeEnum.Mine;
                        MineCollection.Add(MineCellCollection[x, y]);
                        minesPlaced++;
                    }
                }
            }
        }

        // GetMineCellGroup - Returns the given mine cell coordinates along with the surrounding 8 mine cells.
        public List<MineCell> GetMineCellGroup(int x, int y)
        {
            return GetMineCellGroup(MineCellCollection[x, y]);
        }

        // GetMineCellGroup - Returns the given mine cell along with the surrounding 8 mine cells.
        public List<MineCell> GetMineCellGroup(MineCell mineCell)
        {
            List<MineCell> mineCellGroup = new List<MineCell>();

            if (MineCellCollection != null)
            {
                for (var x = Math.Max(mineCell.X - 1, 0); x <= Math.Min(mineCell.X + 1, Width - 1); x++)
                {
                    for (var y = Math.Max(mineCell.Y - 1, 0); y <= Math.Min(mineCell.Y + 1, Height - 1); y++)
                    {
                        if (x != mineCell.X || y != mineCell.Y)
                        {
                            mineCellGroup.Add(MineCellCollection[x, y]);
                        }
                    }
                }
            }

            return mineCellGroup;
        }

        // GetMineCount - Returns the total count of mines within the mine cell group of the given mine cell coordinates.
        public int GetMineCount(int x, int y)
        {
            return GetMineCount(MineCellCollection[x, y]);
        }

        // GetMineCount - Returns the total count of mines within the mine cell group of the given mine cell.
        public int GetMineCount(MineCell mineCell)
        {
            var count = 0;

            if (MineCellCollection != null)
            {
                for (var x = Math.Max(mineCell.X - 1, 0); x <= Math.Min(mineCell.X + 1, Width - 1); x++)
                {
                    for (var y = Math.Max(mineCell.Y - 1, 0); y <= Math.Min(mineCell.Y + 1, Height - 1); y++)
                    {
                        if (x != mineCell.X || y != mineCell.Y)
                        {
                            if (MineCellCollection[x, y].Type == MineCellTypeEnum.Mine)
                            {
                                count++;
                            }
                        }
                    }
                }
            }

            return count;
        }

        // GetAllMineCounts - Iterate through the MineCellCollection to calculate and set the surrounding mine count for each mine cell.
        public void GetAllMineCounts()
        {
            if (MineCellCollection != null)
            {
                for (var x = 0; x < Width; x++)
                {
                    for (var y = 0; y < Height; y++)
                    {
                        if (MineCellCollection[x, y].Type != MineCellTypeEnum.Mine)
                        {
                            MineCellCollection[x, y].SurroundingMineCount = GetMineCount(MineCellCollection[x, y]);
                        }
                        else 
                        {
                            MineCellCollection[x, y].SurroundingMineCount = -1;
                        }
                    }
                }
            }
        }

        // GetFlaggedCount - Returns the total count of flagged cells within the mine cell group of the given mine cell coordinates.
        public int GetFlagCount(int x, int y)
        {
            return GetFlagCount(MineCellCollection[x, y]);
        }

        // GetFlaggedCount - Returns the total count of flagged cells within the mine cell group of the given mine cell.
        public int GetFlagCount(MineCell mineCell)
        {
            var count = 0;

            if (MineCellCollection != null)
            {
                for (var x = Math.Max(mineCell.X - 1, 0); x <= Math.Min(mineCell.X + 1, Width - 1); x++)
                {
                    for (var y = Math.Max(mineCell.Y - 1, 0); y <= Math.Min(mineCell.Y + 1, Height - 1); y++)
                    {
                        if (x != mineCell.X || y != mineCell.Y)
                        {
                            if (MineCellCollection[x, y].Status == MineCellStatusEnum.Flagged)
                            {
                                count++;
                            }
                        }
                    }
                }
            }

            return count;
        }

        // GetClusterSize - Gets the cluster size of the given mine cell.
        // A cluster represents how many surrounding cells would be cleared if the given cell was revealed.
        public void GetClusterSize(MineCell mineCell)
        {
            if (mineCell.Status != MineCellStatusEnum.Revealed && mineCell.Type != MineCellTypeEnum.Mine)
            {
                HashSet<(int, int)> visited = new HashSet<(int, int)>();
                Stack<(int, int)> toVisit = new Stack<(int, int)>();

                toVisit.Push((mineCell.X, mineCell.Y));

                int clusterSize = 0;

                while (toVisit.Count > 0)
                {
                    (int cx, int cy) = toVisit.Pop();

                    if (visited.Contains((cx, cy)))
                    {
                        continue;
                    }

                    visited.Add((cx, cy));
                    clusterSize++;

                    if (GetMineCount(cx, cy) == 0)
                    {
                        foreach (var sibling in GetMineCellGroup(cx, cy))
                        {
                            if (!visited.Contains((sibling.X, sibling.Y)) && sibling.Type != MineCellTypeEnum.Mine)
                            {
                                toVisit.Push((sibling.X, sibling.Y));
                            }
                        }
                    }
                }

                mineCell.ClusterSize = clusterSize;
            }
           
        }

        // GetAllClusterSizes - Iterates through all of the mine cells and sets the cluster size on each cell.
        // A cluster represents how many surrounding cells would be cleared if the given cell was revealed.
        public void GetAllClusterSizes()
        {
            if (MineCellCollection != null)
            {
                for (int x = 0; x < Width; x++)
                {
                    for (int y = 0; y < Height; y++)
                    {
                        GetClusterSize(MineCellCollection[x, y]);
                    }
                }
            }

            SortMineCellCollection();
        }

        // SortMineCellCollection - Flattens and sorts the mine cell collection by cluster count descending then by mine count ascending.
        public void SortMineCellCollection()
        {
            if (MineCellCollection != null)
            {
                MineCell[] flattenedMineCells = Common.FlattenArray(MineCellCollection);

                Array.Sort(flattenedMineCells, new MineCellComparer(new string[] { "ClusterSize", "SurroundingMineCount" }, new bool[] { false, true }));

                SortedClusterCollection = flattenedMineCells;
            }
        }
    }
}
