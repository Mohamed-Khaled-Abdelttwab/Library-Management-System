using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_System
{
    internal class Admin : User
    {
        private Library Library;
        public Admin(string name, string email, string password)
        {
            this.Name = name;
            this.Email = email;
            this.Password = password;
        }
        public Admin()
        {
            
        }
        public void EnterTheLibrary(Library library)
        {
            this.Library = library;
        }
        public void AddBook(Book book)
        {
            Library.addBook(book);
        }
        public bool RemoveBook(string title , string author)
        {
            return Library.RemoveBook(title , author);
        }
        public void DisplayAllUsers(List<LibraryUser> users)
        {
            if(users.Count==0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("There is No Users in the system !!");
                Console.ForegroundColor = ConsoleColor.White;
                return;
            }
            foreach (LibraryUser user in users)
            {
                Console.WriteLine(user);
            }
        }
        public void DisplayAllBorrowedBooks(List<LibraryUser> users)
        {
            int count = 0;
            foreach (LibraryUser user in users)
            {
                foreach (var book in user.borrowedBooks)
                {                 
                    Console.WriteLine(book);
                    count++;
                }
            }
            if(count == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("There is No Borrowed Books !!");
                Console.ForegroundColor = ConsoleColor.White;
            }
           
        }

        public void DeleteUser(string email , List<LibraryUser> users)
        {
            foreach (var user in users) 
            {
                if (user.Email == email)
                {
                    foreach(var book in user.borrowedBooks)
                    {
                        Library.addBook(book);
                    }
                    users.Remove(user);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("User Deleted Successfully !!");
                    Console.ForegroundColor = ConsoleColor.White;
                    return;
                }
            }
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("This User Doesn't Exist !!");
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
