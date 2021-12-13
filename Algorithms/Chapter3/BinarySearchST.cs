using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Chapter3
{
    public class BinarySearchST<K, V> where K : IComparable<K>
    {
        private K[] _keys;
        private V[] _vals;
        private int _len;
        public BinarySearchST(int capacity)
        {
            _keys = new K[capacity];
            _vals = new V[capacity];
        }
        /// <summary>
        /// 返回小于给定键的数量
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public int Rank(K key)
        {
            int lo = 0, hi = _len - 1;
            while (lo <= hi)
            {
                int mid = lo + (hi - lo) / 2;
                int cmp = key.CompareTo(_keys[mid]);
                if (cmp > 0) lo = mid + 1;
                else if (cmp < 0) hi = mid - 1;
                else return mid;
            }
            return lo;
        }
        public V Get(K key)
        {
            if (_len == 0) return default(V);
            int low = Rank(key);
            if (low < _len && key.CompareTo(_keys[low]) == 0) return _vals[low];
            else return default(V);
        }
        public void Put(K key, V val)
        {
            int low = Rank(key);
            if (low < _len && key.CompareTo(_keys[low]) == 0)
            {
                _vals[low] = val;
                return;
            }

            for (int i = _len; i > low; i--)
            {
                _keys[i] = _keys[i - 1];
                _vals[i] = _vals[i - 1];
            }
            _keys[low] = key;
            _vals[low] = val;
            _len++;
        }
        #region 我的实现
        public V GetMy(K key)
        {
            int low = Rank(key);
            int cmp = key.CompareTo(_keys[low]);
            if (cmp == 0) return _vals[low];
            else return default(V);
        }

        public void PutMy(K key, V val)
        {
            int low = Rank(key);
            int cmp = key.CompareTo(_keys[low]);
            if (cmp == 0)
            {
                _vals[low] = val;
            }
            else
            {
                for (int i = _len; i > low; i--)
                {
                    _keys[i] = _keys[i - 1];
                    _vals[i] = _vals[i - 1];
                }
                _keys[low] = key;
                _vals[low] = val;
                _len++;
            }
        }
        #endregion
    }
}
