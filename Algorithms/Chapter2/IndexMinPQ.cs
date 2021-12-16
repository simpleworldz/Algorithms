using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Chapter2
{
    public class IndexMinPQ<V> where V : IComparable<V>
    {
        /// <summary>
        /// maximum number of elements on PQ
        /// </summary>
        private int _maxN;
        /// <summary>
        /// number of elements on PQ
        /// </summary>
        private int _n;
        /// <summary>
        /// binary heap using 1-based indexing
        /// </summary>
        private int[] pq;
        /// <summary>
        /// inverse of pq - qp[pq[i]] = pq[qp[i]] = i
        /// </summary>
        private int[] qp;
        /// <summary>
        /// keys[i] = priority of i
        /// </summary>
        private V[] _vals;

        public IndexMinPQ(int maxN)
        {
            _maxN = maxN;
            _n = 0;
            pq = new int[_maxN + 1];
            qp = new int[_maxN + 1];
            _vals = new V[_maxN + 1];
            for (int i = 0; i <= _maxN; i++)
            {
                qp[i] = -1;
            }
        }
        public bool IsEmpty()
        {
            return _n == 0;
        }
        public int Size()
        {
            return _n;
        }

        public void Insert(int i, V val)
        {
            if (Contains(i)) throw new ArgumentException(("index is already in the priority queue"));
            _vals[i] = val;
            pq[++_n] = i;
            qp[i] = _n;
            Swim(_n);
        }
        public int DelMin()
        {
            //if (IsEmpty()) return default(T);//??
            var min = pq[1];
            Exch(1, _n--);// _n-- 的位置要注意
            Sink(1);
            _vals[min] = default(V);//防止对象游离（通知GC清理）
            qp[min] = -1;
            pq[_n + 1] = -1;
            return min;
        }
        public bool Contains(int i)
        {
            return qp[i] != -1;
        }
        private void Swim(int k)
        {
            while (k > 1 && Less(k, k / 2))
            {
                Exch(k, k / 2);
                k = k / 2;
            }
        }

        private void Sink(int k)
        {
            while (k * 2 <= _n)
            {
                var j = k * 2;
                if (j + 1 <= _n && Less(j + 1, j)) j++;
                if (!Less(j, k)) break;
                Exch(k, j);
                k = j;
            }
        }
        public void Change(int i, V val)
        {
            if (!Contains(i)) throw new ArgumentException("index is not in the priority queue");
            _vals[i] = val;
            Swim(qp[i]);
            Sink(qp[i]);
        }
        private bool Less(int i, int j)
        {
            return _vals.Less(pq[i], pq[j]);
        }
        private void Exch(int i, int j)
        {
            var temp = pq[i];
            pq[i] = pq[j];
            pq[j] = temp;
            qp[pq[i]] = i;
            qp[pq[j]] = j;
        }
        /// <summary>
        /// 堆排序，未实现，算法2.7 P206
        /// </summary>
        /// <param name="a"></param>
    }
}
