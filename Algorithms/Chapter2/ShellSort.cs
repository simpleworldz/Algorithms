using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Chapter2
{
    public static class ShellSort
    {
        /// <summary>
        /// 将数组以一定间隔分成多个子集进行原地排序。间隔逐渐减小，直到为1。
        /// </summary>
        public static void Sort<T>(T[] a) where T : IComparable<T>
        {
            var N = a.Length;
            var h = 1;
            while (h < N / 3) h += 3;//1, 4, 13, 40, 121 ...
            while (h >= 1)
            {
                //[@]for (int i = 1; i < a.Length; i++)
                for (int i = h; i < a.Length; i++)
                {
                    for (int j = i; j >= h && Common.Less(a[j], a[j - h]); j -= h)
                    {
                        a.Exch(j, j - h);
                    }
                }
                h /= 3;
            }

        }

        /// <summary>
        /// 将数组以一定间隔分成多个子集进行原地排序。间隔逐渐减小，直到为1。
        /// 与算法四中发方法相比
        /// 不同：算法四中的方法是按顺序对数组一个个元素排序，排序间隔为h。
        /// 这个方法是将数组分为h个子数组，依次对每个子数组进行原地排序。
        /// 缺点：多了个循环，但其实没到0(N^3)级别
        /// </summary>
        public static void SortMy<T>(T[] a) where T : IComparable<T>
        {
            var N = a.Length;
            var h = 1;
            while (h < N / 3) h += 3;//1, 4, 13, 40, 121 ...
            while (h >= 1)
            {
                for (int s = 0; s < h; s++)
                {
                    for (int i = s; i < a.Length; i += h)
                    {
                        for (int j = i; j >= h && Common.Less(a[j], a[j - h]); j -= h)
                        {
                            a.Exch(j, j - h);
                        }
                    }
                }
                h /= 3;
            }

        }

    }
}
