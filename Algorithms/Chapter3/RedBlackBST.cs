using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Chapter3
{
    public class RedBlackBST<K, V> where K : IComparable<K>
    {
        private const bool Red = true;
        private const bool Black = false;
        private Node _root;

        private class Node
        {
            public K Key { get; set; }
            public V Val { get; set; }
            public int N { get; set; }
            public bool Color { get; set; }
            public Node Left { get; set; }
            public Node Right { get; set; }
            public Node(K key, V val, int n, bool color)
            {
                this.Key = key;
                this.Val = val;
                this.N = n;
                this.Color = color;
            }
        }
        #region 从BST搬过来的方法（二叉查找树通用）
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
            if (cmp < 0) return Get(node.Left, key);
            else if (cmp > 0) return Get(node.Right, key);
            else return node.Val;
        }
        #endregion
        private bool IsRed(Node node)
        {
            if (node == null) return false;
            return node.Color == Red;
        }
        private Node RotateLeft(Node node)
        {
            var r = node.Right;
            node.Right = r.Left;
            r.Left = node;
            r.Color = node.Color;
            //r.Left
            node.Color = Red;
            r.N = node.N;
            node.N = Size(node.Left) + Size(node.Right) + 1;
            return r;
        }
        private Node RotateRight(Node node)
        {
            var l = node.Left;
            node.Left = l.Right;
            l.Right = node;
            l.Color = node.Color;
            node.Color = Red;
            l.N = node.N;
            node.N = Size(node.Left) + Size(node.Right) + 1;
            return l;
        }
        private void FlipColor(Node node)
        {
            node.Color = Red;
            node.Left.Color = Black;
            node.Right.Color = Black;
        }
        public void Put(K key, V val)
        {
            _root = Put(_root, key, val);
            _root.Color = Black;
        }
        private Node Put(Node node, K key, V val)
        {
            if (node == null) return new Node(key, val, 1, Red);
            int cmp = key.CompareTo(node.Key);
            if (cmp < 0)
                node.Left = Put(node.Left, key, val);
            else if (cmp > 0)
                node.Right = Put(node.Right, key, val);
            else node.Val = val;

            //balance
            if(IsRed(node.Right) && !IsRed(node.Left))
                node = RotateLeft(node);
            if (IsRed(node.Left) && IsRed(node.Left.Left))
                node = RotateRight(node);
            if (IsRed(node.Left) && IsRed(node.Right))
                FlipColor(node);

            node.N = Size(node.Left) + Size(node.Right) + 1;
            return node;
        }
    }
}
