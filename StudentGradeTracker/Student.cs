using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentGradeTracker
{
    internal class Student 
    {
        private string name;
        private int age;
        private string grade;


        public  Student(string name1, int age1, string grade1)
        {
            name = name1;
            age = age1;
            grade = grade1;
        }
    }
}
