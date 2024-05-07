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

        public LibraryUser(string name , string email , string password)
        {
            this.Name = name;
            this.Email = email;
            this.Password = password;
        }
        public LibraryUser()
        {
            
        }
        public void EnterTheLibrary(Library library)
        {
            this.Library = library;
        }
        public bool PrintBorrowedBooks()
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
                return true;
            }
            else
            {

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("You Don't Have Borrowed Books !!");
                Console.ForegroundColor = ConsoleColor.White;
            }
            return false;
            
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
        public void RetriveBook(string bookname)
        {
                Book resultBook = new Book();
                int count = 0;
                foreach (var book in borrowedBooks)
                {
                    if (book.Title == bookname)
                    {
                        resultBook = book;
                        count++;
                    }
                }
                if (count > 1)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("There is Dublicated Book name , please Enter The Author Name : ");
                    Console.ForegroundColor = ConsoleColor.White;
                    string author = Console.ReadLine();
                    foreach (var book in borrowedBooks)
                    {
                        if (book.Title == bookname && book.Author==author)
                        {
                            resultBook = book;
                            break;
                        }
                    }
                Library.RetrieveBook(resultBook);
                borrowedBooks.Remove(resultBook);
                    
                }
                else if(count ==0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("This Book is not in your borrowed books  !!");
                    Console.ForegroundColor = ConsoleColor.White;
                }
            else
            {
                Library.RetrieveBook(resultBook);
                borrowedBooks.Remove(resultBook);
               
            }
            
        }

        public override string ToString()
        {
            return $"User Name : {Name} , Email : {Email} , Password {Password}";
        }


    }
}
