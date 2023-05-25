using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MineSweeperPro
{
    public class MineCellComparer : IComparer<MineCell>
    {
        private readonly string[] _propertyNames;
        private readonly bool[] _sortDirections;

        public MineCellComparer(string[] propertyNames, bool[] sortDirections)
        {
            _propertyNames = propertyNames;
            _sortDirections = sortDirections;
        }

        public int Compare(MineCell x, MineCell y)
        {
            for (int i = 0; i < _propertyNames.Length; i++)
            {
                string propertyName = _propertyNames[i];
                bool sortDirection = _sortDirections[i];

                var valueX = (int)x.GetType().GetProperty(propertyName).GetValue(x);
                var valueY = (int)y.GetType().GetProperty(propertyName).GetValue(y);

                int result = sortDirection ? valueX.CompareTo(valueY) : valueY.CompareTo(valueX);
                if (result != 0)
                    return result;
            }

            return 0;
        }
    }
}
