using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Chapter4
{
    public class EdgeWeightedDigraph
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
        private ConcurrentBag<DirectedEdge>[] _adj;

        public int V { get => _v; }
        public int E { get => _e; }
        public EdgeWeightedDigraph(int v)
        {
            _v = v;
            _e = 0;
            _adj = new ConcurrentBag<DirectedEdge>[_v];
            for (int i = 0; i < _adj.Length; i++)
            {
                _adj[i] = new ConcurrentBag<DirectedEdge>();
            }
        }
        /// <summary>
        /// 暂且用string[]作为参数吧
        /// </summary>
        /// <param name="dic"></param>
        public EdgeWeightedDigraph(string[] arr) : this(int.Parse(arr[0]))
        {
            //int e = arr[1];
            for (int i = 2; i < arr.Length - 2; i += 3)
            {
                AddEdge(new DirectedEdge(int.Parse(arr[i]), int.Parse(arr[i + 1]), double.Parse(arr[i + 2])));
            }
        }

        private void AddEdge(DirectedEdge e)
        {
            var v = e.From;
            _adj[v].Add(e);
            _e++;
        }

        public IEnumerable<DirectedEdge> Adj(int v)
        {
            return _adj[v];
        }
        public IEnumerator<DirectedEdge> GetEnumerator()
        {
            foreach (var item in _adj)
            {
                foreach (var e in item)
                {
                    yield return e;

                }
            }
        }
    }
}
