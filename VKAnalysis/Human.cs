using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VKAnalysis
{
    public class Human
    {
        string name;
        string surname;
        string fullName;
        string sex;
        int age;
        List<Book> readedBooks;

        public Human(string name, string surname, string sex, int age)
        {
            this.name = name;
            this.surname = surname;
            this.sex = sex;
            this.age = age;

            this.fullName = name + " " + surname;
            readedBooks = new List<Book>();
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

        public string Surname
        {
            get
            {
                return surname;
            }

            set
            {
                surname = value;
            }
        }

        public string Sex
        {
            get
            {
                return sex;
            }

            set
            {
                sex = value;
            }
        }

        public int Age
        {
            get
            {
                return age;
            }

            set
            {
                age = value;
            }
        }

        public string FullName
        {
            get
            {
                return fullName;
            }
        }
    }
}
