using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyIO;
namespace Sort
{
    class Program
    {
        static void Main(string[] args)
        {   //**一定得自己写一遍**
            //{2}先用已经实现了 comparable？的类型，后面再尝试字节写继承comparable的类
            #region string
            ////string[] a = {"adf","fadsf","fadsf","fdsa","dfa",
            ////    "fdsaf","fsdf","qw","wd","jl","dk","lcc" };
            //string[] a = In.ReadEnWord(@"E:\Code\Algorithm\Alg\war+peace.txt");
            //Console.WriteLine("数组长度为{0}", a.Length);
            #endregion
            #region int
            //int[] a1 = { 1, 2 };
            //object obj = a1;
            //IComparable[] a2 = obj;
            //IComparable[] a = { 1, 2, 23, 432, 1, 2, "4", 7 };
           // 这个可以
            //IComparable[] a2 = { 1, 2, 23, 432, 1, 2, 7 };
            #endregion
            #region Student
            Student[] a = new Student[] {new Student("huang","zhen",80,85),
             new Student("Mary", "Yang", 60, 77),
                new Student("Jane", "Pope",80,75),
                new Student("Jack", "Baker", 55, 70),
                new Student("Jane", "Chan", 61, 90)};
            //IComparable<Student>[] a1 = a; 
            //别忘了[]
            //IComparable[] a1 = a;
            #endregion
            QuickSort.Sort(a);

            //都好快 差不多快
            //Array.Sort(a);
            //if (SortTools.IsSorted(a))
            //{
            //    Console.WriteLine("排序成功！");
            //    SortTools.Show(a);
            //}
            //else
            //{
            //    Console.WriteLine("排序未成功！");
            //    SortTools.Show(a);
            //}
            foreach (var student in a)
            {
                Console.WriteLine(student.FirstName + " " + student.LastName + " English:" + student.EnglishScore + " Chinese:" + student.ChineseScore);

            }
                Console.ReadKey();
        }
    }
}
