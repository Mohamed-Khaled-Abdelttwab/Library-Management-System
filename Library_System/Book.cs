using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_System
{
    internal class Book
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string Type { get; set; }
        public string Year { get; set; }

        public override string ToString()
        {
            return $"Book Tile : {Title} , Book Author : {Author} , Book Type : {Type} , Publish Year : {Type=Year}";
        }
    }
}
