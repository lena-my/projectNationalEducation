

using Newtonsoft.Json;

namespace EducationNationale
{
    public class Course
    {
        public int Id { get; }
        public string Name { get; }

        public Course(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}

