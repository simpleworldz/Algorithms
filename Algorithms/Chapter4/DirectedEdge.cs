using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Chapter4
{
    public class DirectedEdge
    {
        private readonly int _v;
        public int From { get => _v; }
        private readonly int _w;
        public int To { get => _w; }
        private readonly double _weight;
        public double Weight { get => _weight; }
        public DirectedEdge(int v, int w, double weight)
        {
            _v = v;
            _w = w;
            _weight = weight;
        }
        public int CompareTo(Edge that)
        {
            if (this.Weight < that.Weight) return -1;
            else if (this.Weight > that.Weight) return +1;
            else return 0;
        }
        public override string ToString()
        {
            return $"{_v}->{_w} {_weight}";
        }
    }
}
