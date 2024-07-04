
namespace EducationNationale
{
    // class used to define the types to FileHandler (that converts json files)
    public class DataApp
    {
        public List <Course> Courses { get; set; }
        public List <Student> Students { get; set; }

        public DataApp (List<Course> courses, List<Student> students)
        {
            Courses = courses;
            Students = students;
        }

    }
}