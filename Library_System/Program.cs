namespace Library_System
{
    internal class Program
    {
        static void Main(string[] args)
        {
           Library l = new Library();
            l.addBook(new Book() { Author = "ali ahmed", Title = "math", Type = "sciecnce", Year = "1/1/2021" });
            l.addBook(new Book() { Author = "Mark", Title = "physics", Type = "sciecnce", Year = "12/3/2014" });
            l.addBook(new Book() { Author = "souzan", Title = "Love", Type = "romanitc", Year = "19/12/2020" });
            l.addBook(new Book() { Author = "Ramy", Title = "Muscle", Type = "Sports", Year = "9/9/2017" });
            l.addBook(new Book() { Author = "Ramy", Title = "Football", Type = "Sports", Year = "19/1/2018" });
            l.addBook(new Book() { Author = "Hamza", Title = "Football", Type = "Sports", Year = "20/8/2015" });
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Welcome to our Library Managment System :");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("As a User , Here is your Valid Activities in out System :");
            Console.WriteLine();
            while (true)
            {
                Console.WriteLine("1- Display all Books ");
                Console.WriteLine("2- Display all Authors ");
                Console.WriteLine("3- Displat all Types");
                Console.WriteLine("4- Choose a book");
                Console.WriteLine("5- Search for a book");
                Console.WriteLine();

                Console.WriteLine("Enter Your Choice :");
                int num =  Convert.ToInt32(Console.ReadLine());

                if(num == 4)
                {
                    l.DisplayAllBooks();
                    Console.WriteLine();
                    Console.Write("Please Enter the book name you want: ");
                    string name = Console.ReadLine();
                    Book book = l.GetBookByTitle(name);
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
                else if(num == 5)
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

                Console.WriteLine("Do you want to return back to Menu ?");
                Console.WriteLine("1- Yes");
                Console.WriteLine("2- No");
                int num2 = Convert.ToInt32(Console.ReadLine());
                if (num2 == 1)
                {
                    Console.WriteLine("----------------------------------------");
                    Console.WriteLine();
                    continue;
                }
                else
                {
                    break;
                }


            }



        } 
    }
}
