using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Chapter2
{
    /// <summary>
    /// 确实实现条件 
    /// 1.需要关联索引的优先队列 
    /// 2.需要有指针的输入，如Stream之类的读取数据后指针自动往后移动的，或者实现了MoveNext的。
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Multiway<T>where T:IComparable<T>
    {
        /// <summary>
        /// 多个有序数组的多项归并
        /// </summary>
        /// <param name="arr"></param>
        public static void Merge(params T[] arr)
        {
            var N = arr.Length;
            var pq = new MaxPQ<T>(N);
            for (int i = 0; i < N; i++)
            {
            }
        }
    }
}
