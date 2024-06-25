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
            this.id = id;
            this.name = name;
        }

        // empty constructor
        public Course() { }

        // method to generate unique id
        public int IdGenerator()
        {
            //TODO
            return 0;
        }

        // method to create a new course
        public void CreateCourse()
        {
            Console.WriteLine("Enter the name of a couse:");
            string courseString = Console.ReadLine();
            Course course = new Course(courseString); // creates a new course

            // defines the path to data.json
            string directoryPath = "./bin/Debug/net8.0/";
            string filePath = Path.Combine(directoryPath, "data.json");

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

        // method to display all courses

        public void DisplayAllCourses()
        {
            // defines the path to data.json
            string directoryPath = "./bin/Debug/net8.0/";
            string filePath = Path.Combine(directoryPath, "data.json");

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
        public string FindCourseById()
        {
            // defines the path to data.json
            string directoryPath = "./bin/Debug/net8.0/";
            string filePath = Path.Combine(directoryPath, "data.json");

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
            List<Course> courses = new List<Course>();

            // Enter the id of the course to exclude
            Console.WriteLine("Display a course by id:");
            int.TryParse(Console.ReadLine(), out int id);

            Course course = courses.FirstOrDefault(c => c.GetId() == id);
            return course.GetName();
        }

        // Delete course by Id
        public void DeleteCourse()
        {
            Console.WriteLine("Enter the id of the course to remove:");
            int.TryParse(Console.ReadLine(), out int id);

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

