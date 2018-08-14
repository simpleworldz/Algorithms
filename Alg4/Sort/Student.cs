using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sort
{
    public class Student : IComparable<Student>,IComparable
    { public Student(string firstName, string lastName, int chineseScore, int englishScore )
            {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.ChineseScore = chineseScore;
            this.EnglishScore = englishScore;
        }
        public string FirstName;
        public string LastName;
        public int ChineseScore;
        public int EnglishScore;

        public int CompareTo(Student other)
        {
            if (other == null) throw new ArgumentNullException("other");
            //也可以不用CompareTo
            int result = this.ChineseScore.CompareTo(other.ChineseScore);
            if (result == 0)
            {
                result = this.EnglishScore.CompareTo(other.EnglishScore);
            }
            return result;
        }

        public int CompareTo(object obj)
        {
            Student other = obj as Student;
            if (other == null) throw new ArgumentNullException("other");
            //也可以不用CompareTo
            int result = this.ChineseScore.CompareTo(other.ChineseScore);
            if (result == 0)
            {
                result = this.EnglishScore.CompareTo(other.EnglishScore);
            }
            return result;
        }
    }
}
