using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_System
{
    internal class Library
    {
        private List<Book> books = new List<Book>();

        public void addBook(Book book)
        {
            books.Add(book);
        }
        public void DisplayAllBooks()
        {
            if (books.Count>0)
            {
                int number = 1;
                foreach (Book book in books)
                {
                    Console.WriteLine($"{number}- {book.Title} by {book.Author}");
                    number++;
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("There is no Books in the Library Right now !!");
                Console.ForegroundColor = ConsoleColor.White;
            }
        }
        public void DisplayAllAuthors()
        {
            if (books.Count > 0)
            {
                HashSet<string> Authors = new HashSet<string>();
                foreach (Book book in books)
                {
                    Authors.Add(book.Author);
                }
                int number = 1;
                foreach (var Author in Authors)
                {
                    Console.WriteLine($"{number}- {Author}");
                    number++;
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("There is no Authors Right now !!");
                Console.ForegroundColor = ConsoleColor.White;
            }
        }
        public void DisplayAllBooksByAuthors(string Author)
        {
            if (books.Count > 0)
            {
                int count = 0;
                int number = 1;
                foreach (Book book in books)
                {
                    if (book.Author == Author)
                    {
                        Console.WriteLine($"{number}- {book.Title}");
                        number++;
                        count++;
                    }
                }
                if (count == 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("This Author is not exist !!");
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("There is no Books in the Library Right now !!");
                Console.ForegroundColor = ConsoleColor.White;
            }
        }
        public void DisplayAllBookTypes()
        {
            if (books.Count > 0)
            {
                HashSet<string> Types = new HashSet<string>();
                foreach (Book book in books)
                {
                    Types.Add(book.Type);
                }
                int number = 1;
                foreach (var type in Types)
                {
                    Console.WriteLine($"{number}- {type}");
                    number++;
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("There is no Books in the Library Right now !!");
                Console.ForegroundColor = ConsoleColor.White;
            }
        }
        public void DisplayAllBooksByType(string type)
        {
            if (books.Count > 0)
            {
                int count = 0;
                int number = 1;
                foreach (Book book in books)
                {
                    if (book.Type == type)
                    {
                        Console.WriteLine($"{number}- {book.Title}");
                        number++;
                        count++;
                    }
                }
                if(count ==0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("This Type is not exist !!");
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("There is no Books in the Library Right now !!");
                Console.ForegroundColor = ConsoleColor.White;
            }
        }

        public Book GetBookByTitle(string title)
        {
            Book resultBook = null;
            int count = 0;
            foreach (var book in books)
            {
                if(book.Title == title)
                {
                    resultBook = book;
                    count++;
                }
            }
           if(count >1)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("There is Dublicated Book name , please Enter The Author Name :");
                Console.ForegroundColor = ConsoleColor.White;
                string author = Console.ReadLine();
                resultBook = GetBookByAuthor(title, author);
            }
            return resultBook;
        }

        public Book GetBookByAuthor(string title , string Author)
        {
            foreach (var book in books)
            {
                if (book.Title == title && book.Author==Author)
                {
                    return book;
                }
            }
            return null;
        }

        public Book Search(string title)
        {
            Book resultBook = null;
            if (books.Count > 0)
            {
                int count = 0;
                int number = 1;
                foreach ( var book in books)
                {
                    if(book.Title == title)
                    {
                        Console.WriteLine($"{number}- {book.Title} by {book.Author}");
                        count++;
                        number++;
                    }

                }

                if(count > 1)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("There is Dublicated Book name , please Enter The Author Name :");
                    Console.ForegroundColor = ConsoleColor.White;
                    string author = Console.ReadLine();
                    resultBook = GetBookByAuthor(title, author);
                }
                else
                {
                    resultBook = GetBookByTitle(title);
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("There is no Books in the Library Right now !!");
                Console.ForegroundColor = ConsoleColor.White;
            }
            return resultBook;
        }

    }
}
