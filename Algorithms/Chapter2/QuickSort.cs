using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Chapter2
{
    public class QuickSort<T> where T : IComparable<T>
    {
        public static void Sort(T[] a)
        {
            //首先打乱数组 --这里没有实习

            Sort(a, 0, a.Length - 1);
        }
        private static void Sort(T[] a, int lo, int hi)
        {
            //由于小数组插入排序快于快速排序，可以当数组Size小于一定值时，切换成插入排序。
            if (lo >= hi) return;
            int j = Partition(a, lo, hi);
            Sort(a, lo, j - 1);
            Sort(a, j + 1, hi);

        }
        private static int Partition(T[] a, int lo, int hi)
        {
            var v = a[lo];
            int i = lo, j = hi + 1;
            while (true)
            {
                while (Common.Less(a[++i], v)) { if (i == hi) break; }
                while (Common.Less(v, a[--j])) { if (j == lo) break; }
                if (i >= j) break;
                a.Exch(i, j);
            }
            a.Exch(lo, j);
            return j;
        }
        public static void Sort3Way(T[] a)
        {
            Sort3Way(a, 0, a.Length - 1);
        }
        private static void Sort3Way(T[] a, int lo, int hi)
        {
            if (lo >= hi) return;
            int lt = lo, i = lo + 1, gt = hi;
            var v = a[lo];
            while(i <= gt)
            {
                int cmp = a[i].CompareTo(v);
                if (cmp < 0) a.Exch(i++, lt++);
                else if (cmp > 0) a.Exch(i, gt--);
                else i++;
            }
            Sort3Way(a, lo, lt - 1);
            Sort3Way(a, gt + 1, hi);
        }
        #region 我的实现
        public static void SortMy(T[] a, int lo, int hi)
        {
            if (lo >= hi) return;
            var v = a[lo];
            int i = lo + 1, j = hi;
            while (i <= j)
            {
                while (i <= hi && Common.Less(a[i], v)) i++;
                while (j >= lo && Common.Less(v, a[j])) j--;
                if (i < j)
                    a.Exch(i, j);
            }

            //if(Common.Less(a[w],k)) //while 循环改为 <= 即可
            a.Exch(lo, j);
            //[!]切分出错了
            //Sort(a, lo, (lo + hi) / 2);
            //Sort(a, (lo + hi) / 2 + 1, hi);
            SortMy(a, lo, j - 1);
            SortMy(a, j + 1, hi);
        }

        /// <summary>
        /// 失败了
        /// </summary>
        /// <param name="a"></param>
        /// <param name="lo"></param>
        /// <param name="hi"></param>
        private static void Sort3WayMY(T[] a, int lo, int hi)
        {
            if (lo >= hi) return;
            var v = a[lo];
            int k = lo, i = lo, j = hi;

            while (i < j)
            {
                //Console.WriteLine("i: "+i);
                if (Common.Less(a[i], v))
                {
                    a.Exch(i++, k++);
                }
                else if (Common.Less(v, a[i]))
                {
                    while (Common.Less(v, a[j]))
                    {
                        if (j == i) break;
                        j--;
                        //Console.WriteLine(j);
                    }
                    a.Exch(i, j);
                }
                else
                {
                    i++;
                }
            }
            Sort3WayMY(a, lo, k - 1);
            Sort3WayMY(a, j + 1, hi);
        }
        #endregion
    }
}
