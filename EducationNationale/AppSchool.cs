using EducationNationale.Business;
using EducationNationale.View;

namespace EducationNationale
{
    public class AppSchool
    {
        private readonly ServiceApp _serviceApp;
        public AppSchool(ServiceApp serviceApp){
            _serviceApp = serviceApp;
        }
        public void RunProgram()
        {

            UserInterface userInterface = new UserInterface();
            UserEntry userEntry = new UserEntry();
            Console.Clear();

            while (true)
            {
                int menuChoice;
                userInterface.DisplayMainMenu();
                menuChoice = userEntry.GetMenuChoice();

                // Menu student
                if (menuChoice == 1)
                {
                    while (true)
                    {
                        userInterface.DisplayMenuStudents();
                        menuChoice = userEntry.GetMenuChoice();

                        // Back to main menu
                        if (menuChoice == 0) break; 
                        // List of students
                        else if (menuChoice == 1)
                        {
                            userInterface.DisplayStudents();
                            _serviceApp.DisplayStudents();
                        }
                        // Add new student
                        else if (menuChoice == 2)
                        {
                            // Create New Student method
                        }
                        // Find a student
                        else if (menuChoice == 3)
                        {
                            Console.WriteLine("Find a student");
                        }
                        // Add a grade and an assessment to a student
                        else if (menuChoice == 4)
                        {
                            Console.WriteLine("Add a grade and an assessment to a student");
                        }
                        // Other cases
                        else
                        {
                            userInterface.DisplayInvalidNumber();
                        }

                        //Quand tu sors du If/Else If on recommence la boucle While
                    }
                }

                // Menu course
                else if (menuChoice == 2)
                {
                    while (true)
                    {
                        userInterface.DisplayCourseMenu();
                        menuChoice = userEntry.GetMenuChoice();

                        if (menuChoice == 0) break;

                        // List of courses
                        else if (menuChoice == 1)
                        {
                            Console.WriteLine("----------------------------------------------------------------------");
                            Console.WriteLine("\nLIST OF COURSES \n");
                            _serviceApp.DisplayAllCourses();



                            userInterface.DisplayBackToMainMenu();
                            menuChoice = userEntry.GetBackToMainMenu();
                            if (menuChoice == 0) break;
                        }

                        // Find course by id
                        else if (menuChoice == 2)
                        {
                            userInterface.DisplayGetCourseById();
                            int id = userEntry.GetEnteredId();
                            Course courseToFind = _serviceApp.FindCourseById(id); // calls the method FindCourseById
                            Console.WriteLine($"Code course : {courseToFind.Id}    Course : {courseToFind.Name}\n");

                            menuChoice = userEntry.GetBackToMainMenu();
                            if (menuChoice == 0) break;
                        }

                        // Create new course
                        else if (menuChoice == 3)
                        {
                            Course newCourse = _serviceApp.GetCourseToCreate();
                            _serviceApp.CreateCourse(newCourse);

                            if (userEntry.GetBackToMainMenu() == 0) break;
                        }

                        // Exclude a course by id
                        else if (menuChoice == 4)
                        {
                            userInterface.DisplayRemoveCourseById();
                            int id = userEntry.GetEnteredId();
                            _serviceApp.DeleteCourse(id);

                            menuChoice = userEntry.GetBackToMainMenu();
                            if (menuChoice == 0) break;
                        }
                        else
                        {
                            userInterface.DisplayInvalidNumber();
                        }
                    }
                }
                else
                {
                    userInterface.DisplayInvalidNumber();
                }

            }
        }
    }
}