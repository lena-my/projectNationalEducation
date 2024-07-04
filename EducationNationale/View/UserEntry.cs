
using System.ComponentModel.DataAnnotations;

namespace EducationNationale.View
{
    public class UserEntry
    {
        public int GetEnteredId()
        {
            int.TryParse(Console.ReadLine(), out int id);
            return id;
        }

        public int GetMenuChoice()
        {
            int.TryParse(Console.ReadLine(), out int menuChoice);
            return menuChoice;
        }

        public double? GetEnteredValueGrade()
        {
            string input = Console.ReadLine();
            if (double.TryParse(input, out double grade))
            {
                return grade;
            }
            else
            {
                return null;
            }
        }

        public string? GetEnteredObservation()
        {
            string observation = Console.ReadLine();
            return observation;
        }

        public Grade GetGradeToAdd (int idStudent, int idCourse)
        {
            double gradeValue = (double)GetEnteredValueGrade();
            string? observation = GetEnteredObservation();
            Grade gradeToAdd = new Grade(idCourse, idStudent, gradeValue, observation);

            return gradeToAdd;
        }

    }
}