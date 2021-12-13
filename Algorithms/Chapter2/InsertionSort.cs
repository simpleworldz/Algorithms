using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Chapter2
{
    public class InsertionSort
    {
        /// <summary>
        /// 当前值和前一个值比较，小于前一个值则交换，直到当前值大于或等于前一个值时停止。
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="a"></param>
        public static void Sort<T>(T[] a) where T : IComparable<T>
        {
            for (int i = 1; i < a.Length; i++)
            {
                for (int j = i; j > 0 && Common.Less(a[j],a[j - 1]); j--)
                {
                    a.Exch(j, j - 1);
                }
            }
        }

        /// <summary>
        /// 找到当前值该属的位置，并插入该位置，后面的值向后移动一格。（比较符合“插入”这个词）
        /// 与算法4中的方法相比
        /// 缺点：1.不够简洁 2.即使是部分有序的输入，也需要N^2级别比较。3.多了个循环，但其实没到0(N^3)级别
        /// 优点？：给数组赋值次数要少点（Exch算两次赋值的话）。
        /// </summary>
        public static void SortMy<T>(T[] a)where T:IComparable<T>
        {
            for (int i = 1; i < a.Length; i++)
            {
                var iVal = a[i];
                for (int j = 0; j < i; j++)
                {
                    if (Common.Less(iVal, a[j]))
                    {
                        for (int k = i; k > j; k--)
                        {
                            a[k] = a[k - 1]; 
                        }
                        a[j] = iVal;
                        //[!]别漏了
                        break;
                    }
                }
            }
        }
    }
}
