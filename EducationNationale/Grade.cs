using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EducationNationale
{
    public class Grade
    {
        public int CourseId { get; set; }
        public int StudentId { get; set; }
        public double Value;
        public string Observation;

        public Grade (int courseId, double value, string observation = ""){
            CourseId = courseId;
            Value = value;
            Observation = observation;
        }

    }
}