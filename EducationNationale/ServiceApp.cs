using System.Globalization;
using System.Text.RegularExpressions;
using EducationNationale.Business;

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
        }

        public void CreateCourse(Course course)
        {
            try
            {
               ServiceCourse.CreateCourse(course);
                Save();
                Console.WriteLine($"id: {course.Id}, name: {course.Name} created successfully."); 
            }
            catch (System.Exception e)
            {
                Console.WriteLine($"Course not created. ERROR: {e.Message}");
            }
            
        }

        public Course FindCourseById(int id)
        {
            return ServiceCourse.FindCourseById(id);
        }

        public void DeleteCourse(int id)
        {
            ServiceCourse.DeleteCourse(id);
            Save();
        }

        public void CreateStudent(Student student)
        {
            try
            {
                ServiceStudent.CreateStudent(student);
                Save();
                Console.WriteLine($"{student.Name} {student.Surname}, birthday: {student.Birthday} created successfully.");
            }
            catch (System.Exception e)
            {
                Console.WriteLine($"Student not created. ERROR: {e.Message}");
            }

        }

        public Student FindStudentById(int id)
        {
            return ServiceStudent.FindStudentById(id);
        }

        public void DeleteStudent(int id)
        {
            try{
                ServiceStudent.DeleteStudent(id);
                Save();
                Console.WriteLine($"Student with id {id} was removed successfully.");
            }
            catch (System.Exception e)
            {
                Console.WriteLine($"Student not deleted. ERROR: {e.Message}");
            }

        }

        public void DisplayStudentById(Student studentToFind)
        {
            ServiceStudent.DisplayStudent(studentToFind, ServiceCourse.Courses);
        }

        public void AddGradeToStudent(Student student, Grade grade)
        {
            try
            {
                ServiceStudent.AddGrade(student, grade);
                Save();
                Console.WriteLine($"Grade {grade.Value} added to the course id {grade.CourseId} successfully.");
            }
            catch (System.Exception e)
            {
                Console.WriteLine($"Grade not added. ERROR: {e.Message}");
            }
        }
    }
}