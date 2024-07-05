using System.Globalization;
using System.Text.RegularExpressions;
using EducationNationale.Business;
using Serilog;

namespace EducationNationale
{
    public class ServiceApp
    {
        private const string PATTERN_NAME = @"^\p{L}+(?:[-' ]\p{L}+)*$";
        public readonly ServiceStudent ServiceStudent;
        public readonly ServiceCourse ServiceCourse;

        public ServiceApp(ServiceStudent serviceStudent, ServiceCourse serviceCourse)
        {
            ServiceCourse = serviceCourse;
            ServiceStudent = serviceStudent;
        }

        public int IdGeneratorCourse()
        {
            return ServiceCourse.Courses.Max(x => x.Id) + 1;
        }
        public int IdGeneratorStudent()
        {
            return ServiceStudent.Students.Max(x => x.Id) + 1;
        }

        public bool Save()
        {
            return FileHandler.Serialize(new DataApp(ServiceCourse.Courses, ServiceStudent.Students));
        }

        public void DisplayStudents()
        {
            Console.WriteLine("List of students");
            Console.WriteLine("----------------------------------------------------------------------");
            ServiceStudent.DisplayStudents(ServiceCourse.Courses);
            Console.WriteLine("----------------------------------------------------------------------");
        }

        // method create new student
        public Student GetStudentToCreate()
        {
            string nameStudent;
            string surnameStudent;
            DateOnly birthdayStudent;

            Regex regex = new Regex(PATTERN_NAME, RegexOptions.Compiled | RegexOptions.IgnoreCase);

            Console.WriteLine("Add new student");

            // loop to enter the correct name
            while (true)
            {
                Console.WriteLine("Name :");
                string name = Console.ReadLine();

                if (regex.IsMatch(name))
                {
                    nameStudent = name;
                    break;
                }
                else
                {
                    Console.WriteLine($"{name} is a invalid name.");
                }
            }

            // loop to enter the correct surname
            while (true)
            {
                Console.WriteLine("Surname:");
                string surname = Console.ReadLine();

                if (regex.IsMatch(surname))
                {
                    surnameStudent = surname;
                    break;
                }
                else
                {
                    Console.WriteLine($"{surname} is a invalid name.");   
                }
            }
           
            // loop into correct date
            while (true)
            {
                Console.WriteLine("Birthday (dd/mm/yyyy):");
                string birthdayInput = Console.ReadLine();
                string format = "dd/MM/yyyy";

                if (DateOnly.TryParseExact(birthdayInput, format, CultureInfo.InvariantCulture, DateTimeStyles.None, out birthdayStudent))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid date format. Please enter the date in dd/mm/yyy format.");
                } 
            }
            
            return new Student(IdGeneratorStudent(), nameStudent, surnameStudent, birthdayStudent);
        }

        public Course? GetCourseToCreate()
        {
            Console.WriteLine("Add new course");
            Console.WriteLine("Enter the name of a course:");
            string courseString = Console.ReadLine();

            if (string.IsNullOrEmpty(courseString))
            {
                return null;
            }

            return new Course(IdGeneratorCourse(), courseString);
        }

        public void DisplayAllCourses()
        {
            ServiceCourse.DisplayAllCourses();
            Log.Information("Displayed list of all courses.");
        }

        public void CreateCourse(Course course)
        {
               ServiceCourse.CreateCourse(course);
                Save();
                Console.WriteLine($"id: {course.Id}, name: {course.Name} created successfully.");  
                Log.Information($"Created course id: {course.Id}, name: {course.Name}.");           
        }

        public Course FindCourseById(int id)
        {
            Log.Information($"Found course by id {id}.");
            return ServiceCourse.FindCourseById(id);
        }

        public void CreateStudent(Student student)
        {
                ServiceStudent.CreateStudent(student);
                Save();
                Console.WriteLine($"{student.Name} {student.Surname}, birthday: {student.Birthday} created successfully.");
                Log.Information($"Creation of new student {student.Name} {student.Surname}, birthday: {student.Birthday}");
        }

        public Student FindStudentById(int id)
        {
            Log.Information($"Search student by id {id}.");
            return ServiceStudent.FindStudentById(id);
        }

        public void DeleteStudent(int id)
        {
                ServiceStudent.DeleteStudent(id);
                Save();
                Console.WriteLine($"Student with id {id} was removed successfully.");
                Log.Information($"Removed student with id {id}");
        }

        public void DisplayStudentById(Student studentToFind)
        {
            ServiceStudent.DisplayStudent(studentToFind, ServiceCourse.Courses);
            Log.Information($"Displayed student {studentToFind.Name} {studentToFind.Surname}, birthday {studentToFind.Birthday}, id {studentToFind.Id}");
        }

        public void AddGradeToStudent(Student student, Grade grade)
        {
                ServiceStudent.AddGrade(student, grade);
                Save();
                Console.WriteLine($"Grade {grade.Value} added to the course id {grade.CourseId} successfully.");
                Log.Information($"Added grade {grade.Value}  to the course id {grade.CourseId} to student {student.Name} {student.Surname}, ");
        }

        public void DeleteCourse(int id)
        {
            Course deletedCourse = ServiceCourse.DeleteCourse(id);
            ServiceStudent.DeleteStudentGrade(deletedCourse);
            Save();
            Log.Information($"Deleted course {deletedCourse.Name}, id {deletedCourse.Id}.");
        }
    }
}