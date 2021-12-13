using Algorithms.Chapter1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Chapter4
{
    public class BreadthFirstPath
    {
        /// <summary>
        /// 这个顶点是否调用过BFS()
        /// </summary>
        private bool[] _marked;
        /// <summary>
        /// 从起点到一个顶点的已知路径的最后一个顶点
        /// </summary>
        private int[] _pathTo;
        /// <summary>
        /// 起点
        /// </summary>
        private int _s;
        public BreadthFirstPath(Graph g, int s)
        {
            _marked = new bool[g.V];
            _pathTo = new int[g.V];
            _s = s;
            BFS(g, s);
        }

        private void BFS(Graph g, int s)
        {
            var queue = new NodeQueue<int>();
            _marked[s] = true;
            queue.Enqueue(s);
            while (!queue.IsEmpty())
            {
                int v = queue.Dequeue();
                foreach (var w in g.Adj(v))
                {
                    if (!_marked[w])
                    {
                        _pathTo[w] = v;
                        _marked[w] = true;
                        queue.Enqueue(w);
                    }
                }
            }
        }
        public bool HasPathTo(int v)
        {
            return _marked[v];
        }
        public IEnumerable<int> PathTo(int v)
        {
            if (HasPathTo(v))
            {
                var path = new ResizingArrayStack<int>();
                for (int i = v; i != _s; i = _pathTo[i])
                {
                    path.Push(i);
                }
                path.Push(_s);
                while (!path.IsEmpty())
                {
                    yield return path.Pop();
                }
            };
        }
    }
}
