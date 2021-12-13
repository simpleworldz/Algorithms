using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Chapter1
{
    public static class BinarySearch
    {
        /// <summary>
        /// 循环法
        /// </summary>
        public static int Rank(int key, int[] a)
        {
            int lo = 0, hi = a.Length - 1;
            while (lo <= hi)
            {
                int mid = lo + (hi - lo) / 2;
                if (key < a[mid]) hi = mid - 1;
                else if (key > a[mid]) lo = mid + 1;
                else return mid;
            }
            return -1;
        }
        /// <summary>
        /// 递归法
        /// </summary>
        public static int RankR(int key, int[] a)
        {
            return RankR(key, a, 0, a.Length - 1);
        }
        public static int RankR(int key, int[] a, int lo, int hi)
        {
            if (hi < lo) return -1;
            //int mid = lo + hi / 2;
            int mid = lo + (hi - lo) / 2;
            if (key < a[mid]) return RankR(key, a, lo, mid - 1);
            else if (key > a[mid]) return RankR(key, a, mid + 1, hi);
            else return mid;
        }
    }
}
