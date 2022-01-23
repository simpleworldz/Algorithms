using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Chapter5
{
    public class BoyerMoore
    {
        private int[] _right;
        private string _pat;
        private int _m;
        public BoyerMoore(string pat)
        {
            _pat = pat;
            _m = _pat.Length;
            _right = Enumerable.Repeat(-1, 256).ToArray();
            //_right = Enumerable.Repeat(_m, 256).ToArray();

            for (int i = 0; i < _m; i++)
            {
                _right[pat[i]] = i;
            }
        }

        public int Search(string text)
        {
            int i,j = 0;
            for (i = 0; i <= text.Length - _m && j < _m;)
            {
                Console.WriteLine("i: " + i);
                //j应该从 _m - 1 开始。
                for (j = 0; j < _m; j++)
                {
                Console.WriteLine("j: "+j);
                    var c = text[i + j];
                    if (c != _pat[j])
                    {
                        int skip = j - _right[c];
                        if (skip > 0)
                        {
                            i += skip;
                        }
                        else
                        {
                            i++;
                        }
                        break;
                    }
                }
            }
            if (j == _m) return i;
            return -1;
        }
    }
}
