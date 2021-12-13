using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Chapter1
{
    /// <summary>
    /// 下压堆栈 链表实现
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class NodeStack<T> : IEnumerable<T>
    {
        private Node first;
        private int N;
        private class Node
        {
            public T Item { get; set; }
            public Node Next { get; set; }
        }

        public bool IsEmpty()
        {
            return N == 0;
        }
        /// <summary>
        /// 可以用属性替代
        /// </summary>
        /// <returns></returns>
        public int Size()
        {
            return N;
        }
        public void Push(T item)
        {
            var oldFirst = first;
            first = new Node();
            first.Item = item;
            first.Next = oldFirst;
            #region 可算法四中的有点不同，但差不多的。
            //var newNode = new Node();
            //newNode.Item = item;
            //newNode.Next = first;
            //first = newNode;
            #endregion
            N++;
        }
        public T Pop()
        {
            var item = first.Item;
            first = first.Next;
            N--;
            return item;
        }
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
