using MyIO;
using Structure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphs
{
    public class Graph
    {
        //注意 写的时候想想为什么要 const
        public int Vertex;
        public int Edge;
        Bag<int>[] adj;
        public void Initialize(int v)
        {
            this.Vertex = v;
            this.Edge = 0;
            adj = new Bag<int>[v];
            //**1莫名其妙 好吧 没有这个 都为default 也就是 null
            for (int i = 0; i < v; i++)
            {
                adj[i] = new Bag<int>();
            }
        }
        public Graph(string filePath)
        {
            int[] ins = In.ReadInts(filePath);
            //失败
            //this(ins[0]);
            Initialize(ins[0]);
            int e = ins[1];
            //**
            for (int i = 1; i <= e; i++)
            {
                Add(ins[i * 2], ins[i * 2 + 1]);
            }

        }
        public void Add(int v, int w)
        {
            adj[v].Add(w);
            adj[w].Add(v);
            Edge++;
        }
        public int V()
        {
            return this.Vertex;
        }
        public int E()
        {
            return this.Edge;
        }
        public Bag<int> Adj(int v)
        {
            return adj[v];
        }
        public string ToString()
        {
            string str = string.Format("{0} Vertices,{1} edges\n", Vertex, Edge);
            for (int i = 0; i < Vertex; i++)
            {
                str += i + ": ";
                //不用这样 优先率
                //str += i;
                //str += ": ";
                foreach (var item in adj[i])
                {
                    str += item;
                    str += " ";
                }
                str += "\n";
            }
            return str;
        }
    }
}
