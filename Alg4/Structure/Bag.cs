using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Structure
{
    public class Bag<Item>:IEnumerable<Item> 
    {
      public  Node first;
        //string str;

        //public string Str { get => str; set => str = value; }

        public class Node
        {
          public  Item item;
           public Node next;            
        }
        public void Add(Item item)
        {    //错了
            //Node x = first;
            //while (x.next != null)
            //{
            //    x = x.next;
            //}
            //x.next = new Node();
            Node oldFirst = first;
            first = new Node();
            first.item = item;
            first.next = oldFirst;
        }
        public IEnumerator<Item> GetEnumerator()
        {
            return new MyEnumerator<Item>(this);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

    }
   
}
