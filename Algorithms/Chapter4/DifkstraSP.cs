using Algorithms.Chapter2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Chapter4
{
    public class DifkstraSP
    {
        private DirectedEdge[] _edgeTo;
        private double[] _distTo;
        private IndexMinPQ<double> _pq;

        public DifkstraSP(EdgeWeightedDigraph g, int s)
        {
            _edgeTo = new DirectedEdge[g.V];
            _distTo = Enumerable.Repeat(double.PositiveInfinity, g.V).ToArray();
            _pq = new IndexMinPQ<double>(g.V);
            _distTo[s] = 0.0;

            _pq.Insert(s, 0.0);
            while (!_pq.IsEmpty())
                Relax(g, _pq.DelMin());
        }
        private void Relax(EdgeWeightedDigraph g, int v)
        {
            foreach (var e in g.Adj(v))
            {
                int w = e.To;
                if (_distTo[v] + e.Weight < _distTo[w])
                {
                    _edgeTo[w] = e;
                    _distTo[w] = _distTo[v] + e.Weight;
                    if (_pq.Contains(e.To))
                        _pq.Change(e.To, _distTo[w]);
                    else
                        _pq.Insert(e.To, _distTo[w]);
                }
            }
        }
        #region 我的实现
        public void DifkstraSPMy(EdgeWeightedDigraph g, int s)
        {
            _edgeTo = new DirectedEdge[g.V];
            _distTo = Enumerable.Repeat(double.PositiveInfinity, g.V).ToArray();
            _distTo[s] = 0.0;
            _pq = new IndexMinPQ<double>(g.V);
            foreach (var e in g.Adj(s))
            {
                _edgeTo[e.To] = e;
                _distTo[e.To] = e.Weight;
                _pq.Insert(e.To, e.Weight);
            }
            while (!_pq.IsEmpty())
            {
                var i = _pq.DelMin();
                foreach (var e in g.Adj(i))
                {
                    RelaxMy(i, e);
                }
            }
        }
        private void RelaxMy(int i, DirectedEdge e)
        {
            if (_distTo[i] + e.Weight < _distTo[e.To])
            {
                _edgeTo[e.To] = e;
                _distTo[e.To] = _distTo[i] + e.Weight;
                if (_pq.Contains(e.To))
                    _pq.Change(e.To, _distTo[i] + e.Weight);
                else
                    _pq.Insert(e.To, _distTo[i] + e.Weight);
            }
        }
        #endregion
        public IEnumerator<DirectedEdge> GetEnumerator()
        {
            foreach (var e in _edgeTo)
            {
                yield return e;
            }
        }
    }
}
