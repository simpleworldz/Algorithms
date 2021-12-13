using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Chapter3
{
    /// <summary>
    /// 基于拉链法的散列表
    /// </summary>
    public class SeparateChainingHashST<K,V>
    {
        /// <summary>
        /// 键值对总数
        /// </summary>
        //private int _n;

        /// <summary>
        /// 散列表大小
        /// </summary>
        private int _m;
        /// <summary>
        /// 存放链表对象的数组
        /// </summary>
        private SequentialSearchST<K, V>[] _sts;

        public SeparateChainingHashST():this(997)
        {
        }
        public SeparateChainingHashST(int m)
        {
            _m = m;
            _sts = new SequentialSearchST<K, V>[_m];
            for (int i = 0; i < _sts.Length; i++)
            {
                _sts[i] = new SequentialSearchST<K, V>();
            }
        }
        private int Hash(K key)
        {
            return (key.GetHashCode() & 0x7fffffff) % _m;
        }
        public V Get(K key)
        {
            return _sts[Hash(key)].Get(key);
        }
        public void Put(K key, V val)
        {
            _sts[Hash(key)].Put(key, val);
        }
    }
}
