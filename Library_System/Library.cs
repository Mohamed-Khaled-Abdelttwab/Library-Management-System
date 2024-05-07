using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Reflection.Metadata.BlobBuilder;
using System.Xml;
using Newtonsoft.Json;

namespace Library_System
{
    public class Library
    {
        private List<Book> books = new List<Book>();

        public void addBook(Book book)
        {
            books.Add(book);
        }
        public bool RemoveBook(string title, string author)
        {
            if(books.Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("There is no Books in the Library Right now !!");
                Console.ForegroundColor = ConsoleColor.White;
                return false;
            }
            else
            {
                foreach(Book book in books)
                {
                    if(book.Title == title && book.Author==author) 
                    {
                        books.Remove(book);
                        return true;
                    }
                }
            }
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("This Book Doesn't Exist");
            Console.ForegroundColor = ConsoleColor.White;
            return false;
        }
        public bool IfBooksExist()
        {
            return books.Count > 0;
        }
        public void SerializeToJson(string filePath)
        {
            string json = JsonConvert.SerializeObject(books, Newtonsoft.Json.Formatting.Indented);
            File.WriteAllText(filePath, json);
        }
        public void DeserializeFromJson(string filePath)
        {
            if (File.Exists(filePath))
            {
                string json = File.ReadAllText(filePath);
                books = JsonConvert.DeserializeObject<List<Book>>(json);
            }
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

        public void SubscrbeToEvent(LibraryUser user)
        {
            user.onBookChoosen += User_onBookChoosen;
        }

        private void User_onBookChoosen(Book book)
        {
           if(books.Contains(book))
            {
                books.Remove(book);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Your book added to your borrowed List");
                Console.ForegroundColor = ConsoleColor.White;
            }
        }
        public void RetrieveBook(Book book)
        {
            try
            {
                books.Add(book);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Proccess Pass Successfully !!");
                Console.ForegroundColor = ConsoleColor.White;
            }
            catch 
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid Book");
                Console.ForegroundColor = ConsoleColor.White;
            }
        }
    }
}
