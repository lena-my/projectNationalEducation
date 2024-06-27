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
        public int Id { get; }
        public string Name { get; }

        public Course(string name, int id)
        {
            Id = id;
            Name = name;
        }

        // empty constructor
        public Course() { }
    }
}

