using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphs
{
    class Program
    {
        static void Main(string[] args)
        {
            Graph graph = new Graph(@"..\..\..\tinyG.txt");
            Console.WriteLine(graph.ToString());
            DepthFirstSearch dfs = new DepthFirstSearch(graph, 0);
            //string str = "";
            for (int i = 0; i < graph.Vertex; i++)
            {
                if (dfs.IsMarked(i))
                {
                    Console.Write(i + " ");
                }

            }
            Console.WriteLine();
            //Console.WriteLine(str);
            int start = 0;
            BreadthFirstPaths bfs = new BreadthFirstPaths(graph, start);
            for (int i = 0; i < graph.Vertex; i++)
            {
                if (bfs.HasPathTO(i))
                {
                    foreach (var item in bfs.PathTo(i))
                    {
                        if (item == start)
                        {
                            Console.Write(item);
                        }
                        else
                        {

                        Console.Write("→" + item);
                        }
                    }
                    Console.WriteLine();
                }
                else
                {
                    Console.WriteLine("没有到{0}的路径", i);
                }
            }
            Console.ReadKey();
        }
    }
}
