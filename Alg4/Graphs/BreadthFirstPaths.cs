using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphs
{
   public class BreadthFirstPaths
    {  
        int start;
        bool[] market;
        int[] edgeTo;

     public BreadthFirstPaths(Graph g,int s)
        {
            market = new bool[g.Vertex];
            edgeTo = new int[g.Vertex];
            start = s;
            BFS(g, s);
        }

        private void BFS(Graph g, int v)
        { 
            Queue<int> queue = new Queue<int>();
            queue.Enqueue(v);
            market[v] = true;
            while (queue.Count !=0)
            {
                int w = queue.Dequeue();
                //market[w] = true;
                foreach (var item in g.Adj(w))
                {
                    if (market[item]!=true)
                    {
                        market[item] = true;
                    queue.Enqueue(item);
                    edgeTo[item] = w;
                    }
                }
            }
        }
        public bool HasPathTO(int v)
        {
            return market[v];
        }
        
        //其实好理解为什么是IEnumerable 而不是Ienumerator的
        //# 这个很好 很强
        public IEnumerable<int> PathTo(int v)
        {
            if (!HasPathTO(v))
            {
                return null;
            }
            Stack<int> path = new Stack<int>();
            //##这个很强
            for (int i = v ; v != start; v = edgeTo[v])
            {
                path.Push(v);
            }
            path.Push(start);
            return path;
        }
    }
}
