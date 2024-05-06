using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Reflection.Metadata.BlobBuilder;

namespace Library_System
{
    public delegate void BookChoosen(Book book);
  
    public class LibraryUser:User
    {
        public List<Book> borrowedBooks = new List<Book>();
        private Library Library;
        public event BookChoosen onBookChoosen;
        public LibraryUser(Library library)
        {
            this.Library = library;
        }
        public LibraryUser(string name , string email , string password, Library library)
        {
            this.Name = name;
            this.Email = email;
            this.Password = password;
            this.Library = library;
        }
        public LibraryUser()
        {
            
        }
        public void PrintBorrowedBooks()
        {
            if (borrowedBooks.Count > 0)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Your Borrowed Books list :");            
                Console.ForegroundColor = ConsoleColor.White;

                foreach (var book in borrowedBooks)
                {
                    Console.WriteLine(book.Title+" by "+book.Author);
                }
            }
            else
            {

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("You Don't Have Borrowed Books !!");
                Console.ForegroundColor = ConsoleColor.White;
            }
            
        }
        public void AddBookToBorrowedList(Book book)
        {
            borrowedBooks.Add(book);
        }
        public void DisplayAllBooks()
        {
            Library.DisplayAllBooks();
        }
        public void ChooseBook(string name)
        {
          
                Book book = Library.GetBookByTitle(name);
                if (book != null)
                {
                    if (onBookChoosen != null)
                    {
                        AddBookToBorrowedList(book);
                        onBookChoosen(book); // firing the event

                    }
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("This Book Doesn't Exist");
                    Console.ForegroundColor = ConsoleColor.White;

                }
            
        }




    }
}
