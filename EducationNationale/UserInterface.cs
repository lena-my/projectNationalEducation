using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EducationNationale
{
    public class UserInterface
    {
        private App _app;

        public UserInterface(App app){
            _app = app;
        }

        public UserInterface() {}

        public int ChooseMenu()
        {
            int.TryParse(Console.ReadLine(), out int menuChoice);
            return menuChoice;
        }
        public void DisplayMainMenu()
        {
            Console.WriteLine("MAIN MENU");
            Console.WriteLine("Choose an option:");
            Console.WriteLine("1 - Student");
            Console.WriteLine("2 - Course");
        }

        public void DisplayMenuStudents()
        {
            Console.WriteLine("MENU STUDENT");
            Console.WriteLine("Choose an option:");
            Console.WriteLine("0 - Back to the main menu");
            Console.WriteLine("1 - List of students");
            Console.WriteLine("2 - Add a new student");
            Console.WriteLine("3 - Find a student");
            Console.WriteLine("4 - Add a grade and an assessment to a student");
            // _app.DisplayStudent();
        }

        public void DisplayCourseMenu()
        {
            Console.WriteLine("MENU COURSE");
            Console.WriteLine("Choose an option:");
            Console.WriteLine("0 - Back to the main menu");
            Console.WriteLine("1 - List of courses");
            Console.WriteLine("2 - Find course by id");
            Console.WriteLine("3 - Add a new course");
            Console.WriteLine("4 - Exclude a course by id");
        }

        public int DisplayBackToMainMenu()
        {
            //Console.WriteLine("0 - Back to main menu");
            int.TryParse(Console.ReadLine(), out int MenuChoice);
                        
            return MenuChoice;
        }

        public void DisplayStudents()
        {
            Console.WriteLine("List of students");            
            
            Console.WriteLine("----------------------------------------------------------------------");
            Console.WriteLine("Student's information : \n");
            Console.WriteLine($"Name              : ");
            Console.WriteLine($"Surname           : ");
            Console.WriteLine($"Birthday : \n\n");
            Console.WriteLine($"Results :\n");
            Console.WriteLine($"   Course :");
            Console.WriteLine($"      Grade       :");
            Console.WriteLine($"      Observation : \n");
            Console.WriteLine($"      Average     :\n");
            Console.WriteLine("----------------------------------------------------------------------");
        }



    }
}