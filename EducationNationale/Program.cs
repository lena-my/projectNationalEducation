using System.Net.Mail;
using EducationNationale;
using EducationNationale.Business;
using EducationNationale.View;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

public class Program
{
    public static void Main()
    {
        DataApp? dataApp = FileHandler.Deserialize(); // Converts the data.json to
        if(dataApp is null){
            dataApp = new DataApp(new List<Course> (){}, new List<Student> (){});
        }
        // dataApp.Students.AddRange(new List<Student>{
        //     new Student(1,"","BOBO",new DateTime(2010,10,10)),
        //     new Student(2,"Helena","Miura",new DateTime(2000,10,10)),
        // });

        // dataApp.Courses.AddRange(new List<Course>{
        //     new Course("Math",1),
        //     new Course("Hist",2)
        // });

        ServiceStudent serviceStudent = new ServiceStudent(dataApp.Students);
        ServiceCourse serviceCourse = new ServiceCourse(dataApp.Courses);

        App app = new App(serviceStudent, serviceCourse );

        UserInterface userInterface = new UserInterface();
        UserEntry userEntry = new UserEntry();



        //serviceCourse.GetAllCourses();
        // serviceCampus.Courses = courses;
        // serviceCampus.Students = students;

        // serviceCourse.CreateCourse();

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
                    if (menuChoice == 0) break; // Back to main menu

                    // List of students
                    else if (menuChoice == 1)
                    {
                        userInterface.DisplayStudents();
                        app.DisplayStudents();
                        menuChoice = userEntry.GetBackToMainMenu();
                        if (menuChoice == 0) break;
                    }

                    // Add new student
                    else if (menuChoice == 2)
                    {
                        // Create New Student method
                        menuChoice = userEntry.GetBackToMainMenu();
                        if (menuChoice == 0) break;
                    }

                    // Find a student
                    else if (menuChoice == 3)
                    {
                        Console.WriteLine("Find a student");

                        menuChoice = userEntry.GetBackToMainMenu();
                        if (menuChoice == 0) break;
                    }

                    // Add a grade and an assessment to a student
                    else if (menuChoice == 4)
                    {
                        Console.WriteLine("Add a grade and an assessment to a student");
                        
                        menuChoice = userEntry.GetBackToMainMenu();
                        if (menuChoice == 0) break;
                    }

                    // Other cases
                    else
                    {
                        userInterface.DisplayInvalidNumber();
                        continue;
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
                        serviceCourse.DisplayAllCourses();
                        
                        

                        userInterface.DisplayBackToMainMenu();
                        menuChoice = userEntry.GetBackToMainMenu();
                        if (menuChoice == 0) break;
                    }

                    // Find course by id
                    else if (menuChoice == 2)
                    {
                        userInterface.DisplayGetCourseById();
                        int id = userEntry.GetEnteredId();
                        Course courseToFind = serviceCourse.FindCourseById(id); // calls the method FindCourseById
                        Console.WriteLine($"Code course : {courseToFind.Id}    Course : {courseToFind.Name}\n");

                        menuChoice = userEntry.GetBackToMainMenu();
                        if (menuChoice == 0) break;
                    }

                    // Create new course
                    else if (menuChoice == 3)
                    {
                        Course newCourse = app.GetCourseToCreate();
                        serviceCourse.CreateCourse(newCourse);

                        menuChoice = userEntry.GetBackToMainMenu();
                        if (menuChoice == 0) break;
                    }

                    // Exclude a course by id
                    else if (menuChoice == 4)
                    {
                        userInterface.DisplayRemoveCourseById();
                        int id = userEntry.GetEnteredId();
                        serviceCourse.DeleteCourse(id);

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

            FileHandler.Serialize(dataApp);
        }
     }
}


