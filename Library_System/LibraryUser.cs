using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_System
{
    internal class LibraryUser:User
    {
        private List<Book> borrowedBooks = new List<Book>();

        public void PrintBorrowedBooks()
        {
            if (borrowedBooks.Count > 0)
            {
                foreach (var book in borrowedBooks)
                {
                    Console.WriteLine(book.Title);
                }
            }
            else
            {

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("You Don't Have Borrowed Books !!");
                Console.ForegroundColor = ConsoleColor.White;
            }
            
        }


    }
}
