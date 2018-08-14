using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sort
{
    public class StudentComparer : IComparer<Student>
    {
        public int Compare(Student x, Student y)
        { 
            //x.EnglishScore.CompareTo
            //还不如简写
            if (x.ChineseScore > y.ChineseScore)
            {
                return 1;
            }
            else if (x.ChineseScore< y.ChineseScore)
            {
                return -1;
            }
            else
            {
                if (x.EnglishScore<y.EnglishScore)
                {
                    return -1;
                }
                else if(x.EnglishScore > y.EnglishScore)
                {
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
            
        }
    }
}
