
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

        public int GetBackToMainMenu()
        {
            //Console.WriteLine("0 - Back to main menu");
            int.TryParse(Console.ReadLine(), out int MenuChoice);

            return MenuChoice;
        }
        
    }
}