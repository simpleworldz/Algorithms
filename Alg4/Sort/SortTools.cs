using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sort
{
   public class SortTools
    { public static bool Less(IComparable v,IComparable w)
        {
            return v.CompareTo(w) < 0;
        }
        public static void exch(IComparable[] a , int i ,int j)
        {
            IComparable b = a[i];
            a[i] = a[j];
            a[j] = b;
        }
        public static void Show(IComparable[] a)
        {
            for (int i = 0; i < a.Length; i++)
            {
                Console.Write(a[i]+" ");
                if (i%10 == 0 && i!=0)
                {
                    Console.WriteLine();
                }
            }
        }
        public static bool IsSorted(IComparable[] a)
        {
            for (int i = 0; i < a.Length-1; i++)
            {
                if(Less(a[i+1],a[i]))
                {
                    return false;
                }
            }
            return true;
        }
    }
}
