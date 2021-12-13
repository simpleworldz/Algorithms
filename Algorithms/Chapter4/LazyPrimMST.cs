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
        private NodeQueue<Edge> _mst;
        private MinPQ<Edge> pq;
        public LazyPrimMST(EdgeWeightedGraph g)
        {
            _marked = new bool[g.V];
            _mst = new NodeQueue<Edge>();
            pq = new MinPQ<Edge>(g.V);//MinPQ没有实现自动调整大小，先将就着用吧。
            Visit(g, 0);
        }

        private void Visit(EdgeWeightedGraph g, int v)
        {
            foreach (var e in g.Adj(v))
            {
                pq.Insert(e);
            }
        }
    }
}
