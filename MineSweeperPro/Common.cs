using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MineSweeperPro
{
    internal class Common
    {
        public static T[] FlattenArray<T>(T[,] array)
        {
            int rows = array.GetLength(0);
            int cols = array.GetLength(1);

            T[] flattenedArray = new T[rows * cols];
            int index = 0;

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    flattenedArray[index] = array[i, j];
                    index++;
                }
            }

            return flattenedArray;
        }

        public static T[] RemoveFirst<T>(T[] array)
        {
            if (array.Length < 1)
            {
                // If the array is empty, return the array as is
                return array;
            }

            T[] newArray = new T[array.Length - 1];
            Array.Copy(array, 1, newArray, 0, array.Length - 1);
            return newArray;
        }
    }
}
