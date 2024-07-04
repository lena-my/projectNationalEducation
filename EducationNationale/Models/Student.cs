
namespace EducationNationale
{
    public class Student
    {
        public int Id { get; }
        public string Name { get; }
        public string Surname { get; }
        public DateOnly Birthday { get; } // (yyyy, mm, dd)
        public List<Grade> Grades { get; }

        public Student(int id, string name, string surname, DateOnly birthday)
        {
            Id = id;
            Name = name;
            Surname = surname;
            Birthday = birthday;
            Grades = new List<Grade>();
        }

    }
}