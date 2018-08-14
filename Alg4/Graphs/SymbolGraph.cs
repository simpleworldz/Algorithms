using Bintree;
using MyIO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphs
{
    //{2}未完成
  public  class SymbolGraph
    {
        BST<string, int> st;
        string[] keys;
        Graph g;
        public SymbolGraph(string fileName)
        {
            string[] strs = In.ReadEnWords(fileName);
            st.Put(strs[0], 0);
            //{1}先将就下 看看行不行
            //也可以先去重的，有好多办法
            keys = new string[strs.Length];
            keys[0] = strs[0];
            for (int i = 1; i < strs.Length; i++)
            {
                if (st.Get(strs[i])!= 0)
                { int key = st.Size();
                    st.Put(strs[i], key);
                    keys[key] = strs[i];
                }
            }
            //keys[0] = strs[0];
            //for (int i = 1; i < st.Size(); i++)
            //{
            //    keys[i] = st.;
            //}

            //keys = new string[st.Size()];
            //不能用strs 因为它可能有重复  先用上面的那个代替吧
            //{0}然而并没有实现Keys()这个功能
            //foreach (var item in st.Keys() )
            //{

            //}


        }
    }
}
