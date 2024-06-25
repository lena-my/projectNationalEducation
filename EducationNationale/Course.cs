using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace EducationNationale
{
    public class Course
    {
        private int id;
        private string name;

        public Course(string name, int id = 0)
        {
            this.id = IdGenerator();
            this.name = name;
        }

        // empty constructor
        public Course() { }

        // method to generate unique id
        public int IdGenerator()
        {
            // defines the path to data.json
            string filePath = "./bin/Debug/net8.0/data.json";

            // check if the file exists
            if (!File.Exists(filePath))
            {
                Console.WriteLine("JSON file not found!");
            }

            // Read JSON file
            string json = File.ReadAllText(filePath);

            // Parse JSON using JObject
            JObject jsonData = JObject.Parse(json);

            // Extract list of "courses"
            JArray courseList = (JArray)jsonData["courses"];

            int lastId = (int)courseList.Last["id"];
            id = lastId + 1;

            return id;
        }

        // method to create a new course
        public void CreateCourse(Course course)
        {
            // defines the path to data.json
            string filePath = "./bin/Debug/net8.0/data.json";

            // check if the file exists
            if (!File.Exists(filePath))
            {
                Console.WriteLine("JSON file not found!");
            }

            // Read JSON file
            string json = File.ReadAllText(filePath);

            // Parse JSON using JObject
            JObject jsonData = JObject.Parse(json);

            // Extract list of "courses"
            JArray coursesList = (JArray)jsonData["courses"];

            //string jsonString = JsonConvert.SerializeObject(course, Formatting.Indented);

            // Write in json file
            //File.WriteAllText(filePath, jsonString);

            // Create new course to the list
            var newCourse = new
            {
                id = course.GetId(),
                name = course.GetName()
            };

            try
            {
                coursesList.Add(JObject.FromObject(newCourse));

                // Converts to JSON
                string updatedJson = JsonConvert.SerializeObject(jsonData, Formatting.Indented);

                // Write in json file
                File.WriteAllText(filePath, updatedJson);

                Console.WriteLine($"The course {course.GetName()} was added successfully to data.json.");

            }
            catch (Exception e)
            {
                Console.WriteLine($"Failed to add ${course.GetName} to data.json: {e.Message}");
            }
        }

        /*public void ReadAllCourses ()
        {
            string filePath = "./bin/Debug/net8.0/data.json";
            string json = File.ReadAllText(filePath);


        }*/

        // method to display all courses
        public void DisplayAllCourses()
        {
            // defines the path to data.json
            string filePath = "./bin/Debug/net8.0/data.json";

            // check if the file exists
            if (!File.Exists(filePath))
            {
                Console.WriteLine("JSON file not found!");
            }

            // Read JSON file
            string json = File.ReadAllText(filePath);

            // Parse JSON using JObject
            JObject jsonData = JObject.Parse(json);

            // Extract list of "courses"
            JArray courseList = (JArray)jsonData["courses"];


            // loop through JObject courseList
            foreach (JObject courseObject in courseList)
            {
                int id = (int)courseObject["id"];
                string name = (string)courseObject["name"];
                Console.WriteLine($"Code course : {id}    Course : {name}\n");
            }

        }

        // Get Course By Id
        public Course FindCourseById(int id)
        {
            // defines the path to data.json
            string filePath = "./bin/Debug/net8.0/data.json";

            // check if the file exists
            if (!File.Exists(filePath))
            {
                Console.WriteLine("JSON file not found!");
            }

            // Read JSON file
            string json = File.ReadAllText(filePath);

            // Parse JSON using JObject
            JObject jsonData = JObject.Parse(json);

            // Extract list of "courses"
            JArray courseList = (JArray)jsonData["courses"];

            // Find the course with the specified id
            foreach (JObject courseObj in courseList)
            {
                if ((int)courseObj["id"] == id)
                {
                    // Deserialize the JObject to Course
                    Course course = courseObj.ToObject<Course>();
                    return course;
                }
            }

            return null; // Course not found
        }

        // Delete course by Id
        public void DeleteCourse(int id)
        {
            // defines the path to data.json
            string filePath = "./bin/Debug/net8.0/data.json";

            // check if the file exists
            if (!File.Exists(filePath))
            {
                Console.WriteLine("JSON file not found!");
            }

            // Read JSON file
            string json = File.ReadAllText(filePath);

            // Parse JSON using JObject
            JObject jsonData = JObject.Parse(json);

            // Extract list of "courses"
            JArray courseList = (JArray)jsonData["courses"];

            JObject courseToRemove = null;

            // loop into array courseList to find the object to remove
            foreach (JObject courseObject in courseList)
            {
                if ((int)courseObject["id"] == id)
                {
                    courseToRemove = courseObject;
                    break;
                }
            }

            if (courseToRemove != null)
            {
                // remove the courseToRemove from courseList
                courseList.Remove(courseToRemove);

                // Convert updated JSON back to string
                string updatedJson = JsonConvert.SerializeObject(jsonData, Formatting.Indented);

                // Write the updated JSON back to the file
                File.WriteAllText(filePath, updatedJson);

                Console.WriteLine($"The course with id {id} was deleted successfully.");
            }
            else
            {
                Console.WriteLine($"Course with id {id} not found.");
            }
        }



        // getters and setters
        public int GetId()
        {
            return this.id;
        }

        public string GetName()
        {
            return this.name;
        }

        public void SetName(string name)
        {
            this.name = name;
        }

    }
}

