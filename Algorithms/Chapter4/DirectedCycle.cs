using Algorithms.Chapter1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Chapter4
{
    public class DirectedCycle
    {
        private bool[] _marked;
        private int[] _pathTo;
        /// <summary>
        /// 有向环上的地点（如果有环）
        /// </summary>
        private NodeStack<int> _cycle;
        /// <summary>
        /// 递归调用的栈上的顶点
        /// </summary>
        private bool[] _onStack;

        public DirectedCycle(Digraph g)
        {
            _marked = new bool[g.V];
            _pathTo = new int[g.V];
            _onStack = new bool[g.V];
            for (int v = 0; v < g.V; v++)
            {
                if (!_marked[v])
                    DFS(g, v);
            }
        }
        private void DFS(Digraph g, int v)
        {
            _onStack[v] = true;
            _marked[v] = true;
            foreach (var w in g.Adj(v))
            {
                if (HasCycle()) return;
                else if (!_marked[w])
                {
                    _pathTo[w] = v;
                    DFS(g, w);
                }
                else if (_onStack[w])
                {
                    _cycle = new NodeStack<int>();
                    for (int i = v; i != w; i = _pathTo[i])
                    {
                        _cycle.Push(i);
                    }
                    _cycle.Push(w);
                    _cycle.Push(v);
                }
            }
            _onStack[v] = false;
        }
        public bool HasCycle()
        {
            return _cycle != null;
        }
        public IEnumerable<int> Cycle()
        {
            return _cycle;
        }

        #region 我的实现
        /// <summary>
        /// 实现有误：因为遇到!_marked[w]并不能说明就有环
        /// </summary>
        /// <param name="g"></param>
        /// <param name="v"></param>
        private void DFSMy(Digraph g, int v)
        {
            if (HasCycle()) return;
            _marked[v] = true;
            foreach (var w in g.Adj(v))
            {
                if (!_marked[w])
                {
                    _pathTo[w] = v;
                    DFS(g, w);
                }
                else
                {
                    _cycle = new NodeStack<int>();
                    for (int i = v; i != w; i = _pathTo[i])
                    {
                        _cycle.Push(i);
                        //将_onStack的意义理解错了
                        _onStack[i] = true;
                    }
                    _cycle.Push(w);
                    _onStack[w] = true;
                    _cycle.Push(v);
                }
            }
        }
        #endregion
    }
}
