using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Chapter3
{
    public class LinearProbingHashST<K, V> where K : IComparable<K>//如果确定只用 == 和 != 则用 IEquatable 更好
    {
        private int _n;
        private int _m;//= 16;
        private K[] _keys;
        private V[] _vals;

        public LinearProbingHashST() : this(16)
        {
            _keys = new K[_m];
            _vals = new V[_m];
        }
        public LinearProbingHashST(int capacity)
        {
            _m = capacity;
            _keys = new K[_m];
            _vals = new V[_m];
        }
        private int Hash(K key)
        {
            return (key.GetHashCode() & 0x7fffffff) % _m;
        }

        public V Get(K key)
        {
            var hash = Hash(key);
            for (var i = Hash(key); _keys[i].CompareTo(default(K)) != 0; i = (i + 1) % _m)
            {
                if (key.CompareTo(_keys[i]) == 0)
                    return _vals[i];
            }
            return default(V);
        }
        public void Put(K key, V val)
        {
            if (_n >= _m / 2) Resize(_m * 2);
            int i;
            //for (i = Hash(key); _keys[i] != null; i = (i + 1) % _m)
            //for (i = Hash(key); _keys[i] != default(K); i = (i + 1) % _m)
            //这个default(K)就很难帮，也就是说，当K为数字类型的时候，不可以将 0 作为键
            for (i = Hash(key); _keys[i].CompareTo(default(K)) != 0; i = (i + 1) % _m)
            {
                if (key.CompareTo(_keys[i]) == 0)
                {
                    _vals[i] = val;
                    return;
                }
            }
            _keys[i] = key;
            _vals[i] = val;
            _n++;
        }

        private void Resize(int size)
        {
            var newST = new LinearProbingHashST<K, V>(size);
            for (int i = 0; i < _m; i++)
            {
                if (_keys[i] != null)
                    newST.Put(_keys[i], _vals[i]);
            }
            _keys = newST._keys;
            _vals = newST._vals;
            _m = newST._m;
        }
        #region 我的实现
        public V GetMy(K key)
        {
            var hash = Hash(key);
            while (_keys[hash] != null)
            {
                if (_keys[hash].CompareTo(key) == 0)
                    return _vals[hash];
                if (hash == _m - 1) hash = 0;
                else hash++;
            }
            return default(V);
        }
        public void PutMy(K key, V val)
        {
            if (_n >= _m / 2) ResizeMy(_m * 2);
            var hash = Hash(key);
            while (_keys[hash] != null)
            {
                if (_keys[hash].CompareTo(key) == 0)
                {
                    _vals[hash] = val;
                    return;
                }
                //[!]
                //if (hash == _m) hash = 0;
                if (hash == _m - 1) hash = 0;
                else hash++;
            }
            _keys[hash] = key;
            _vals[hash] = val;
            _n++;
        }

        private void ResizeMy(int size)
        {
            var oldKeys = _keys;
            var oldVals = _vals;
            _m = size;
            //[!]
            _n = 0;
            _keys = new K[_m];
            _vals = new V[_m];
            for (int i = 0; i < oldKeys.Length; i++)
            {
                if (oldKeys[i] != null)
                    Put(oldKeys[i], oldVals[i]);
            }
        }
        #endregion
    }
}
