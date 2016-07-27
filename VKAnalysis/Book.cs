using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VKAnalysis
{
    public class Book
    {
        string name;
        string author;

        public Book()
        {

        }
        public Book(string name, string author)
        {
            this.name = name;
            this.author = author;
        }

        public string Name
        {
            get
            {
                return name;
            }

            set
            {
                name = value;
            }
        }

        public string Author
        {
            get
            {
                return author;
            }

            set
            {
                author = value;
            }
        }
    }
}
