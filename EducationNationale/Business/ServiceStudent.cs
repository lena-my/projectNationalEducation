using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace EducationNationale.Business
{
    public class ServiceStudent
    {
        public List<Student> Students;

        public ServiceStudent(List<Student> students){
            Students = students;
        }
        // method to get the average of grades of all the students


        public double GetAverage(Student student)
        {
            //TODO
            return 0;
        }

        public void DisplayStudents( List<Course> courses){
            foreach (var student in Students)
            {
                DisplayStudent(student, courses);
            }
        }

        // method to display list of students
        public void DisplayStudent(Student student, List<Course> courses)
        {
            Console.WriteLine("Student's information : \n");
            Console.WriteLine($"Name              : {student.Name}");
            Console.WriteLine($"Surname           : {student.Surname}");
            Console.WriteLine($"Birthday : \n\n");

            if(student.Grades is not null && student.Grades.Count>0)
            {
            Console.WriteLine($"Results :\n");

            foreach (var grade in student.Grades)
            {
                Course specificCourseOfGrade = courses.First(item => item.Id == grade.CourseId);
                DisplayGrade(grade,specificCourseOfGrade,0);
            }
            //DisplayAverage()
            }
                
        }
        public void DisplayGrade(Grade grade, Course coursOfGrade, double average){

            Console.WriteLine($"   Course : {coursOfGrade.Name}");
            Console.WriteLine($"      Grade       : {grade.Value}");
            Console.WriteLine($"      Observation : {grade.Observation}\n");
        }

       public void CreateStudent(string name, string surname, DateTime dateOfBirth){
            Student newStudent = new Student(1,name,surname,dateOfBirth);
            
       }

    }
}