using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Chapter2
{
    public class MaxPQ<T> where T : IComparable<T>
    {
        private T[] pq;
        private int N = 0;

        public MaxPQ(int maxN)
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
            //超出数组长度时的处理
            //if(pq.Length == N + 1)
            //{
            //    var tempPq = pq;
            //    pq = new T[N * 2 + 1];
            //    for (int i = 1; i <= N; i++)
            //        pq[i] = tempPq[i];
            //}
            pq[++N] = t;
            Swim(N);
        }
        public T DelMax()
        {
            //if (IsEmpty()) return default(T);//??
            var max = pq[1];
            pq[1] = pq[N--];
            pq[N + 1] = default(T);//防止对象游离（通知GC清理）
            Sink(1);
            return max;
        }
        private void Swim(int k)
        {
            while (k > 1 && pq.Less(k / 2, k))
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
                if (j + 1 <= N && pq.Less(j, j + 1)) j++;
                if (!pq.Less(k, j)) break;
                pq.Exch(k, j);
                k = j;
            }
        }
    }
}
