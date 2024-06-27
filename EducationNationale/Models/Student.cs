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
        public int Id { get; set; }
        public string Name { get; set; }        
        public string Surname { get; set; }
        public DateTime Birthday { get; set; } // (yyyy, mm, dd)
        public List<Grade> Grades { get; set; }

        public Student(int id, string name, string surname, DateTime birthday)
        {
            Id = id;
            Name = name;
            Surname = surname;
            Birthday = birthday;
            Grades = new List<Grade>();
        }

        public Student() {}

    }
}