using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EducationNationale
{
    public class Campus
    {
        public int Id;
        public string Name;
        public List <Course> Courses;
        public List <Student> Students;

        public Campus (string name, List<Course> courses, List<Student> students, int id = 0)
        {
            Name = name;
            Courses = courses;
            Students = students;
        }

        // empty constructor
        public Campus () {}

        public int GenerateId ()
        {
            
            return 0;
        }

    }
}