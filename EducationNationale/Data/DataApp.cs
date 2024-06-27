using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace EducationNationale
{
    public class DataApp
    {
        public List <Course> Courses { get; set; }
        public List <Student> Students { get; set; }

        public DataApp (List<Course> courses, List<Student> students)
        {
            Courses = courses;
            Students = students;
        }

        // empty constructor
        public DataApp () {
        }
        

    }

}