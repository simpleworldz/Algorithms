using Algorithms.Chapter1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Chapter4
{
    public class DepthFirstPaths
    {
        /// <summary>
        /// 这个顶点是否调用过DFS()
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
        public DepthFirstPaths(Graph g, int s)
        {
            _marked = new bool[g.V];
            _pathTo = new int[g.V];
            _s = s;
            DFS(g, s);
            //for (int i = 0; i < _marked.Length; i++)
            //{
            //    if (!_marked[i])
            //        DFS(g, s);
            //}
        }

        private void DFS(Graph g, int s)
        {
            _marked[s] = true;
            foreach (var w in g.Adj(s))
            {
                if (!_marked[w])
                {
                    _pathTo[w] = s;
                    DFS(g, w);
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
                var path = new NodeStack<int>();
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
