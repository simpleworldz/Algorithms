using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphs
{
 public   class DepthFirstSearch
    {
        int count;
        bool[] marked;
        public DepthFirstSearch(Graph g,int s)
        {
            marked = new bool[g.Vertex];
            DFS(g, s);
        }

        private void DFS(Graph g, int v)
        {  //放在这边 在下面的话 第一轮就有问题
            count++;
            marked[v] = true;
            foreach (var item in g.Adj(v))
            {
                if (!marked[item])
                {
                    //count++;
                    //Marked[item] = true;
                    DFS(g, item);
                }
            }
        }

        public bool IsMarked(int w)
        {
            return marked[w];
        }
        public int Count()
        {
            return count;
        }
        
    }
}
