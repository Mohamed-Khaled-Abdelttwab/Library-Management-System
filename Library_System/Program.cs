namespace Library_System
{
    internal class Program
    {
        public static string LibraryJsonFile = "C:\\Users\\El-Wattaneya\\Desktop\\Library_Managment_System\\Library_System\\Library.json";
        public static string UsersJsonFile = "C:\\Users\\El-Wattaneya\\Desktop\\Library_Managment_System\\Library_System\\Users.json";
        static void Main(string[] args)
        {
             Library l = new Library();
            l.DeserializeFromJson(LibraryJsonFile);
            UserAuthenticator userAuthenticator = new UserAuthenticator();
            userAuthenticator.DeserializeFromJson(UsersJsonFile);
            foreach (var us in userAuthenticator.users)
            {
                Console.WriteLine(us.Name + " " + us.Email);
            }
            Console.WriteLine("You are Signing In Now ");

            Console.Write("Please enter your name : ");
            string name = Console.ReadLine();
            Console.WriteLine();

            Console.Write("Please enter your Email : ");
            string Email = Console.ReadLine();
            if (userAuthenticator.SetEmail(Email))
            {
                if (userAuthenticator.CheckEmailIsExist(Email) == true)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("This Email Already Exist");
                    Console.ForegroundColor = ConsoleColor.White;
                    return;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("This is valid Email ");
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("This is invalid Email ");
                Console.ForegroundColor = ConsoleColor.White;
                return;
            }


            Console.WriteLine();
            Console.Write("Please enter your Password : ");
            string Password = Console.ReadLine();
            LibraryUser user = new LibraryUser(name, Email, Password, l);
            userAuthenticator.Signup(user);
            Console.WriteLine();
            Console.WriteLine("----------------------------------------------------");
            Console.WriteLine();

            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Welcome to our Library Managment System :");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("As a User , Here is your Valid Activities in out System :");
                Console.WriteLine();
                Console.WriteLine("1- Display all Books ");
                Console.WriteLine("2- Display all Authors ");
                Console.WriteLine("3- Display all Types");
                Console.WriteLine("4- Choose a book");
                Console.WriteLine("5- Search for a book");
                Console.WriteLine("6- Display your Borrowed Books list");

                Console.WriteLine();

                Console.WriteLine("Enter Your Choice :");
                int num = Convert.ToInt32(Console.ReadLine());

                if (num == 4)
                {
                    if (l.IfBooksExist())
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("The Library Book List :");
                        Console.WriteLine();
                        Console.ForegroundColor = ConsoleColor.White;
                        l.DisplayAllBooks();
                        Console.Write("Please Enter The book you want : ");
                        string bookname = Console.ReadLine();
                        l.SubscrbeToEvent(user);
                        user.ChooseBook(bookname);

                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Sorry There is no Books Available Right Now");
                        Console.ForegroundColor = ConsoleColor.White;
                    }


                }
                else if (num == 5)
                {
                    Console.Write("Enter The Book name You Search For :");
                    string title = Console.ReadLine();
                    Book book = l.Search(title);
                    if (book != null)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("your Book Details is :");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine(book);
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("This Book Doesn't Exist");
                        Console.ForegroundColor = ConsoleColor.White;

                    }
                }
                else if (num == 6)
                {
                    user.PrintBorrowedBooks();
                }

                Console.WriteLine("Do you want to return back to Menu ?");
                Console.WriteLine("1- Yes");
                Console.WriteLine("2- No");
                int num2 = Convert.ToInt32(Console.ReadLine());
                if (num2 == 1)
                {
                    Console.WriteLine("----------------------------------------");
                    Console.WriteLine();
                    Console.Clear();
                    continue;
                }
                else
                {

                    break;
                }


            }
            l.SerializeToJson(LibraryJsonFile);
            userAuthenticator.SerializeToJson(UsersJsonFile);




        } 
    }
}
