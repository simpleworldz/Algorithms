using System;

namespace Algorithms.Chapter3
{
    public class BST<K, V> where K : IComparable<K>
    {
        private Node _root;
        private class Node
        {
            public K Key { get; set; }
            public V Val { get; set; }
            public Node Left { get; set; }
            public Node Right { get; set; }
            /// <summary>
            /// 以该节点为根的子树中的节点总数（包括它自己）
            /// </summary>
            public int N { get; set; }
            public Node(K key, V val, int n)
            {
                this.Key = key;
                this.Val = val;
                this.N = n;
            }
        }
        public int Size()
        {
            return Size(_root);
        }
        private int Size(Node node)
        {
            if (node == null) return 0;
            return node.N;
        }

        public V Get(K key)
        {
            return Get(_root, key);
        }
        private V Get(Node node, K key)
        {
            if (node == null) return default(V);//虽然用default(V)不是很好
            int cmp = key.CompareTo(node.Key);
            if (cmp < 0) return Get(node.Left, key); //以后统一下，小于0
            else if (cmp > 0) return Get(node.Right, key);
            else return node.Val;
        }

        public void Put(K key, V val)
        {
            _root = Put(_root, key, val);
        }

        private Node Put(Node node, K key, V val)
        {
            if (node == null) return new Node(key, val, 1);
            int cmp = key.CompareTo(node.Key);
            if (cmp < 0)
                node.Left = Put(node.Left, key, val);
            else if (cmp > 0)
                node.Right = Put(node.Right, key, val);
            else
                node.Val = val;
            node.N = Size(node.Left) + Size(node.Right) + 1;
            return node;
        }
        /// <summary>
        /// 找出小于参数key的最大键
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public K Floor(K key)
        {
            Node node = Floor(_root, key);
            if (node == null) return default(K);
            return node.Key;
        }

        private Node Floor(Node node, K key)
        {
            if (node == null) return null;
            int cmp = key.CompareTo(node.Key);
            if (cmp < 0) return Floor(node.Left, key);
            else if (cmp == 0) return node;
            //cmp > 0
            var t = Floor(node.Right, key);
            if (t == null) return node;
            else return t;
        }
        #region 我的实现
        public void PutMy(K key, V val)
        {
            if (_root == null)
            {
                _root = new Node(key, val, 1);
                return;
            }
            PutMy(_root, key, val);
        }

        private void PutMy(Node node, K key, V val)
        {
            int cmp = key.CompareTo(node.Key);

            if (cmp < 0)
            {
                if (node.Left != null)
                {
                    PutMy(node.Left, key, val);
                }
                else
                {
                    node.Left = new Node(key, val, 1);
                }
            }
            else if (cmp > 0)
            {
                if (node.Right != null)
                {
                    PutMy(node.Right, key, val);
                }
                else
                {
                    node.Right = new Node(key, val, 1);
                }
            }
            else
            {
                node.Val = val;
            }
            node.N = node.Left?.N ?? 0 + node.Right?.N ?? 0 + 1;
        }
        #endregion
    }
}
