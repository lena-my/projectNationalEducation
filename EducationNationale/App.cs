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

        public int IdGeneratorCourse()
        {
            int id = ServiceCourse.Courses.Max(x=> x.Id) + 1;
            return id;
        }
        public int IdGeneratorStudent()
        {
            int id = ServiceStudent.Students.Max(x=> x.Id) + 1;
            return id;
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
    }
}