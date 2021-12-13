using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Chapter4
{
    public class Digraph
    {
        /// <summary>
        /// 顶点数
        /// </summary>
        private readonly int _v;
        /// <summary>
        /// 边数
        /// </summary>
        private int _e;
        /// <summary>
        /// 使用的是.Net自带的Bag
        /// </summary>
        private ConcurrentBag<int>[] _adj;

        public int V { get => _v; }
        public int E { get => _e; }
        public Digraph(int v)
        {
            _v = v;
            _e = 0;
            _adj = new ConcurrentBag<int>[_v];
            for (int i = 0; i < _adj.Length; i++)
            {
                _adj[i] = new ConcurrentBag<int>();
            }
        }
        /// <summary>
        /// 暂且用int[]作为参数吧
        /// </summary>
        /// <param name="dic"></param>
        public Digraph(int[] arr) : this(arr[0])
        {
            for (int i = 2; i < arr.Length - 1; i += 2)
            {
                AddEdge(arr[i], arr[i + 1]);
            }
        }

        private void AddEdge(int v, int w)
        {
            _adj[v].Add(w);
            _e++;
        }
        public Digraph Reverse()
        {
            var r = new Digraph(_v);
            for (int v = 0; v < _v; v++)
            {
                foreach (var w in this.Adj(v))
                {
                    r.AddEdge(w, v);
                }
            }
            return r;
        }
        public IEnumerable<int> Adj(int v)
        {
            return _adj[v];
            //foreach (var item in _adj[v])
            //{
            //    yield return item;
            //}
        }
    }
}
