using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;

namespace EducationNationale.Business
{
    public class ServiceCourse
    {
        private readonly Log Logger = new Log();
        public List<Course> Courses;

        public ServiceCourse(List<Course> courses)
        {
            Courses = courses;
        }

        // method to create a new course
        public void CreateCourse(Course course)
        {
            if (Courses == null) // Ensure Courses list is initialized
            {
                Courses = new List<Course>(); // Creates a new list of Courses if it doesn't exist
            }

            Courses.Add(course); // Add the new course to the list
            Logger.LogAction($"Course id {course.Id}, name: {course.Name} added");
        }

        // method to display all courses
        public void DisplayAllCourses()
        {
            if (Courses != null)
            {
                foreach (var course in Courses)
                {
                    Console.WriteLine($"Id     : {course.Id}");
                    Console.WriteLine($"Course : {course.Name}\n");
                }
            }
        }

        // Get Course By Id
        public Course? FindCourseById (int id)
        {
            Course courseToFind = null;
            if (Courses != null)
            {
                foreach (Course course in Courses)
                {
                    if (id == course.Id)
                    {
                        courseToFind = course;
                        break;
                    }  
                }
                if (courseToFind == null) 
                {
                    Console.WriteLine("Course not found.");
                }
            }
            return courseToFind;
        }

        // Delete course by Id
        public void DeleteCourse(int id)
        {
            Course? courseToRemove = FindCourseById(id);
            Courses.Remove(courseToRemove);
            Console.WriteLine($"The course with id {id} was removed successfully.");
        }
    }
}