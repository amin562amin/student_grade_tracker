using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentGradeTracker
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Student> students = new List<Student>();
            DisplayMenu();      
        }

        static void DisplayMenu ()
        {
            int response;
            Console.WriteLine("1. Add Student");
            Console.WriteLine("2. View all students");
            Console.WriteLine("3. Exit");
            Console.WriteLine("Please choose an option by entering a number");
            response = Convert.ToInt32(Console.ReadLine());

            if (response == 1)
            {

            }
            else if (response == 2)
            {


            }
            else if (response == 3)
            {

            }
            else
            {
                Console.WriteLine("Im sorry but you didnt enter a correct input please try again");
                Console.ReadLine();
                DisplayMenu();
            }
        }

        static void ViewStudent()
        {
            Console.WriteLine("Please enter the name of the student");
            string student_name = Console.ReadLine();
            Console.WriteLine("Please enter the age of the student");
            int student_age = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Please enter the grade of the student");
            string student_grade = Console.ReadLine();


            Student a = new Student(student_name,student_age,student_grade);
            Console.WriteLine("The details of the student you entered are {} ",a);

            students.Add (a);
        }

    }
}
