using EducationNationale;
using EducationNationale.Business;
using EducationNationale.View;

public class Program
{
    //serviceCourse.GetAllCourses();
    // serviceCampusourses = courses;
    // serviceCampus.Students = students;

    // serviceCourse.CreateCourse();

    // dataApp.Students.AddRange(new List<Student>{
        //         new Student(1,"","BOBO",new DateTime(2010,10,10)),
        //         new Student(2,"Helena","Miura",new DateTime(2000,10,10)),
        //     });

        // dataApp.Courses.AddRange(new List<Course>{
        //         new Course(1,"Math"),
        //         new Course(2,"Hist")
        //         });

    public static void Main()
    {
        
            DataApp? dataApp = FileHandler.Deserialize(); // Converts the data.json to
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


