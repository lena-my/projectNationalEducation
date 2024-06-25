using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace EducationNationale
{
    public class Student
    {
        public int Id;
        public string Name;
        public string Surname;
        public DateTime Birthday; // (yyyy, mm, dd)
        public List<Grade> Grades;

        public Student(int id, string name, string surname, DateTime birthday)
        {
            Id = id;
            Name = name;
            Surname = surname;
            Birthday = birthday;
            Grades = new List<Grade>();
        }

        public Student() {}

        // method to get the average of grades of all the students


        public double GetAverage()
        {
            //TODO
            return 0;
        }

        // method to display list of students
        public void DisplayStudents()
        {
            Console.WriteLine("----------------------------------------------------------------------");
            Console.WriteLine("Student's information : \n");
            Console.WriteLine($"Name              : ");
            Console.WriteLine($"Surname           : ");
            Console.WriteLine($"Birthday : \n\n");
            Console.WriteLine($"Results :\n");
            Console.WriteLine($"   Course :");
            Console.WriteLine($"      Grade       :");
            Console.WriteLine($"      Observation : \n");
            Console.WriteLine($"      Average     :\n");
            Console.WriteLine("----------------------------------------------------------------------");
        }

        public void ReadAllStudents()
        {
            // defines the path to data.json
            string directoryPath = "./bin/Debug/net8.0/";
            string filePath = Path.Combine(directoryPath, "data.json");

            // check if the file exists
            if (!File.Exists(filePath))
            {
                Console.WriteLine("JSON file not found!");
                return;
            }

            // Read JSON file
            string json = File.ReadAllText(filePath);

            // Parse JSON using JObject
            JObject jsonData = JObject.Parse(json);

            // Extract list of "students"
            JArray studentsArray = (JArray)jsonData["students"];
            List<string> studentNames = new List<string>();

            foreach (JObject studentObj in studentsArray)
            {
                string name = (string)studentObj["name"];
                studentNames.Add(name);
            }

            // Exibir os nomes dos alunos
            Console.WriteLine("Students:");
            foreach (string name in studentNames)
            {
                Console.WriteLine(name);
            }

        }

        // method create new student
        public Student CreateStudent ()
        {
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

        internal void DisplayCourses()
        {
            throw new NotImplementedException();
        }
    }
}