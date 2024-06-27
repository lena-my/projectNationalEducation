using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using EducationNationale.Business;

namespace EducationNationale
{
    public class App
    {
        
        public readonly ServiceStudent ServiceStudent;

        public readonly ServiceCourse ServiceCourse;
        
        public App(ServiceStudent serviceStudent,ServiceCourse serviceCourse){
            ServiceCourse = serviceCourse;
            ServiceStudent = serviceStudent;
        }

        public int IdGenerator()
        {
            //TODO
            return 0;
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

            Student student = new Student();
            Console.WriteLine("Name :");
            student.Name = Console.ReadLine();
            
            Console.WriteLine("Surname:");
            student.Surname = Console.ReadLine();

            Console.WriteLine("Birthday (dd/mm/yyyy):");
            string bithdayInput = Console.ReadLine();
            string format = "dd/MM/yyyy";
            DateTime.TryParseExact(bithdayInput, format, System.Globalization.CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime birthday);
            student.Birthday = birthday;
            
            return student;
        }

        public Course? GetCourseToCreate()
        {
            Console.WriteLine("Add new course");
            Console.WriteLine("Enter the name of a course:");
            string courseString = Console.ReadLine();

            if(string.IsNullOrEmpty(courseString)){
                return null;
            }

            return new Course(courseString,IdGenerator());
        }
    }
}