using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Chapter4
{
    public class EdgeWeightedGraph
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
        private ConcurrentBag<Edge>[] _adj;

        public int V { get => _v; }
        public int E { get => _e; }
        public EdgeWeightedGraph(int v)
        {
            _v = v;
            _e = 0;
            _adj = new ConcurrentBag<Edge>[_v];
            for (int i = 0; i < _adj.Length; i++)
            {
                _adj[i] = new ConcurrentBag<Edge>();
            }
        }
        /// <summary>
        /// 暂且用string[]作为参数吧
        /// </summary>
        /// <param name="dic"></param>
        public EdgeWeightedGraph(string[] arr) : this(int.Parse(arr[0]))
        {
            //int e = arr[1];
            for (int i = 2; i < arr.Length - 2; i += 3)
            {
                AddEdge(new Edge(int.Parse(arr[i]), int.Parse(arr[i + 1]),double.Parse(arr[i+2])));
            }
        }

        private void AddEdge(Edge e)
        {
            var v = e.Either();
            var w = e.Other(v);
            _adj[v].Add(e);
            _adj[w].Add(e);
            _e++;
        }

        public IEnumerable<Edge> Adj(int v)
        {
            return _adj[v];
        }
    }
}
