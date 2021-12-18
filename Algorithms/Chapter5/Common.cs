using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Chapter5
{
    public static class Common
    {
        public static int CharAt(this string s, int i)
        {
            return s.Length > i ? s[i] : -1;
        }
    }
}
