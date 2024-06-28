
namespace EducationNationale
{
    public class DataApp
    {
        public List <Course> Courses { get; set; }
        public List <Student> Students { get; set; }

        public DataApp (List<Course> courses, List<Student> students)
        {
            Courses = courses;
            Students = students;
        }

        // empty constructor
        public DataApp () {
            Courses = new List<Course>();
            Students = new List<Student>();
         }
    }
}