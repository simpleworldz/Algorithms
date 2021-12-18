using Algorithms.Chapter2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Chapter5
{
    public static class MSD
    {
        private static int _r = 256;
        /// <summary>
        /// 切换成插入排序的阈值
        /// </summary>
        private static int _m = 15;
        private static string[] _aux;

        public static void Sort(string[] a)
        {
            _aux = new string[a.Length];
            Sort(a, 0, a.Length - 1, 0);
        }

        private static void Sort(string[] a, int lo, int hi, int d)
        {

            //if (lo + _m >= hi)
            //{     
            //    InsertionSort.Sort(a, lo, hi);//还没实现这个方法
            //}
            if (lo >= hi) return;
            var count = new int[_r + 2];
            for (int i = lo; i <= hi; i++)
            {
                count[a[i].CharAt(d) + 2]++;
            }
            //[!]for (int r = 0; r < _r; r++)
            for (int r = 0; r < _r + 1; r++)
            {
                count[r + 1] += count[r];
            }
            for (int i = lo; i <= hi; i++)
            {
                _aux[count[a[i].CharAt(d) + 1]++] = a[i];
            }
            //[!]for (int i = lo; i < hi; i++)
            for (int i = lo; i <= hi; i++)
            {
                a[i] = _aux[i - lo];
            }
            for (int r = 0; r < _r; r++)
            {
                //if(count[r] + lo < count[r + 1] + lo - 1)
                //  Console.WriteLine($"{d + 1} {count[r] + lo} {count[r + 1] + lo - 1}");

                //[!]Sort(a, d + 1, count[i] + lo, count[i + 1] + lo);
                //if(count[r] + lo < count[r + 1] + lo - 1)
                Sort(a, count[r] + lo, count[r + 1] + lo - 1, d + 1);
            }
        }
        #region 我的实现
        /// <summary>
        /// 失败了
        /// </summary>
        /// <param name="a"></param>
        /// <param name="d"></param>
        /// <param name="lo"></param>
        /// <param name="hi"></param>
        private static void SortMy(string[] a, int d, int lo, int hi)
        {

            //if (lo + _m >= hi)
            //{     
            //    InsertionSort.Sort(a, lo, hi);//还没实现这个方法
            //}
            if (lo + 1 >= hi) return;
            var count = new int[_r + 2];
            for (int i = lo; i <= hi; i++)
            {
                count[a[i][d] + 1]++;
            }
            count[0] = lo;
            for (int i = 0; i < _r; i++)
            {
                count[i + 1] += count[i];
            }
            for (int i = lo; i <= hi; i++)
            {
                _aux[count[_aux[i][d]]++] = a[i];
            }
            for (int i = lo; i < hi; i++)
            {
                a[i] = _aux[i];
            }
            for (int i = 0; i < _r; i++)
            {
                Sort(a, d + 1, count[i], count[i + 1]);
            }
        }
        #endregion
    }
}
