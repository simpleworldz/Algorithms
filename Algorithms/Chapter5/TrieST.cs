using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Chapter5
{
    public class TrieST<V>
    {
        private static int _r = 256;
        //private Node _root = new Node();
        private Node _root;

        private class Node
        {
            public V Val { get; set; }
            public Node[] Next = new Node[_r];
        }

        public V Get(string key)
        {
            var node = Get(_root, key, 0);
            if (node == null)
            {
                return default(V);//只能用这个了
            }
            return node.Val;
        }

        private Node Get(Node node, string key, int d)
        {
            if (node == null)
            {
                return null;
            }
            if (d == key.Length)
            {
                return node;
            }
            return Get(node.Next[key[d]], key, d + 1);
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
            }
            if (d == key.Length)
            {
                node.Val = val;
                return node;
            }
            //[!]node = Put(node.Next[key[d]], key, val, d + 1);
            node.Next[key[d]] = Put(node.Next[key[d]], key, val, d + 1);
            return node;
        }
        #region 我的实现，非递归形式，貌似也行。但得先给_root赋值。private Node _root = new Node()
        public V GetMy(string key)
        {
            return GetMy(_root, key);
        }

        private V GetMy(Node node, string key)
        {
            for (int i = 0; i < key.Length; i++)
            {
                node = node.Next[key[i]];
                if (node == null)
                {
                    return default(V);//这能用这个了
                }
            }
            return node.Val;
        }
        public void PutMy(string key, V val)
        {
            PutMy(_root, key, val);
        }

        private void PutMy(Node node, string key, V val)
        {
            for (int i = 0; i < key.Length; i++)
            {
                if (node.Next[key[i]] == null)
                {
                    node.Next[key[i]] = new Node();
                }
                node = node.Next[key[i]];
            }
            node.Val = val;
        }
        #endregion
    }
}
