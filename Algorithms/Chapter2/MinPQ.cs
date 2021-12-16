using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Chapter2
{
    public class MinPQ<T> where T : IComparable<T>
    {
        private T[] pq;
        private int N = 0;

        public MinPQ(int maxN)
        {
            pq = new T[maxN + 1];
        }
        public bool IsEmpty()
        {
            return N == 0;
        }
        public int Size()
        {
            return N;
        }
        public void Insert(T t)
        {
            pq[++N] = t;
            Swim(N);
        }
        public T DelMin()
        {
            //if (IsEmpty()) return default(T);//??
            var min = pq[1];
            pq[1] = pq[N--];
            pq[N + 1] = default(T);//防止对象游离（通知GC清理）
            Sink(1);
            return min;
        }
        private void Swim(int k)
        {
            while (k > 1 && pq.Less(k, k / 2))
            {
                pq.Exch(k, k / 2);
                k = k / 2;
            }
        }
        private void Sink(int k)
        {
            while (k * 2 <= N)
            {
                var j = k * 2;
                if (j + 1 <= N && pq.Less(j + 1, j)) j++;
                if (!pq.Less(j,k)) break;
                pq.Exch(k, j);
                k = j;
            }
        }

        /// <summary>
        /// 堆排序，未实现，算法2.7 P206
        /// </summary>
        /// <param name="a"></param>
        public void Sort(T[] a)
        {
            var l = a.Length;
        }
    }
}
