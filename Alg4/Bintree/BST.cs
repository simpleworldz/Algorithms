using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bintree
{
    public class BST<Key, Value> where Key : IComparable<Key>
    { //本该是都是private的 但为了方便
       public Node root;
        //类用private ,则对象也必须为private
        public class Node
        { //【2】用private 因为有构造函数 不能用private因为不然x就不能访问属性了
            //可是书本上用的是private 难道是因为java？
            public Key key;
            public Value val;
            public int N;
            public Node left, right;
            public Node(Key key, Value val, int N)
            {
                this.key = key;
                this.val = val;
                this.N = N;
            }
        }
        public int Size()
        {
            return Size(root);
        }

        private int Size(Node x)
        {
            if (x == null) return 0;
            return x.N;
        }
        public void Print()
        {
            Print(root);
        }
        /// <summary>
        /// 按照Key 从小到大输出
        /// </summary>
        /// <param name="x"></param>
        private void Print(Node x)
        { 
            if (x == null) return;
            Print(x.left);
            Console.WriteLine("Key: {0,-20}\tValue:{1}", x.key, x.val);
            Print(x.right);
        }

        //public Value Get(Key key)
        //public void Put(Key key, Value val)
        //Max() Min() Ceiling() Floor() 
        //Select() Rank()
        //Delect() DelMin() DelMax()
        //Keys()

        #region Get() Put()
        //之所以有两个，一位有一个是默认的，在没有给节点的情况下，默认是输出根节点的
        //貌似这个有点说不通，但是其他的是这样的。
        public Value Get(Key key)
        {
            return Get(root, key);
        }
        //这个Key并不是root的Key是你要找的
        private Value Get(Node x, Key key)
        {
            if (x == null) return default(Value);
            if (key.CompareTo(x.key) < 0)
            {
                return Get(x.left, key);
            }
            else if (key.CompareTo(x.key) > 0)
            {
                return Get(x.right, key);
            }
            else
            {
                return x.val;
            }
            //不用这样   有个一个严密的逻辑 （我真是有多此一举了）
            //else if(key.CompareTo(x.key) == 0)
            //{
            //    return x.val;
            // }
            //else
            //{
            //    return null;
            //}
        }
        
        public void Put(Key key, Value val)
        {//注意了 更新要赋值 要改N
         root =   Put(root, key, val);
        }
        //【1】为什么要return Node呢？
        //可能是因为没有return 的话，它会一直执行下去
        //也就是是说，貌似这样成为了尾递归
        //不对 这个是x.left 而不是return
        private Node Put(Node x, Key key, Value val)
        {
            if (x == null)
            {
             return   new Node(key, val, 1);
            }
            if (key.CompareTo(x.key) < 0)
            {//**2 over and over again  StackOverflowException
             // x.left= Put(x, key, val);
                x.left = Put(x.left, key, val);
            }
            else if (key.CompareTo(x.key) > 0)
            {
                //x.right =  Put(x, key, val);
                x.right = Put(x.right, key, val);
            }
            else 
            {
                x.val = val;
            }
            x.N = Size(x.left) + Size(x.right) + 1;
            return x;
        }
        #endregion
        #region Max() Min() Ceiling() Floor() 
        //这个我得实现 
        public Key Min()
        {
            return Min(root).key ;
        }

        //返回Node是为了后面有用 找到最小的Node 感觉更好

        private Node Min(Node x)
        {
            if (x.left != null)
            {
                return Min(x.left);
            }
            return x;
        }
        //这个书本上的实现
        public Key Max()
        {
            return Max(root).key;
        }

        private Node Max(Node x)
        {
            if (x.right == null)
            {
                return x;
            }
            return Max(x.right);
        }
        
        public Key Floor(Key key)
        {
            Node x =  Floor(root, key);
            if (x == null) return default(Key);
            return x.key;
        }

        private Node Floor(Node x, Key key)
        {
            int cmp = key.CompareTo(x.key);
            if (cmp == 0)
            {
                return x;
            }
            else if (cmp < 0)
            {
                return Floor(x.left, key);
            }
            Node t = Floor(x.right, key);
            if (t==null)
            {
                return x;
            }
            else
            {
                return t;
            }
        }

        #endregion
        //Select() Rank()
        #region Delect() DelMin()  — DelMax()
        public void DelMin()
        {
         root =    DelMin(root);
        }

        private Node DelMin(Node x)
        {
            if (x.left ==null)
            {
                return x.right;
            }
            x = DelMin(x);
            //更新节点时别忘了更新 N;
            x.N = Size(x.right) + Size(x.left) + 1;
            return x;
        }
        public void Delect(Key key)
        {  //更新 要赋值回去，查找不用
            root = Delect(root, key);
        }

        private Node Delect(Node x, Key key)
        {   //本来就有默认值为null
            if (x == null) return null;
            int cmp = key.CompareTo(x.key);
            if (cmp< 0)
            {    //复杂了
                //if (x.left ==null)
                //{
                //    return x;
                //}
                x = Delect(x.left, key);
            }
            else if(cmp> 0)
            {
                //if (x.right == null)
                //{
                //    return x;
                //}
                x = Delect(x.right, key);
            }
            else
            {
                if (x.right ==null)
                {
                    return x.left;
                }
                if (x.left == null)
                {
                    return x.right;
                }
                //有问题  P260 的图一目了然 其实思路上就感觉结果莫名奇妙
                //Node l = Max(x.left);
                //x = Min(x.right);
                //x.left = l;
                Node t = x;
                x = Min(t.right);
                x.right = DelMin(t.right);
                x.left = t.left;
            }
            x.N = Size(x.left) + Size(x.right) + 1;
            //**1 很关键
            return x;
            
        }
        #endregion
    //Keys()

    }
}
