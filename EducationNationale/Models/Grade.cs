using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EducationNationale
{
    public class Grade
    {
        public readonly int CourseId ;
        public readonly int StudentId ;
        public readonly double Value ;
        public readonly string Observation ;

        public Grade (int id, int courseId, int studentId, double value, string observation = "")
        {
            CourseId = courseId;
            StudentId = studentId;
            Value = value;
            Observation = observation;
        }

        public Grade () {}

        
    }
}