using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Chapter4
{
    public class DepthFirstSearch
    {
        private bool[] _marked;
        private int _count;
        public int Count { get => _count; }
        public DepthFirstSearch(Graph g, int s)
        {
            _marked = new bool[g.V];
            DFS(g, s);
        }

        private void DFS(Graph g, int v)
        {
            _marked[v] = true;
            //s自己也算上
            _count++;
            //Console.WriteLine(v);
            foreach (var w in g.Adj(v))
            {
                if (!_marked[w])
                    DFS(g, w);
            }
        }
    }
}
