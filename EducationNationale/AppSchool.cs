using System.Numerics;
using EducationNationale.Business;
using EducationNationale.View;

namespace EducationNationale
{
    public class AppSchool
    {
        private readonly ServiceApp _serviceApp;
        public AppSchool(ServiceApp serviceApp)
        {
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
                            _serviceApp.DisplayStudents();
                        }
                        // Add new student
                        else if (menuChoice == 2)
                        {
                            Student student = _serviceApp.GetStudentToCreate();
                            _serviceApp.CreateStudent(student);
                        }
                        // Find a student by id
                        else if (menuChoice == 3)
                        {
                            userInterface.DisplayGetStudentById(); // displays text to get the student id
                            int idStudentToFind = userEntry.GetEnteredId(); // method to enter the student id
                            Student studentToFind = _serviceApp.FindStudentById(idStudentToFind); // defines student to find
                            if (studentToFind is null) continue;

                            _serviceApp.DisplayStudentById(studentToFind); // displays the student found

                            // Add a grade and an assessment to a student
                            userInterface.DisplayGetGrades();
                            menuChoice = userEntry.GetMenuChoice();

                            if (menuChoice == 0) break;
    
                            else if (menuChoice == 1)
                            {
                                Console.WriteLine("\nLIST OF COURSES \n");
                                _serviceApp.DisplayAllCourses();
                                Console.WriteLine("Enter the id of the course to add grades:");
                                int idCourseToFind = userEntry.GetEnteredId();
                                Course courseToFind = _serviceApp.FindCourseById(idCourseToFind); // calls the method FindCourseById

                                Console.WriteLine("Enter the grade:");
                                double gradeValue = (double)userEntry.GetEnteredValueGrade();
                                Console.WriteLine("Enter an observation:");
                                string? observation = userEntry.GetEnteredObservation();

                                Grade newGrade = new Grade(idCourseToFind, idStudentToFind, gradeValue, observation);

                                _serviceApp.AddGradeToStudent(studentToFind, newGrade);
                            }
                            else{
                                userInterface.DisplayInvalidNumber();
                            }
                        }
                        
                        // Other cases
                        else
                        {
                            userInterface.DisplayInvalidNumber();
                        }
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
                        }

                        // Find course by id
                        else if (menuChoice == 2)
                        {
                            userInterface.DisplayGetCourseById();
                            Course courseToFind = _serviceApp.FindCourseById(userEntry.GetEnteredId()); // calls the method FindCourseById
                            Console.WriteLine($"Code course : {courseToFind.Id}    Course : {courseToFind.Name}\n");
                        }

                        // Create new course
                        else if (menuChoice == 3)
                        {
                            Course newCourse = _serviceApp.GetCourseToCreate();
                            _serviceApp.CreateCourse(newCourse);
                        }

                        // Exclude a course by id
                        else if (menuChoice == 4)
                        {
                            userInterface.DisplayRemoveCourseById();
                            int id = userEntry.GetEnteredId();
                            _serviceApp.DeleteCourse(id);
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