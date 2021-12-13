using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Chapter3
{
    public class SequentialSearchST<K,V>
    {
        private Node _first;

        private class Node
        {
            public K Key { get; set; }
            public V Val { get; set; }
            public Node Next { get; set; }
            public Node(K key,V val, Node next)
            {
                this.Key = key;
                this.Val = val;
                this.Next = next;
            }
        }
        public void Put(K key, V val)
        {
            //[@]
            for (Node node = _first; node != null ; node = node.Next)
            {
                //[!]
                if (key.Equals(node.Key))
                {
                    node.Val = val;
                    return;
                }
            }
            //[@]
            _first = new Node(key, val, _first);
        }
        public V Get(K key)
        {
            for (Node node = _first; node != null ; node = node.Next)
            {
                if (key.Equals(node.Key))
                {
                    return node.Val;
                }
            }
            return default(V);// 如果是int的话，default为0，就不是很好了。
        }
    }
}
