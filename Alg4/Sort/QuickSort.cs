using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sort
{
    public class QuickSort
    {
        public static void Sort(IComparable[] a)
        {
            //{1}先打乱数组 默认不提供 要自己写
            Sort(a, 0, a.Length - 1);
        }
        // #1 private?
        private static void Sort(IComparable[] a, int lo, int hi)
        {//原文为 貌似是更好
         if(lo>=hi) return;
            int j = Partition(a, lo, hi);
            //j == lo 无意义
           // if (j == lo || hi - lo == 1) return;
            Sort(a, lo, j - 1);
            //用j+1 因为j不用参加排序了
            Sort(a, j + 1, hi);

        }

        private static int Partition(IComparable[] a, int lo, int hi)
        {
            IComparable k = a[lo];
            int i = lo;
            //【1】那还不如换成长度 而不是索引呢  可以是下 超出索引界限。。
            int  j = hi + 1;
            while (true)
            {
                while (SortTools.Less(a[++i], k))
                {   //【3】这样不是会多比较好多次吗？  不对 有后面的 *1 做保证？
                    if (i == hi) break;
                    //if (i == j) break;
                }
                while (SortTools.Less(k, a[--j]))
                {
                    if (j == lo) break;
                    //【2】 == ？
                    //if (i == j) break;
                }
                //*1
                if (i >= j) break;
                SortTools.exch(a, i, j);
            }
            SortTools.exch(a, lo, j);
            return j;
        }
    }
}
