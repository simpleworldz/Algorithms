using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Structure
{
    //IEnumerator<Item> 不知怎么想的 改了好几回了，差点放弃
    public class MyEnumerator<Item> : IEnumerator<Item>
    {
        Bag<Item> bag;
        Bag<Item>.Node currentNode;
        bool bl = false;
        public MyEnumerator(Bag<Item> items)
        {
            if (items != null)
            {
            bag = items;
            }
            else
            {
                throw new Exception("bag cann't null");
            }
            //这里为null 会报错
           // currentNode = items.first;
        }


        //【1】为空的话 ，会报错吗
        // public Bag<Item>.Node Current { get => currentNode; }
        public Item Current { get => currentNode.item; }
        object IEnumerator.Current { get => Current; }
        public void Dispose()
        {
            
        }
        //应该会先执行MoveNext()
        public bool MoveNext()
        {
            if (bl)
            {
                currentNode = currentNode.next;
                 
            }
            else
            {
                currentNode = bag.first;
                bl = true;
            }
                return (currentNode != null);
        }

        public void Reset()
        {
            currentNode = bag.first;
        }
    }
}
