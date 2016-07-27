using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace VKAnalysis
{
    public class HumanGenerator
    {
        List<string> maleNames;
        List<string> femaleNames;
        List<string> surnames;
        List<Human> humans;
        //List<Book> books;
        public List<string> booksNames;
        public List<string> authors;

        Random random;
        string sex = null;
        string maleNamesFilePath = @"C:\Users\oleksandrv\Documents\Visual Studio 2015\Projects\VKAnalysis\VKAnalysis\Database\MaleNames.txt";
        string femaleNamesFilePath = @"C:\Users\oleksandrv\Documents\Visual Studio 2015\Projects\VKAnalysis\VKAnalysis\Database\FemaleNames.txt";
        string surnamesFilePath = @"C:\Users\oleksandrv\Documents\Visual Studio 2015\Projects\VKAnalysis\VKAnalysis\Database\Surnames.txt";
        string authorsFilePat = @"C:\Users\oleksandrv\Documents\Visual Studio 2015\Projects\VKAnalysis\VKAnalysis\Database\Authors.txt";
        string booksNamesFilePath = @"C:\Users\oleksandrv\Documents\Visual Studio 2015\Projects\VKAnalysis\VKAnalysis\Database\BooksNames.txt";

        public HumanGenerator()
        {
            random = new Random(DateTime.Now.Millisecond);
            humans = new List<Human>();
            surnames = new List<string>();
            maleNames = new List<string>();
            femaleNames = new List<string>();
            booksNames = new List<string>();
            authors = new List<string>();
            //books = new List<Book>();
            fillTheList(maleNamesFilePath, maleNames);
            fillTheList(femaleNamesFilePath, femaleNames);
            fillTheList(surnamesFilePath, surnames);
            fillTheList(authorsFilePat, authors);
            fillTheList(booksNamesFilePath, booksNames);
        }

        void fillTheList(string filePath, List<string> names)
        {
            string line = null;
            StreamReader srteamReader = new StreamReader(filePath);
            while ((line = srteamReader.ReadLine()) != null)
            {
                names.Add(line);
            }
        }

        string getRandomName()
        {
            string name = null;

            if (random.Next(0,2) > 0)
            {
                name = maleNames[random.Next(1, 100)];
                sex = "Male";
            }
            else
            {
                name = femaleNames[random.Next(1, 100)];
                sex = "Female";
            }

            return name;
        }

        string getRandomSurname()
        {
            string surname = surnames[random.Next(1,254)];
            return surname;
        }

        public Human GenerateHuman()
        {
            Human somebody = new Human(getRandomName(), getRandomSurname(), sex, random.Next(10, 71));
            return somebody;
        }
    }
}
