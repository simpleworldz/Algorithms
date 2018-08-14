using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyIO;
namespace Bintree
{
    class Program
    {
        static void Main(string[] args)
        {
            BST<string, int> bST = new BST<string, int>();
            string[] strs = In.ReadEnWords(@"..\..\..\tale.txt");
            Console.WriteLine("共{0}个词", strs.Length);
            Stopwatch sp = new Stopwatch();
            sp.Start();
            for (int i = 0; i < strs.Length; i++)
            {
                bST.Put(strs[i], bST.Get(strs[i])+1);
            }
            sp.Stop();
            Console.WriteLine("共{0}个词，其中不重复的有{1},花时{2}ms", strs.Length, bST.Size(),sp.ElapsedMilliseconds);
            //bST.Print();
            Console.ReadKey();
        }
    }
}
