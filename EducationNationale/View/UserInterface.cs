using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EducationNationale
{
    public class UserInterface
    {
        private ServiceApp _app;

        public UserInterface(ServiceApp app)
        {
            _app = app;
        }

        public UserInterface() { }


        public void DisplayMainMenu()
        {
            Console.WriteLine("MAIN MENU");
            Console.WriteLine("Choose an option:");
            Console.WriteLine("1 - Student");
            Console.WriteLine("2 - Course");
        }

        public void DisplayMenuStudents()
        {
            Console.WriteLine("MENU STUDENT\n");
            Console.WriteLine("Choose an option:\n");
            Console.WriteLine("0 - Back to the main menu");
            Console.WriteLine("1 - List of students");
            Console.WriteLine("2 - Add a new student");
            Console.WriteLine("3 - Find a student");
        }

        public void DisplayCourseMenu()
        {
            Console.WriteLine("MENU COURSE\n");
            Console.WriteLine("Choose an option:\n");
            Console.WriteLine("0 - Back to the main menu");
            Console.WriteLine("1 - List of courses");
            Console.WriteLine("2 - Find course by id");
            Console.WriteLine("3 - Add a new course");
            Console.WriteLine("4 - Exclude a course by id");
        }

        public void DisplayInvalidNumber()
        {
            Console.WriteLine("Invalid number. Try again.");
        }

        public void DisplayRemoveCourseById()
        {
            Console.WriteLine("Remove a course by id");
            Console.WriteLine("Enter the id of the course to remove:");
        }

        public void DisplayGetCourseById()
        {
            Console.WriteLine("----------------------------------------------------------------------");
            Console.WriteLine("Find course by id");
            Console.WriteLine("Enter the id of the course to find:");
        }

        public void DisplayBackToMainMenu()
        {
            Console.WriteLine("\n0 - Back to the main menu");
        }

        public void DisplayGetStudentById()
        {
            Console.WriteLine("----------------------------------------------------------------------");
            Console.WriteLine("Find student by id");
            Console.WriteLine("Enter the id of the student to find:");
        }

        public void DisplayGetGrades()
        {
            Console.WriteLine("Add a grade and an assessment to the student");
            Console.WriteLine("0 - Back to previous menu");
            Console.WriteLine("1 - Add grades");
        }

    }
}