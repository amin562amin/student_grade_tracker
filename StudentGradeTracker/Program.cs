using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace StudentGradeTracker
{
    internal class Program
    {
        static string fileName = "students.csv"; // File to store students data 
        static void Main(string[] args)
        {
            // Create a list to store all student objects 
            List<Student> students = new List<Student>();

            //Load student data file
            if (File.Exists(fileName))
            {
                LoadStudents(students);
            }

           

           // Start the main menu loop
            DisplayMenu(students);      
        }

        /// <summary>
        /// Displays the main menu and handles user input.
        /// Loops until the user chooses to exit.
        /// </summary>
        /// 
        /// <param name="students">The list of students to manage</param >
       


        static void DisplayMenu (List<Student> students)
        {
            
            bool running = true;
            while (running)
            {
                // Show menu options 
                Console.WriteLine("1. Add Student");
                Console.WriteLine("2. View all students");
                Console.WriteLine("3. Exit");
                Console.WriteLine("Please choose an option by entering a number");

                // Read user input aand safely parse to integer 
                string input = Console.ReadLine();
                int response;


                if (!int.TryParse(input, out response))
                {
                    // Input was not a valid number
                    Console.WriteLine("Invalid input.Press Enter to try again.");
                    Console.ReadLine();
                    continue; // Go back to the top of the loop 
                }

                // Handle menu choices 
                if (response == 1)
                {
                    AddStudent(students);
                }
                else if (response == 2)
                {
                    ViewStudents(students);

                }
                else if (response == 3)
                {
                    SaveStudents(students);
                    running = false; // Exit the loop, program will end 
                }
                else
                {
                    Console.WriteLine("Im sorry but you didnt enter a valid input please try again");
                    Console.ReadLine();
                }
            }
        }

        /// <summary>
        /// Prompts the user to enter student details and adds a new Student object to the list.
        /// </summary>
        /// <param name="students">The list of students to add to</param>
        


        static void AddStudent(List<Student> students)
        {
            // Prompt user for student details 
            Console.WriteLine("Please enter the name of the student");
            string student_name = Console.ReadLine();

            Console.WriteLine("Please enter the age of the student");
            int student_age;

            // Validate age input to avoid crashes
            while (!int.TryParse(Console.ReadLine(), out student_age))
            {
                Console.WriteLine("Invalid input. Please enter a number for age:");
            }

            Console.WriteLine("Please enter the grade of the student");
            string student_grade = Console.ReadLine();

            // Create a new Student object 

            Student a = new Student(student_name,student_age,student_grade);

            // Display the newly added student's details 

            Console.WriteLine($"The students details are: \n {a.GetName()} \n " +
                   $"{a.GetAge()}\n {a.GetGrade()}");

            // add the student to the list 
            students.Add (a);
        }

        /// <summary>
        /// Displays all students currently in the list.
        /// Pauses at the end so the user can read before returning to the menu.
        /// </summary>
        /// <param name="students">The list of students to display</param>


        static void ViewStudents(List<Student> students)
        {

            // Handle case where no students have been added
            if (students.Count == 0)
            {
                Console.WriteLine("No students have been added yet.");
                return;
            }

            // Loop through each student and display details  

            for (int i = 0; i < students.Count; i++)
            {

                
                    Console.WriteLine($"Student #{i + 1} details:");
                    Console.WriteLine($"Name: {students[i].GetName()}");
                    Console.WriteLine($"Age: {students[i].GetAge()}");
                    Console.WriteLine($"Grade: {students[i].GetGrade()}\n");
                

            }

            // Pause so the user can read the output before returning to menu 

            Console.WriteLine("Press Enter to return to the menu.");
            Console.ReadLine(); // just waits for the user, then goes back to the menu loop

        }

        /// <summary>
        /// Load the contents of the file containing student data into the program
        /// Formats the students data
        /// Stores the Formatted data into the student list to be used in the program
        /// </summary>
        /// <param name="students"></param>

        static void LoadStudents(List<Student> students)
        {
            string[] fileLines = File.ReadAllLines(fileName);
            string name,grade;
            int age;

            
                for (int i = 1; i < fileLines.Length; i++)
                {
                    string[] LinePart = fileLines[i].Split(',');

                    if (LinePart.Length == 3)
                    {
                        name = LinePart[0];
                        grade = LinePart[2];
                        if (int.TryParse(LinePart[1], out age))
                        {
                            students.Add(new Student(name, age, grade));
                        }
                    }
                }
            }
        

        /// <summary>
        /// Save the contents of the list containing student details to a file 
        /// </summary>
        /// <param name="students"></param>
        static void SaveStudents(List<Student> students)
        {
            List<string> format_Lines = new List<string>();
            string line;

            if (students.Count == 0)
            {
                Console.WriteLine("There are no students to save");
            }
            else
            {
                format_Lines.Add("Name,Age,Grade");

                foreach (Student student in students)
                {
                  
                    line = $"{student.GetName()},{student.GetAge()},{student.GetGrade()}";
                    format_Lines.Add (line);

                }
                File.WriteAllLines(fileName, format_Lines);
            }

        }

    }
}
