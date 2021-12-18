using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Chapter5
{
    public class LSD
    {
        public static void Sort(string[] a, int w)
        {
            int N = a.Length;
            int R = 256;
            var aux = new string[N];
            for (int d = w - 1; d >= 0; d--)
            {
                var count = new int[R + 1];
                for (int i = 0; i < N; i++)
                {
                    aux[i] = a[i];
                }
                //计数
                for (int i = 0; i < N; i++)
                {
                    count[a[i][d] + 1] += 1;
                }
                //将频率转化为索引
                //[!]for (int i = 1; i <= N; i++)
                for (int i = 1; i <= R; i++)
                {
                    count[i] += count[i - 1];
                }
                for (int i = 0; i < N; i++)
                {
                    a[count[aux[i][d]]++] = aux[i];
                }
            }
        }
    }
}
