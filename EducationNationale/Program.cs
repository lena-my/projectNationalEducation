using EducationNationale;
using EducationNationale.Business;
using EducationNationale.View;

public class Program
{
    public static void Main()
    {
            DataApp? dataApp = FileHandler.Deserialize(); // Converts the data.json to objects
            if (dataApp is null)
            {
                dataApp = new DataApp(new List<Course>() { }, new List<Student>() { });
            }

            ServiceStudent serviceStudent = new ServiceStudent(dataApp.Students);
            ServiceCourse serviceCourse = new ServiceCourse(dataApp.Courses);
            ServiceApp app = new ServiceApp(serviceStudent, serviceCourse);

        AppSchool appSchool = new AppSchool(app);
        appSchool.RunProgram();
    }
}


