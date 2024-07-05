using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Serilog;

namespace EducationNationale.Business
{
    public class ServiceStudent
    {
        public List<Student> Students;

        public ServiceStudent(List<Student> students)
        {
            Students = students;
        }

        // method to get the average of grades of all the students
        public double GetAverage(Student student)
        {
            double sum = 0;

            foreach (var grade in student.Grades)
            {
                sum = +grade.Value;
            }

            return sum / student.Grades.Count(); // average
        }

        // Display the list of students
        public void DisplayStudents(List<Course> courses)
        {
            foreach (var student in Students)
            {
                DisplayStudent(student, courses);
            }

            Log.Information("Displayed list of students.");
        }

        // method to display a students
        public void DisplayStudent(Student student, List<Course> courses)
        {
            Console.WriteLine("Student's information : \n");
            Console.WriteLine($"Name              : {student.Name}");
            Console.WriteLine($"Surname           : {student.Surname}");
            string formattedBirthday = student.Birthday.ToString("dd/MM/yyyy");
            Console.WriteLine($"Birthday          : {formattedBirthday}\n\n");

            if (student.Grades is not null && student.Grades.Count > 0)
            {
                Console.WriteLine($"Results :\n");

                foreach (var grade in student.Grades)
                {
                    Course specificCourseOfGrade = courses.FirstOrDefault(item => item.Id == grade.CourseId);

                    if (specificCourseOfGrade is null)
                    {
                        Log.Error($"No matching id between idStudent {student.Id}  and Grade {grade.Value} and CourseId {grade.CourseId}");
                        break;
                    }

                    DisplayGrade(grade, specificCourseOfGrade, 0);
                }

                double average = GetAverage(student);
                Console.WriteLine($"Average : {average}");
            }

            Console.WriteLine("\n----------------------------------------------------------------------\n");
        }
        // Method to display grades according to the course and the student
        public void DisplayGrade(Grade grade, Course courseOfGrade, double average)
        {
            Console.WriteLine($"   Course : {courseOfGrade.Name}");
            Console.WriteLine($"        Grade       : {grade.Value}");
            Console.WriteLine($"        Observation : {grade.Observation}\n");
        }

        public void CreateStudent(Student student)
        {
            if (Students == null) // Ensure that Students is initalized
            {
                Students = new List<Student>(); // Creates a new List of Students if it doesn't exist
            }

            Students.Add(student);
        }

        public void AddGrade(Student student, Grade grade)
        {
            student.Grades.Add(grade);
        }

        // Find student by id
        public Student? FindStudentById(int id)
        {
            Student? studentToFind = Students.FirstOrDefault(student => student.Id == id);

            if (studentToFind == null)
            {
                Console.WriteLine("Student not found. Try another id.");
            }

            return studentToFind;
        }

        //Remove course by id
        public void DeleteStudent(int id)
        {
            Student? studentToRemove = FindStudentById(id);
            Students.Remove(studentToRemove);
            Console.WriteLine($"The student with id {id} was removed successfully.");
        }

        public void DeleteStudentGrade(Course deletedCourse)
        {
            Students.ForEach(x => x.Grades.RemoveAll(y => y.CourseId == deletedCourse.Id));
        }
    }
}