
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
            while (true)
            {
                string input = Console.ReadLine();
                if (double.TryParse(input, out double grade))
                {
                    if (grade >= 0 && grade <= 20)
                    {
                        return grade;
                    }
                    else
                    {
                        Console.WriteLine("Invalid grade. Grade must be between 0 and 20.");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid number. Enter a valid number between 0 and 20.");
                    return null;
                }
            }
        }

        public string? GetEnteredObservation()
        {
            string observation = Console.ReadLine();
            return observation;
        }

        public Grade GetGradeToAdd(int idStudent, int idCourse)
        {
            double gradeValue = (double)GetEnteredValueGrade();
            string? observation = GetEnteredObservation();
            Grade gradeToAdd = new Grade(idCourse, idStudent, gradeValue, observation);

            return gradeToAdd;
        }

    }
}