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

        public bool Save(){

            return FileHandler.Serialize(new DataApp(ServiceCourse.Courses,ServiceStudent.Students));
        }
        public void DisplayStudents(){
            Console.WriteLine("List of students");
            Console.WriteLine("----------------------------------------------------------------------");
            ServiceStudent.DisplayStudents(ServiceCourse.Courses);
            Console.WriteLine("----------------------------------------------------------------------");
        }
        
         // method create new student
        public Student CreateStudent ()
        {
            Console.WriteLine("Add new student");

            Console.WriteLine("Name :");
            var name = Console.ReadLine();
            
            Console.WriteLine("Surname:");
            var surname = Console.ReadLine();

            Console.WriteLine("Birthday (dd/mm/yyyy):");
            string bithdayInput = Console.ReadLine();
            string format = "dd/MM/yyyy";
            DateTime.TryParseExact(bithdayInput, format, System.Globalization.CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime birthday);
            
            return new Student(IdGeneratorStudent(),name,surname,birthday);
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

        public Course FindCourseById(int Id){
            return ServiceCourse.FindCourseById(Id);
        }

        public void DeleteCourse(int Id){
            ServiceCourse.DeleteCourse(Id);
            Save();
        }
    }
}