using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Chapter2
{
    public static class Common
    {
        public static void Exch<T>(this T[] a, int i, int j)
        {
            //if (i == j) return;
            var temp = a[i];
            a[i] = a[j];
            a[j] = temp;
        }
        public static bool Less<T>(T v, T w) where T : IComparable<T>
        {
            return v.CompareTo(w) < 0;
        }
        //public static bool Less<T>(this T[] a, int i, int j) where T:IComparable<T>
        //{
        //    return a[i].CompareTo(a[j]) < 0;
        //}
        public static bool Less<T>(this T[] a, int i, int j) where T : IComparable<T>
        {
            return a[i].CompareTo(a[j]) < 0;
        }
        public static bool IsSort<T>(this T[] a) where T : IComparable<T>
        {
            for (int i = 1; i < a.Length; i++)
            {
                if (Less(a[i],a[i - 1])) return false;
            }
            return true;
        }

        public static void Show<T>(this T[] a) where T : IComparable<T>
        {
            foreach (var item in a)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
        }
    }
}
