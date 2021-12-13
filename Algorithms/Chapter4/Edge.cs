using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Chapter4
{
    public class Edge : IComparable<Edge>//IComparable<Edge> 这个有必要吗？
    {
        private readonly int _v;
        private readonly int _w;
        private readonly double _weight;
        public double Weight { get => _weight; }
        public Edge(int v, int w, double weight)
        {
            _v = v;
            _w = w;
            _weight = weight;
        }
        public int Either()
        {
            return _v;
        }
        public int Other(int vertex)
        {
            if (vertex == _v) return _w;
            else if (vertex == _w) return _v;
            else throw new Exception("Inconsistent edge");
        }
        public int CompareTo(Edge that)
        {
            if (this.Weight < that.Weight) return -1;
            else if (this.Weight > that.Weight) return +1;
            else return 0;
        }
        public override string ToString()
        {
            return $"{_v}-{_w} {_weight}";
        }
    }
}
