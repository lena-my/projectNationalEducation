using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;

namespace EducationNationale.Business
{
    public class ServiceCourse
    {
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
        }

        // method to display all courses
        public void GetAllCourses()
        {
            if (Courses != null)
            {
                foreach (var course in Courses)
                {
                    Console.WriteLine($"Id Course : {course.Id}");
                    Console.WriteLine($"Course : {course.Name}");
                }
            }

        }

        // Get Course By Id
        public Course FindCourseById(int id)
        {
            // string filePath = "./bin/Debug/net8.0/data.json"; // defines the path to data.json

            // if (!File.Exists(filePath)) // check if the file exists
            // {
            //     Console.WriteLine("JSON file not found!");
            // }

            // string json = File.ReadAllText(filePath); // Read JSON file
            // JObject jsonData = JObject.Parse(json); // Parse JSON using JObject
            // JArray courseList = (JArray)jsonData["courses"]; // Extract list of "courses"

            // foreach (JObject courseObj in courseList) // Find the course with the specified id
            // {
            //     if ((int)courseObj["id"] == id)
            //     {
            //         Course course = courseObj.ToObject<Course>(); // Deserialize the JObject to Course
            //         return course;
            //     }
            // }

            return null; // Course not found
        }

        // Delete course by Id
        public void DeleteCourse(int id)
        {
            // string filePath = "./bin/Debug/net8.0/data.json"; // defines the path to data.json

            // if (!File.Exists(filePath)) // check if the file exists
            // {
            //     Console.WriteLine("JSON file not found!");
            // }

            // string json = File.ReadAllText(filePath); // Read JSON file
            // JObject jsonData = JObject.Parse(json); // Parse JSON using JObject
            // JArray courseList = (JArray)jsonData["courses"]; // Extract list of "courses"
            // JObject courseToRemove = null;

            // foreach (JObject courseObject in courseList) // loop into array courseList to find the object to remove
            // {
            //     if ((int)courseObject["id"] == id)
            //     {
            //         courseToRemove = courseObject;
            //         break;
            //     }
            // }

            // if (courseToRemove != null)
            // {
            //     courseList.Remove(courseToRemove); // remove the courseToRemove from courseList
            //     string updatedJson = JsonConvert.SerializeObject(jsonData, Formatting.Indented); // Convert updated JSON back to string
            //     File.WriteAllText(filePath, updatedJson);  // Write the updated JSON back to the file

            //     Console.WriteLine($"The course with id {id} was deleted successfully.");
            // }
            // else
            // {
            //     Console.WriteLine($"Course with id {id} not found.");
            // }
        }
    }
}