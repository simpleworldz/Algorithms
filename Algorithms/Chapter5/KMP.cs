using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Chapter5
{
    public class KMP
    {
        private string _pat;
        private int[,] _dfa;
        private int _r;
        public KMP(string pat, int r)
        {
            _r = r;
            var m = pat.Length;
            _dfa = new int[_r, m];

            _dfa[pat[0], 0] = 1;
            for (int j = 1; j < m; j++)
            {
                for (int i = 0; i < _r; i++)
                {
                    if (_dfa[pat[i], j - 1] == j)
                    {
                        _dfa[pat[i], j] = j + 1;
                    }

                }
            }
        }
    }
}
