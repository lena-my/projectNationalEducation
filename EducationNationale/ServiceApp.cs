using System.Globalization;
using EducationNationale.Business;

namespace EducationNationale
{
    public class ServiceApp
    {
        public readonly ServiceStudent ServiceStudent;
        public readonly ServiceCourse ServiceCourse;
        
        public ServiceApp(ServiceStudent serviceStudent,ServiceCourse serviceCourse){
            ServiceCourse = serviceCourse;
            ServiceStudent = serviceStudent;
        }

        public int IdGeneratorCourse()
        {
            return ServiceCourse.Courses.Max(x=> x.Id) + 1;
        }
        public int IdGeneratorStudent()
        {
            return ServiceStudent.Students.Max(x=> x.Id) + 1;
        }

        public bool Save()
        {
            return FileHandler.Serialize(new DataApp(ServiceCourse.Courses,ServiceStudent.Students));
        }

        public void DisplayStudents(){
            Console.WriteLine("List of students");
            Console.WriteLine("----------------------------------------------------------------------");
            ServiceStudent.DisplayStudents(ServiceCourse.Courses);
            Console.WriteLine("----------------------------------------------------------------------");
        }
        
         // method create new student
        public Student GetStudentToCreate ()
        {
            Console.WriteLine("Add new student");

            Console.WriteLine("Name :");
            var name = Console.ReadLine();
            
            Console.WriteLine("Surname:");
            var surname = Console.ReadLine();

            Console.WriteLine("Birthday (dd/mm/yyyy):");
            string birthdayInput = Console.ReadLine();
            string format = "dd/MM/yyyy";
            DateOnly.TryParseExact(birthdayInput, format, CultureInfo.InvariantCulture, DateTimeStyles.None, out DateOnly birthday);
            return new Student(IdGeneratorStudent(), name, surname, birthday);
        }

        public Course? GetCourseToCreate()
        {
            Console.WriteLine("Add new course");
            Console.WriteLine("Enter the name of a course:");
            string courseString = Console.ReadLine();

            if(string.IsNullOrEmpty(courseString)){
                return null;
            }

            return new Course(IdGeneratorCourse(),courseString);
        }

        public void DisplayAllCourses(){
            ServiceCourse.DisplayAllCourses();
        }

        public void CreateCourse(Course course)
        {
            ServiceCourse.CreateCourse(course);
            Save();
        }

        public Course FindCourseById(int id){
            return ServiceCourse.FindCourseById(id);
        }

        public void DeleteCourse(int id){
            ServiceCourse.DeleteCourse(id);
            Save();
        }

        public void CreateStudent(Student student)
        {
            try {
                ServiceStudent.CreateStudent(student);
                Save();
            }
            catch (System.Exception e)
            {
                Console.WriteLine($"Student not created. ERROR: {e.Message}");
            }
            
        }

        public Student FindStudentById (int id)
        {
            return ServiceStudent.FindStudentById(id);
        }

        public void DeleteStudent(int id)
        {
            ServiceStudent.DeleteStudent(id);
            Save();
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
            }
            catch (System.Exception e)
            {
                Console.WriteLine($"Grade not added. ERROR: {e.Message}");
            }
            
        }
    }
}