using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MineSweeper
{
    public enum MineCellStatusEnum
    {
        Default = 0,
        Flagged = 1,
        Revealed = 2,
        Exploded = 3
    }
}
