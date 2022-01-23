using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Chapter5
{
    public class TST<V>
    {
        private Node _root;
        private class Node
        {
            public char C { get; set; }
            public Node Left { get; set; }
            public Node Mid { get; set; }
            public Node Right { get; set; }
            public V Val { get; set; }
        }

        public V Get(string key)
        {
            var node = Get(_root, key, 0);
            if (node == null)
            {
                return default(V);
            }
            return node.Val;
        }

        private Node Get(Node node, string key, int d)
        {
            if (node == null)
            {
                return null;
            }
            //由于是字符串，可以直接用 > < = 
            int cmp = node.C.CompareTo(key[d]);
            if (cmp < 0)
            {
                return Get(node.Right, key, d);
            }
            else if (cmp > 0)
            {
                return Get(node.Left, key, d);
            }

            if (d == key.Length - 1)
            {
                return node;
            }
            else
            {
                return Get(node.Mid, key, d + 1);
            }
        }

        public void Put(string key, V val)
        {
            _root = Put(_root, key, val, 0);
        }

        private Node Put(Node node, string key, V val, int d)
        {
            if (node == null)
            {
                node = new Node();
                node.C = key[d];
            }
            if (d == key.Length - 1)
            {
                node.Val = val;
                return node;
            }
            int cmp = node.C.CompareTo(key[d]);
            if (cmp < 0)
            {
                node.Right = Put(node.Right, key, val, d);
            }
            else if (cmp > 0)
            {
                node.Left = Put(node.Left, key, val, d);
            }
            else
            {
                node.Mid = Put(node.Mid, key, val, d + 1);
            }
            return node;
        }
    }

}
