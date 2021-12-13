using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Chapter1
{
    /// <summary>
    /// 下压（LIFO）能够动态调整数组大小的实现
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ResizingArrayStack<T> : IEnumerable<T>
    {
        private T[] a = new T[1];
        private int N = 0;
        public bool IsEmpty()
        {
            return N == 0;
        }
        public int Size()
        {
            return N;
        }
        private void Resize(int newSize)
        {
            var temp = new T[newSize];
            for (int i = 0; i < N; i++)
            {
                temp[i] = a[i];
            }
            a = temp;
        }
        public void Push(T item)
        {
            if (N == a.Length) Resize(a.Length * 2);
            a[N++] = item;
        }
        public T Pop()
        {
            //if (IsEmpty()) return default(T);//??
            //[!]var p = a[N--];
            var item = a[--N];
            a[N] = default(T);
            //[!]if (N == a.Length / 2) Resize(N / 2);
            //[!]if (N > 0 && N == a.Length / 4) Resize(N / 2);
            if (N > 0 && N == a.Length / 4) Resize(a.Length / 2);
            return item;
        }
        public IEnumerator<T> GetEnumerator()
        {
            for (int i = N - 1; i >= 0; i--)
            {
                yield return a[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        #region 我的实现
        public void ResizeMy()
        {
            int newSize;
            var l = a.Length;
            if (N > l) newSize = l * 2;
            else if (N <= l / 2) newSize = l / 2;
            else return;
            var temp = a;
            a = new T[newSize];
            for (int i = 0; i < a.Length; i++)
            {
                a[i] = temp[i];
            }
            return;
        }
        public void PushMy(T t)
        {
            N++;
            ResizeMy();
            a[N] = t;
        }
        public T PopMy()
        {
            if (IsEmpty()) return default(T);//??
            //[!]var p = a[N--];
            var p = a[--N];
            a[N + 1] = default(T);
            ResizeMy();
            return p;
        }
        #endregion
    }
}
