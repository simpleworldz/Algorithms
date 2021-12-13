using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Chapter2
{

    public class MergeSort<T> where T : IComparable<T>
    {
        static T[] aux;
        public static void Sort(T[] a)
        {
            aux = new T[a.Length];
            Sort(a, 0, a.Length - 1);
        }

        private static void Sort(T[] a, int lo, int hi)
        {
            if (lo >= hi) return;
            var mid = (lo + hi) / 2;
            Sort(a, lo, mid);
            Sort(a, mid + 1, hi);
            Merge(a, lo, mid, hi);
        }
        public static void SortBU(T[] a)
        {
            int N = a.Length;
            aux = new T[N];
            //for (int sz = 1; sz <= N; sz += sz) //sz数组大小
            for (int sz = 1; sz < N; sz += sz) //sz数组大小
            {
                //for (int lo = 0; lo <= N; lo += sz * 2)
                for (int lo = 0; lo < N - sz; lo += sz * 2)
                {
                    Merge(a, lo, lo + sz - 1, Math.Min(lo + sz * 2 - 1, N - 1));
                }
            }
        }
        #region 我的自低向上实现
        public static void SortBUMy(T[] a)
        {
            aux = new T[a.Length];
            var h = 1;
            //[!]while (h <= a.Length / 2) //错误
            while (h < a.Length)
            {
                for (int i = 0; i < a.Length; i += 2 * h)
                {
                    if (i + 2 * h - 1 < a.Length)
                        Merge(a, i, i + h - 1, i + 2 * h - 1);
                    else
                        Merge(a, i, i + h - 1, a.Length - 1);
                }
                h *= 2;
            }
        }
        #endregion
        private static void Merge(T[] a, int lo, int mid, int hi)
        {
            //j = mid + 1 对应 Sort(a, mid + 1, hi)
            int i = lo, j = mid + 1;
            //[!] k <= hi
            for (int k = lo; k <= hi; k++) aux[k] = a[k];

            for (int k = lo; k <= hi; k++)
            {
                if (i >= mid + 1) a[k] = aux[j++];
                else if (j > hi) a[k] = aux[i++];
                else if (Common.Less(aux[i], aux[j])) a[k] = aux[i++];
                else a[k] = aux[j++];
            }
        }
    }
    public class MergeSortMy
    {
        public static void Sort<T>(T[] a) where T : IComparable<T>
        {
            Sort(a, 0, a.Length - 1);
        }

        private static void Sort<T>(T[] a, int lo, int hi) where T : IComparable<T>
        {
            if (lo >= hi) return;
            var mid = (lo + hi) / 2;
            Sort(a, lo, mid);
            Sort(a, mid + 1, hi);
            Merge(a, lo, mid + 1, hi + 1);
        }

        public static void Merge<T>(T[] a, int i1, int i2, int l) where T : IComparable<T>
        {
            //[!] l表示长度
            var tempArr = new T[l];
            for (int i = i1; i < l; i++) tempArr[i] = a[i];
            int ii1 = i1, ii2 = i2;
            while (i1 < l)
            {
                if (Common.Less(tempArr[ii1], tempArr[ii2]))
                {
                    //[!] 注意a 和 tempArr
                    a[i1++] = tempArr[ii1++];
                    if (ii1 >= i2)
                    {
                        //[!] i1++
                        while (ii2 < l) a[i1++] = tempArr[ii2++];
                        return;
                    }
                }
                else
                {
                    a[i1++] = tempArr[ii2++];
                    if (ii2 >= l)
                    {
                        while (ii1 < i2) a[i1++] = tempArr[ii1++];
                        return;
                    }
                }
            }


        }
    }
}
