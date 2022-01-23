using Algorithms.Chapter2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Chapter5
{
    public static class Quick3String
    {
        public static void Sort(string[] a)
        {
            Sort(a, 0, a.Length - 1, 0);
        }
        private static void Sort(string[] a, int lo, int hi, int d)
        {
            if (lo >= hi) return;
            //[!]int i = 1, gt = hi, lt = 0;
            int lt = lo, gt = hi, i = lo + 1;
            var mid = a[lo].CharAt(d);
            while (i <= gt)
            {
                var cmp = a[i].CharAt(d).CompareTo(mid);
                if (cmp < 0)
                {
                    a.Exch(i++, lt++);
                }
                else if (cmp > 0)
                {
                    a.Exch(i, gt--);
                }
                else
                {
                    i++;
                }
            }
            Sort(a, lo, lt - 1, d);
            //这个别忘了
            if (mid >= 0)
                Sort(a, lt, i - 1, d + 1);
            Sort(a, i, hi, d);
        }
        #region
        private static void SortMy(string[] a, int lo, int hi, int d)
        {
            if (lo >= hi) return;
            //[!]int i = 1, gt = hi, lt = 0;
            int lt = lo, gt = hi, i = lo + 1;
            var mid = a[lo].CharAt(d);
            while (i <= gt)
            {
                var cmp = a[i].CharAt(d).CompareTo(mid);
                if (cmp < 0)
                {
                    a.Exch(i++, lt++);
                }
                else if (cmp > 0)
                {
                    //Algorithms.Chapter2.Common.Less(a[j][d], mid);
                    while (a[gt].CharAt(d).CompareTo(mid) > 0)
                    {
                        gt--;
                    }
                    if (i < gt)
                        a.Exch(i, gt);
                }
                else
                {
                    i++;
                }
            }
            Sort(a, lo, lt - 1, d);
            //这个别忘了
            if (mid >= 0)
                Sort(a, lt, i - 1, d + 1);
            Sort(a, i, hi, d);
        }
        #endregion
    }
}
