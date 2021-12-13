using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Chapter2
{
    public static class SelectionSort_IComparable
    {
        public static void Sort<T>(IComparable<T>[] a)
        {
            for (int i = 0; i < a.Length - 1; i++)
            {
                var min = i;
                for (int j = i + 1; j < a.Length; j++)
                {
                    //[!]if (Less(a[i], a[j])) min = j;
                    if (Less(a[j], a[min])) min = j;
                }
                a.Exch(i, min);
            }
        }

        public static void Exch<T>(this IComparable<T>[] a, int i, int j)
        {
            if (i == j) return;

            var temp = a[i];
            a[i] = a[j];
            a[j] = temp;
        }
        public static bool Less<T>(IComparable<T> v, IComparable<T> w)
        {
            return v.CompareTo((T)w) < 0;
        }
    }
}
