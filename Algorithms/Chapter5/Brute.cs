using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Chapter5
{
    public class Brute
    {
        public static int Search(string text, string pat)
        {
            for (int i = 0; i <= text.Length - pat.Length; i++)
            {
                for (int j = 0; j < pat.Length; j++)
                {
                    if (pat[j] != text[i + j])
                    {
                        break;
                    }
                    if (j == pat.Length - 1)
                    {
                        return i;
                    }
                }
            }
            return -1;
        }
    }
}
