using Algorithms.Chapter4;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Chapter1
{
    /// <summary>
    /// 先进先出队列 链表实现
    /// </summary>
    public class NodeQueue<T>:IEnumerable<T>
    {
        private Node first;
        private Node last;
        private int N;//当创建实例时，类的成员变量会自动赋默认值
        private class Node
        {
            public T Item { get; set; }
            public Node Next { get; set; }
        }
        public bool IsEmpty()
        {
            return N == 0;
        }
        public int Size()
        {
            return N;
        }
        public void Enqueue(T item)
        {
            var oldLast = last;
            last = new Node();
            last.Item = item;
            last.Next = null;
            if (IsEmpty())
            {
                first = last;
            }
            else
            {
                oldLast.Next = last;
            }
            N++;
        }
        public T Dequeue()
        {
            var item = first.Item;
            first = first.Next;
            N--;
            if (IsEmpty()) last = null;
            return item;
        }
        #region 我的实现
        public void EnqueueMy(T item)
        {
            if(first == null)
            {
                first = new Node();
                first.Item = item;
                //[!]这个时候last还是null呢
                //first.Next = last;
            }
            else if(last == null)
            {
                last = new Node();
                last.Item = item;
                first.Next = last;
            }
            else
            {
                var newLast = new Node();
                newLast.Item = item;
                last.Next = newLast;
                last = newLast;
            }
            N++;
        }

        public T DequeueMy()
        {
            //这边应该要有根据N == 0时的限制呢，还是使用的时候限制？//目前是使用的时候限制，用IsEmpty()
            var item = first.Item;
            first = first.Next;
            N--;
            if (N == 1) last = null;
            return item;
        }
        #endregion 
        public IEnumerator<T> GetEnumerator()
        {
            var current = first;
            while (current != null)
            {
                yield return current.Item;
                current = current.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

    }
}
