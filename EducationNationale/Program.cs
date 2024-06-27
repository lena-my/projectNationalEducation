using System.Net.Mail;
using EducationNationale;
using EducationNationale.Business;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

public class Program
{
    public static void Main()
    {
        DataApp? dataApp = FileHandler.Deserialize();
        if(dataApp is null){
            dataApp = new DataApp(new List<Course> (){}, new List<Student> (){});
        }
        dataApp.Students.AddRange(new List<Student>{
            new Student(1,"toto","BOBO",new DateTime(2010,10,10)),
            new Student(2,"Helena","LaMeilleure",new DateTime(2000,10,10)),
        });

        dataApp.Courses.AddRange(new List<Course>{
            new Course("Math",1),
            new Course("Hist",2)
        });

        ServiceStudent serviceStudent = new ServiceStudent(dataApp.Students);
        ServiceCourse serviceCourse = new ServiceCourse(dataApp.Courses);

        App app = new App(serviceStudent, serviceCourse );

        app.DisplayStudents();

        UserInterface userInterface = new UserInterface();

        FileHandler.Serialize(dataApp);

    
        serviceCourse.CreateCourse(course);

        //serviceCourse.GetAllCourses();



        // serviceCampus.Courses = courses;
        // serviceCampus.Students = students;

        // serviceCourse.CreateCourse();



        while (true)
        {
            int menuChoice;
            userInterface.DisplayMainMenu();
            menuChoice = userInterface.ChooseMenu();

            // Menu student
            if (menuChoice == 1)
            {
                while (true)
                {
                    userInterface.DisplayMenuStudents();
                    menuChoice = userInterface.ChooseMenu(); 
                    if (menuChoice == 0) break; // Back to main menu

                    // List of students
                    else if (menuChoice == 1)
                    {
                        userInterface.DisplayStudents();
                        menuChoice = userInterface.DisplayBackToMainMenu();
                        if (menuChoice == 0) break;
                    }

                    // Add new student
                    else if (menuChoice == 2)
                    {
                        // Create New Student method
                        menuChoice = userInterface.DisplayBackToMainMenu();
                        if (menuChoice == 0) break;
                    }

                    // Find a student
                    else if (menuChoice == 3)
                    {
                        Console.WriteLine("Find a student");

                        menuChoice = userInterface.DisplayBackToMainMenu();
                        if (menuChoice == 0) break;
                    }

                    // Add a grade and an assessment to a student
                    else if (menuChoice == 4)
                    {
                        Console.WriteLine("Add a grade and an assessment to a student");
                        
                        menuChoice = userInterface.DisplayBackToMainMenu();
                        if (menuChoice == 0) break;
                    }

                    // Other cases
                    else
                    {
                        Console.WriteLine("Invalid entry. Try again.");
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
                    menuChoice = userInterface.ChooseMenu();

                    if (menuChoice == 0) break;

                    // List of courses
                    else if (menuChoice == 1)
                    {
                        Console.WriteLine("----------------------------------------------------------------------");
                        Console.WriteLine("\nList of courses");

                        menuChoice = userInterface.DisplayBackToMainMenu();
                        if (menuChoice == 0) break;
                    }

                    // Find course by id
                    else if (menuChoice == 2)
                    {
                        Console.WriteLine("----------------------------------------------------------------------");
                        Console.WriteLine("Find course by id");
                        Console.WriteLine("Enter the id of the course to find:");
                        int.TryParse(Console.ReadLine(), out int id); // output id to find

                        // calls the method FindCourseById
                        Course courseToFind = serviceCourse.FindCourseById(id);
                        Console.WriteLine($"Code course : {courseToFind.Id}    Course : {courseToFind.Name}\n");

                        menuChoice = userInterface.DisplayBackToMainMenu();
                        if (menuChoice == 0) break;
                    }

                    // Add new course
                    else if (menuChoice == 3)
                    {
                        Console.WriteLine("Add new course");
                        Console.WriteLine("Enter the name of a course:");
                        string courseString = Console.ReadLine();
                        Course course = new Course(courseString, 5); // creates a new course

                        // calls the method createCourse
                        serviceCourse.CreateCourse(course);

                        menuChoice = userInterface.DisplayBackToMainMenu();
                        if (menuChoice == 0) break;
                    }

                    // Exclude a course by id
                    else if (menuChoice == 4)
                    {
                        Console.WriteLine("Exclude a course by id");

                        Console.WriteLine("Enter the id of the course to remove:");
                        int.TryParse(Console.ReadLine(), out int id); // Enter the id of the course to exclude
                        serviceCourse.DeleteCourse(id);
                        serviceCourse.FindCourseById(id);

                        menuChoice = userInterface.DisplayBackToMainMenu();
                        if (menuChoice == 0) break;
                    }
                    else
                    {
                        Console.WriteLine("Invalid number. Try again.");
                    }
                }

            }
            else
            {
                Console.WriteLine("Invalid number. Try again.");
            }
        }
     }
}


