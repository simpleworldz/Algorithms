using Algorithms.Chapter1;
using Algorithms.Chapter2;
using Algorithms.Chapter3;
using Algorithms.Chapter4;
using Algorithms.Chapter5;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utility;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var p = new Program();
            //p.StackTest();
            //p.QueueTest();
            //p.STTest();
            //p.GraphTest();
            //p.DigraphTest();
            //p.MinimumSpanningTreesTest();
            //p.PriorityQueueTest();
            //p.ShortestPathTest();
            //p.IndexMinPQTest();
            //p.SPTest();
            p.StringTest();
        }
        void StringTest()
        {
            var strArr = FileHandler.ReadFileAsStrArr("words3.txt");
            var xx = strArr.ToList();
            xx.Add("aaa");
            xx.Add("aaa");
            xx.Add("aaa");
            xx.Add("aaa");
            xx.Add("aaa");
            strArr = xx.ToArray();
            strArr.Show();
            //LSD.Sort(strArr, 3);
            //MSD.Sort(strArr);
            Quick3String.Sort(strArr);
            Console.WriteLine(strArr.IsSort());
            strArr.Show();
            Console.ReadKey();
        }
        void SPTest()
        {
            var strArr = FileHandler.ReadFileAsStrArr("tinyEWD.txt");
            var ewg = new EdgeWeightedDigraph(strArr);
            foreach (var e in ewg.Adj(0))
            {
                Console.WriteLine(e);
            }
            Console.WriteLine();
            foreach (var e in ewg)
            {
                Console.WriteLine(e);
            }
            Console.WriteLine();
            var sp = new DifkstraSP(ewg, 0);
            foreach (var e in sp)
            {
                Console.WriteLine(e);
            }
            Console.ReadKey();
        }
        void IndexMinPQTest()
        {
            var strArr = FileHandler.ReadFileAsStrArr("words3.txt");
            strArr.Show();
            var pq = new IndexMinPQ<string>(strArr.Length);
            for (int i = 0; i < strArr.Length; i++)
            {
                pq.Insert(i, strArr[i]);
            }
            while (!pq.IsEmpty())
            {
                Console.WriteLine(pq.DelMin());
            }
            Console.WriteLine();
            Console.ReadKey();
        }
        void ShortestPathTest()
        {
            var strArr = FileHandler.ReadFileAsStrArr("tinyEWG.txt");
            var ewg = new EdgeWeightedDigraph(strArr);
            foreach (var e in ewg.Adj(0))
            {
                Console.WriteLine(e);
            }
            Console.WriteLine();
            foreach (var e in ewg)
            {
                Console.WriteLine(e);
            }
            Console.ReadKey();
        }
        void MinimumSpanningTreesTest()
        {
            var strArr = FileHandler.ReadFileAsStrArr("tinyEWG.txt");
            var ewg = new EdgeWeightedGraph(strArr);
            foreach (var e in ewg.Adj(0))
            {
                Console.WriteLine(e);
            }
            Console.WriteLine();
            var lpm = new LazyPrimMST(ewg);
            foreach (var e in lpm.Edges())
            {
                Console.WriteLine(e);
            }
            Console.ReadKey();
        }
        void PriorityQueueTest()
        {
            var strArr = FileHandler.ReadFileAsStrArr("words3.txt");
            var qp = new MinPQ<string>(strArr.Length);
            foreach (var item in strArr)
            {
                qp.Insert(item);
            }
            while (!qp.IsEmpty())
            {
                Console.WriteLine(qp.DelMin());
            }
            Console.ReadKey();
        }
        void DigraphTest()
        {
            //var strArr = FileHandler.ReadFileAsStrArr("tinyG.txt");
            //var strArr = FileHandler.ReadFileAsStrArr("tinyDG.txt");
            var strArr = FileHandler.ReadFileAsStrArr("tinyDAG.txt");
            var intArr = Array.ConvertAll(strArr, s => int.Parse(s));
            var dg = new Digraph(intArr);
            //var dgr = dg.Reverse();
            var dc = new DirectedCycle(dg);
            if (dc.HasCycle())
            {
                foreach (var v in dc.Cycle())
                {
                    Console.WriteLine(v);
                }
            }
            Console.ReadKey();
        }
        void GraphTest()
        {
            var strArr = FileHandler.ReadFileAsStrArr("tinyG.txt");
            var intArr = Array.ConvertAll(strArr, s => int.Parse(s));
            var g = new Graph(intArr);
            foreach (var item in g.Adj(0))
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();
            var v = g.V;
            //var dfs = new DepthFirstSearch(g, 0);
            //var dfp = new DepthFirstPaths(g, 0);
            var bfp = new BreadthFirstPath(g, 0);
            foreach (var item in bfp.PathTo(5))
            {
                Console.WriteLine(item);
            }
            Console.ReadKey();
        }

        void STTest()
        {
            var strArr = FileHandler.ReadFileAsStrArr("words3.txt");
            strArr.Show();
            //var st = new SequentialSearchST<string,int>();
            //var st = new BinarySearchST<string,int>(strArr.Length);
            //var st = new BST<string,int>();
            //var st = new RedBlackBST<string,int>();
            //var st = new SeparateChainingHash<string,int>();
            //var st = new SeparateChainingHashST<string,int>(10);
            //var st = new LinearProbingHashST<string,int>();
            var st = new LinearProbingHashST<int, string>();
            for (int i = 1; i < strArr.Length; i++)
            {
                //st.Put(strArr[i], i);
                st.Put(i, strArr[i]);
            }
            //st.Put("bad", 100);
            //Console.WriteLine(st.Get("aaa"));
            //Console.WriteLine(st.Get("bed"));
            //Console.WriteLine(st.Get("zoo"));
            //Console.WriteLine(st.Get("xxx"));
            //Console.WriteLine(st.Get("bad"));
            //Console.WriteLine(st.Get("yet"));
            //Console.WriteLine(st.Get("zzz"));
            #region int -> string
            st.Put(1, "111");
            Console.WriteLine(st.Get(0));
            Console.WriteLine(st.Get(1));
            Console.WriteLine(st.Get(10));
            Console.WriteLine(st.Get(34));
            Console.WriteLine(st.Get(35));
            Console.WriteLine(st.Get(100));
            #endregion
            #region Floor
            //Console.WriteLine();
            //Console.WriteLine(st.Floor("aaa"));
            //Console.WriteLine(st.Floor("bed"));
            //Console.WriteLine(st.Floor("zoo"));
            //Console.WriteLine(st.Floor("xxx"));
            //Console.WriteLine(st.Floor("bad"));
            //Console.WriteLine(st.Floor("baf"));
            //Console.WriteLine(st.Floor("yet"));
            //Console.WriteLine(st.Floor("zzz"));
            #endregion
            Console.ReadKey();
        }
        void StackTest()
        {
            var strArr = FileHandler.ReadFileAsStrArr("words3.txt");
            strArr.Show();
            var stack = new ResizingArrayStack<string>();
            //var stack = new NodeStack<string>();
            foreach (var item in strArr)
            {
                stack.Push(item);
            }
            foreach (var item in stack)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
            while (!stack.IsEmpty())
            {
                Console.Write(stack.Pop() + " ");
            }
            Console.ReadKey();
        }
        void QueueTest()
        {
            var strArr = FileHandler.ReadFileAsStrArr("words3.txt");
            strArr.Show();
            var queue = new NodeQueue<string>();
            foreach (var item in strArr)
            {
                queue.Enqueue(item);
            }
            foreach (var item in queue)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
            while (!queue.IsEmpty())
            {
                Console.Write(queue.Dequeue() + " ");
            }
            Console.ReadKey();
        }
        void SortTest()
        {
            var strArr = FileHandler.ReadFileAsStrArr("words3.txt");
            strArr.Show();
            //SelectionSort.Sort(strArr);
            //InsertionSort.Sort(strArr);
            //ShellSort.Sort(strArr);
            //MergeSort<string>.Sort(strArr);
            //MergeSort<string>.SortBU(strArr);
            //QuickSort<string>.Sort(strArr);
            QuickSort<string>.Sort3Way(strArr);
            Console.WriteLine(strArr.IsSort());
            strArr.Show();
            Console.ReadKey();
        }

    }
}
