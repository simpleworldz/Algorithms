using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Chapter2
{
    public class SelectionSort
    {
        /// <summary>
        /// 选出最小值，和a[0]交换；次一小值和a[1]交换；依次。。
        /// </summary>
        public static void Sort<T>(T[] a) where T : IComparable<T>
        {
            for (int i = 0; i < a.Length - 1; i++)
            {
                var min = i;
                for (int j = i + 1; j < a.Length; j++)
                {
                    if (Common.Less(a[j], a[min])) min = j;
                }
                a.Exch(i, min);
            }
        }
    }
}
