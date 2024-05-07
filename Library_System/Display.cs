using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_System
{
    internal class Display
    {
        public static string LibraryJsonFile = "C:\\Users\\El-Wattaneya\\Desktop\\Library_Managment_System\\Library_System\\Library.json";
        public static string UsersJsonFile = "C:\\Users\\El-Wattaneya\\Desktop\\Library_Managment_System\\Library_System\\Users.json";
        public static string AdminsJsonFile = "C:\\Users\\El-Wattaneya\\Desktop\\Library_Managment_System\\Library_System\\Admins.json";
        public static void UserDisplay()
        {
            Library l = new Library();
            l.DeserializeFromJson(LibraryJsonFile);
            UserAuthenticator userAuthenticator = new UserAuthenticator();
            userAuthenticator.DeserializeFromJson(UsersJsonFile);
            LibraryUser user;

            int choice = 0;
            bool loginflag = true;
            while (loginflag)
            {
                Console.WriteLine("Choose your Option :");
                Console.WriteLine("1- Login");
                Console.WriteLine("2- Sign UP");
                string check = Console.ReadLine();
                bool Isvalid = int.TryParse(check, out choice);
                if (Isvalid)
                {
                    if (choice == 1 || choice == 2)
                    {
                        break;
                    }
                }

                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid Option , Please Enter a valid Option ");
                    Console.ForegroundColor = ConsoleColor.White;
                
            }
            if (choice == 1)
            {
                Console.WriteLine("You Are Logging in now :");
                Console.Write("Please enter your Email : ");
                string Email = Console.ReadLine();
                Console.Write("Please enter your Password : ");
                string Password = Console.ReadLine();
                LibraryUser CheckUser = userAuthenticator.Login(Email, Password);
                if (CheckUser == null)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Login Faild");
                    Console.ForegroundColor = ConsoleColor.White;
                    return;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Logged in Successfully !!");
                    Console.ForegroundColor = ConsoleColor.White;
                    user = CheckUser;
                }
                
            }
            else
            {
                Console.Write("Please enter your name : ");
                string name = Console.ReadLine();
                Console.WriteLine();
                Console.Write("Please enter your Email : ");
                bool flag = true;
                string Email;
                string tempEmail="";
                while (flag)
                {
                    tempEmail = Console.ReadLine();
                    if (userAuthenticator.SetEmail(tempEmail))
                    {
                        if (userAuthenticator.CheckEmailIsExist(tempEmail) == true)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("This Email Already Exist");
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.Write("Please Enter A Valid Email: ");

                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("This is valid Email ");
                            Console.ForegroundColor = ConsoleColor.White;
                            flag = false;

                        }
                    }

                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("This is invalid Email ");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write("Please Enter A Valid Email: ");

                    }
                }
                Email=tempEmail;
                Console.Write("Please enter your Password : ");
                string Password = Console.ReadLine();
                user = new LibraryUser(name, Email, Password);
                userAuthenticator.Signup(user);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Signed UP Successfully !!");
                Console.ForegroundColor = ConsoleColor.White;
            }
            user.EnterTheLibrary(l);           
           Console.Clear(); 

            while (true)
            {
                bool iterator = true;
                int num = 0;
                while (iterator)
                {
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
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
                    Console.WriteLine("7- Retrieve A Book");
                    Console.WriteLine("8- Display Books By The Type You Want");
                    Console.WriteLine("9- Display Books By The Author You Want");

                    Console.WriteLine();

                    Console.WriteLine("Enter Your Choice :");
                   
                    string thechoice = Console.ReadLine();
                    bool isValid = int.TryParse(thechoice, out num);
                    if (isValid)
                    {
                        if (num >= 1 && num <= 9)
                        {                          
                            break;
                        }

                    }
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid Option , Please Enter a valid Option ");
                    Console.ForegroundColor = ConsoleColor.White;

                }

                if(num == 1)
                {
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine("Here is The Book List :");
                    Console.ForegroundColor = ConsoleColor.White;
                    l.DisplayAllBooks();
                }
                else if(num == 2)
                {
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine("Here is The Book List :");
                    Console.ForegroundColor = ConsoleColor.White;
                    l.DisplayAllAuthors();
                }
                else if(num == 3)
                {
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine("Here is The Book List :");
                    Console.ForegroundColor = ConsoleColor.White;
                    l.DisplayAllBookTypes();
                }              
                else if (num == 4)
                {
                    if (l.IfBooksExist())
                    {
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine("Here is The Book List :");
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
                else if (num == 7)
                {
                    bool checkBorrowedList = user.PrintBorrowedBooks();
                    if (checkBorrowedList)
                    {
                        Console.Write("Enter Book Name : ");
                        string Bookname = Console.ReadLine();
                        user.RetriveBook(Bookname);

                    }

                }
                else if(num == 8)
                {
                    Console.Write("Please Enter Your Type : ");
                    string type = Console.ReadLine();
                    l.DisplayAllBooksByType(type);
                }
                else if(num == 9)
                {
                    Console.Write("Please Enter Your Author : ");
                    string author = Console.ReadLine();
                    l.DisplayAllBooksByAuthors(author);
                }
                bool flag2 = true;
                int num2=0;
                while (flag2)
                {
                    Console.WriteLine("Do you want to return back to Menu ?");
                    Console.WriteLine("1- Yes");
                    Console.WriteLine("2- No");
                    string userchoice = Console.ReadLine();  
                    bool IsValidOption = int.TryParse(userchoice, out num2);
                    if (IsValidOption)
                    {
                        if(num2 == 1 || num2 ==2) 
                        {
                            flag2 = false;
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Invalid Option , Please Enter Invalid Option");
                            Console.ForegroundColor = ConsoleColor.White;
                        }
                        
                    }
                    else 
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Invalid Option , Please Enter Invalid Option");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
       
                }
                if(num2 == 1 ) 
                { 
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
        public static void AdminDisplay()
        {
            Library l = new Library();
            l.DeserializeFromJson(LibraryJsonFile);
            UserAuthenticator userAuthenticator = new UserAuthenticator();
            userAuthenticator.DeserializeFromJson(UsersJsonFile);
            AdminAuthenticator adminAuthenticator = new AdminAuthenticator();
            adminAuthenticator.DeserializeFromJson(AdminsJsonFile);
            Admin admin;
            int choice = 0;
            bool loginflag = true;
            while (loginflag)
            {
                Console.WriteLine("Choose your Option :");
                Console.WriteLine("1- Login");
                Console.WriteLine("2- Sign UP");
                string check = Console.ReadLine();
                bool Isvalid = int.TryParse(check, out choice);
                if (Isvalid)
                {
                    if (choice == 1 || choice == 2)
                    {
                        break;
                    }
                }

                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid Option , Please Enter a valid Option ");
                Console.ForegroundColor = ConsoleColor.White;

            }
            if (choice == 1)
            {
                Console.WriteLine("You Are Logging in now ");
                Console.Write("Please enter your Email : ");
                string Email = Console.ReadLine();
                Console.Write("Please enter your Password : ");
                string Password = Console.ReadLine();
                Admin CheckAdmin = adminAuthenticator.Login(Email, Password);
                if (CheckAdmin == null)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Login Faild");
                    Console.ForegroundColor = ConsoleColor.White;
                    return;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Logged in Successfully !!");
                    Console.ForegroundColor = ConsoleColor.White;
                    admin = CheckAdmin;
                }

            }
            else
            {
                Console.Write("Please enter your name : ");
                string name = Console.ReadLine();
                Console.WriteLine();
                Console.Write("Please enter your Email : ");
                bool flag = true;
                string Email;
                string tempEmail = "";
                while (flag)
                {
                    tempEmail = Console.ReadLine();
                    if (adminAuthenticator.SetEmail(tempEmail))
                    {
                        if (adminAuthenticator.CheckEmailIsExist(tempEmail) == true)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("This Email Already Exist");
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.Write("Please Enter A Valid Email: ");

                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("This is valid Email ");
                            Console.ForegroundColor = ConsoleColor.White;
                            flag = false;

                        }
                    }

                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("This is invalid Email ");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write("Please Enter A Valid Email: ");

                    }
                }
                Email = tempEmail;
                Console.Write("Please enter your Password : ");
                string Password = Console.ReadLine();
                admin = new Admin(name, Email, Password);
                adminAuthenticator.Signup(admin);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Signed UP Successfully !!");
                Console.ForegroundColor = ConsoleColor.White;
            }
            admin.EnterTheLibrary(l);
            Console.Clear();
            bool iterator = true;
            int num ;
            while (iterator)
            {

                while (true)
                {
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine("Welcome to our Library Managment System :");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("As a Admin , Here is your Valid Activities in our System :");
                    Console.WriteLine();
                    Console.WriteLine("1- Display all Books ");
                    Console.WriteLine("2- Display all Authors ");
                    Console.WriteLine("3- Display all Types");
                    Console.WriteLine("4- Add Book");
                    Console.WriteLine("5- Remove Book");
                    Console.WriteLine("6- Display All users in the system");
                    Console.WriteLine("7- Display All Borrowed Books from Library");
                    Console.WriteLine("8- Delete An User");

                    Console.WriteLine();
                    Console.WriteLine("Enter Your Choice :");

                    string thechoice = Console.ReadLine();
                    bool isValid = int.TryParse(thechoice, out num);
                    if (isValid)
                    {
                        if (num >= 1 && num <= 9)
                        {
                            break;
                        }

                    }
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid Option , Please Enter a valid Option ");
                    Console.ForegroundColor = ConsoleColor.White;

                
                }
                if (num == 1)
                {
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine("Here is The Book List :");
                    Console.ForegroundColor = ConsoleColor.White;
                    l.DisplayAllBooks();
                }
                else if (num == 2)
                {
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine("Here is The Book List :");
                    Console.ForegroundColor = ConsoleColor.White;
                    l.DisplayAllAuthors();
                }
                else if (num == 3)
                {
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine("Here is The Book List :");
                    Console.ForegroundColor = ConsoleColor.White;
                    l.DisplayAllBookTypes();
                }
                else if (num == 4)
                {
                    Console.Write("Enter The Book Title : ");
                    string title = Console.ReadLine();
                    Console.Write("Enter The Book Author : ");
                    string Author = Console.ReadLine();
                    Console.Write("Enter The Book Type : ");
                    string Type = Console.ReadLine();
                    Console.Write("Enter The Book Publish Year : ");
                    string Year = Console.ReadLine();
                    Book newBook = new Book() {Title= title  , Author=Author ,Type=Type, Year=Year};
                    admin.AddBook(newBook);
                    Console.ForegroundColor= ConsoleColor.Green;
                    Console.WriteLine("Your Book is Added Successfully !!");
                    Console.ForegroundColor = ConsoleColor.White;


                }
                else if (num == 5)
                {
                    Console.WriteLine("Enter the book and The Author you want to Delete :");
                    Console.Write("Enter Book Name :");
                    string title = Console.ReadLine();
                    Console.Write("Enter Book Author :");
                    string author = Console.ReadLine();
                    if(admin.RemoveBook(title,author))
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Book Deleted Successfully !!");
                        Console.ForegroundColor = ConsoleColor.White;
                    }

                }
                else if (num == 6)
                {
                   admin.DisplayAllUsers(UserAuthenticator.users);
                }
                else if (num == 7)
                {
                    admin.DisplayAllBorrowedBooks(UserAuthenticator.users);

                }
                else if (num == 8)
                {
                    Console.WriteLine("Enter User Email You Want to delete :");
                    string Email = Console.ReadLine();
                    admin.DeleteUser(Email, UserAuthenticator.users);
                }
                bool flag2 = true;
                int num2 = 0;
                while (flag2)
                {
                    Console.WriteLine("Do you want to return back to Menu ?");
                    Console.WriteLine("1- Yes");
                    Console.WriteLine("2- No");
                    string Adminchoice = Console.ReadLine();             
                    bool IsValidOption = int.TryParse(Adminchoice, out num2);
                    if (IsValidOption)
                    {
                        if (num2 == 1 || num2 == 2)
                        {
                            flag2 = false;
                        }

                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Invalid Option , Please Enter Invalid Option");
                        Console.ForegroundColor = ConsoleColor.White;
                    }

                }
                if (num2 == 1)
                {
                    Console.Clear();
                    continue;
                }
                else
                {
                    break;
                }


            }

            l.SerializeToJson(LibraryJsonFile);
            adminAuthenticator.SerializeToJson(AdminsJsonFile);
            userAuthenticator.SerializeToJson(UsersJsonFile);
        }

    }
}
