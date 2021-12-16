using Algorithms.Chapter1;
using Algorithms.Chapter2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Chapter4
{
    public class LazyPrimMST
    {
        private bool[] _marked;
        /// <summary>
        /// 用的是.NET自带的Queue
        /// </summary>
        private NodeQueue<Edge> _mst;
        private MinPQ<Edge> pq;
        public LazyPrimMST(EdgeWeightedGraph g)
        {
            _marked = new bool[g.V];
            _mst = new NodeQueue<Edge>();
            pq = new MinPQ<Edge>(g.E);//MinPQ没有实现自动调整大小，先将就着用吧。
            Visit(g, 0);
            while (!pq.IsEmpty())
            {
                var e = pq.DelMin();
                var v = e.Either();
                v = !_marked[v] ? v : e.Other(v);//至少会有一条边已在生成树中。
                if (!_marked[v])
                {
                    _mst.Enqueue(e);
                    Visit(g, v);
                }
            }
        }
        private void Visit(EdgeWeightedGraph g, int v)
        {
            _marked[v] = true;
            foreach (var e in g.Adj(v))
            {
                if(!_marked[e.Other(v)])
                    pq.Insert(e);
            }
        }
        public IEnumerable<Edge> Edges()
        {
            return _mst;
        }
    }
}
