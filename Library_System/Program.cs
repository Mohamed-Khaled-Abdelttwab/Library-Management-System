namespace Library_System
{
    internal class Program
    {

        static void Main(string[] args)
        {
            bool flag = true;
            int choice = 0;
            while (flag)
            {
           
                Console.WriteLine("Choose Your Type :");
                Console.WriteLine("1- User");
                Console.WriteLine("2- Admin");

                string userChoice = Console.ReadLine();
                bool isValid = int.TryParse(userChoice,out choice);
                if (isValid)
                {
                    if(choice ==1 || choice ==2) 
                    {
                        break;
                    }
                }
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid Option , Please Enter a Valid Option");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine();
            }
            if (choice == 1)
            {
                Console.Clear();
                Display.UserDisplay();
            }
            else if (choice == 2)
            {
                Console.Clear();
                Display.AdminDisplay();
            }



        }
    }
}
