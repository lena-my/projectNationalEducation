using System.Net.Mail;
using EducationNationale;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

/* Course mathematics = new Course("Mathematics");
Console.WriteLine(mathematics.GetIdCourse() + " " + mathematics.GetName());
mathematics.CreateCourse();

Course history = new Course("History");
Console.WriteLine(history.GetIdCourse() + " " + history.GetName());
history.CreateCourse(); */


public class Program
{
    public static void Main()
    {
        Campus serviceCampus = new Campus();
        Student serviceStudent = new Student();
        Course serviceCourse = new Course();

        List<Course> courses = new List<Course> {
            new Course ("Maths"), 
            new Course ("Geography"),
            new Course ("Phylosophie")
        };


        Console.Clear();
        while (true)
        {
            int menuChoice;

            Console.WriteLine("MAIN MENU");
            Console.WriteLine("Choose an option:");
            Console.WriteLine("1 - Student");
            Console.WriteLine("2 - Course");
            int.TryParse(Console.ReadLine(), out menuChoice);

            // Menu student
            if (menuChoice == 1)
            {
                while (true)
                {
                    //Console.Clear();
                    Console.WriteLine("MENU STUDENT");
                    Console.WriteLine("Choose an option:");
                    Console.WriteLine("0 - Back to the main menu");
                    Console.WriteLine("1 - List of students");
                    Console.WriteLine("2 - Add a new student");
                    Console.WriteLine("3 - Find a student");
                    Console.WriteLine("4 - Add a grade and an assessment to a student");

                    int.TryParse(Console.ReadLine(), out menuChoice);

                    // Back to main menu
                    if (menuChoice == 0)
                    {
                        break;
                    }

                    // List of students
                    else if (menuChoice == 1)
                    {
                        //Console.Clear();
                        Console.WriteLine("List of students");

                        serviceStudent.DisplayStudents();

                        Console.WriteLine("Press 0 to go back to main menu");
                        int.TryParse(Console.ReadLine(), out menuChoice); // create int menuChoice
                        if (menuChoice == 0)
                        {
                            break;
                        }
                    }

                    // Add new student
                    else if (menuChoice == 2)
                    {
                        //Console.Clear();
                        Console.WriteLine("Add new student");
                        Console.WriteLine("0 - Back to main menu");
                        int.TryParse(Console.ReadLine(), out menuChoice);
                        if (menuChoice == 0)
                        {
                            break;
                        }
                    }

                    // Find a student
                    else if (menuChoice == 3)
                    {
                        //Console.Clear();
                        Console.WriteLine("Find a student");
                        Console.WriteLine("0 - Back to main menu");
                        int.TryParse(Console.ReadLine(), out menuChoice);
                        if (menuChoice == 0)
                        {
                            break;
                        }
                    }

                    // Add a grade and an assessment to a student
                    else if (menuChoice == 4)
                    {
                        //Console.Clear();
                        Console.WriteLine("Add a grade and an assessment to a student");
                        Console.WriteLine("0 - Back to main menu");
                        int.TryParse(Console.ReadLine(), out menuChoice);
                        if (menuChoice == 0)
                        {
                            continue;
                        }
                    }

                    // Other cases
                    else
                    {
                        //Console.Clear();
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
                    
                    Console.WriteLine("MENU COURSE");
                    Console.WriteLine("Choose an option:");
                    Console.WriteLine("0 - Back to the main menu");
                    Console.WriteLine("1 - List of courses");
                    Console.WriteLine("2 - Find course by id");
                    Console.WriteLine("3 - Add a new course");
                    Console.WriteLine("4 - Exclude a course by id");

                    int.TryParse(Console.ReadLine(), out menuChoice);

                    // Back to main menu
                    if (menuChoice == 0)
                    {
                        break;
                    }

                    // List of courses
                    else if (menuChoice == 1)
                    {
                        Console.WriteLine("----------------------------------------------------------------------");
                        Console.WriteLine("List of courses");
                        
                        // calls the method DisplayALlCourses to display a list of the courses
                        serviceCourse.DisplayAllCourses();

                        Console.WriteLine("Press 0 to go back to main menu");
                        int.TryParse(Console.ReadLine(), out menuChoice); // output menuChoice
                        if (menuChoice == 0)
                        {
                            break;
                        }
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
                        Console.WriteLine($"Code course : {courseToFind.GetId()}    Course : {courseToFind.GetName()}\n");

                        // menu
                        Console.WriteLine("Press 0 to go back to main menu");
                        int.TryParse(Console.ReadLine(), out menuChoice); // output menuChoice

                        if (menuChoice == 0)
                        {
                            break;
                        }
                    }

                    // Add new course
                    else if (menuChoice == 3)
                    {
                        Console.WriteLine("Add new course");
                        Console.WriteLine("Enter the name of a course:");
                        string courseString = Console.ReadLine();
                        Course course = new Course(courseString); // creates a new course

                        // calls the method createCourse
                        serviceCourse.CreateCourse(course);

                        Console.WriteLine("\n0 - Back to main menu");

                        int.TryParse(Console.ReadLine(), out menuChoice); // output menuChoice

                        if (menuChoice == 0)
                        {
                            break;
                        }
                    }

                    // Exclude a course by id
                    else if (menuChoice == 4)
                    {
                        Console.WriteLine("Exclude a course by id");

                        Console.WriteLine("Enter the id of the course to remove:");
                        int.TryParse(Console.ReadLine(), out int id); // Enter the id of the course to exclude
                        serviceCourse.DeleteCourse(id);

                        Console.WriteLine("\n0 - Back to main menu");
                        int.TryParse(Console.ReadLine(), out menuChoice);

                        serviceCourse.FindCourseById(id);

                        if (menuChoice == 0)
                        {
                            break;
                        }
                    }
                    else {
                        Console.WriteLine("Invalid number. Try again");
                    }
                }

            }
            else
            {
                Console.WriteLine("Invalid number. Try again");
            }

        }
    }
}


