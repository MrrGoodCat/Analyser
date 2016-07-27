using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VKAnalysis
{
    public class Model
    {
        DataSerializer<List<Human>> serializer;
        public List<Human> users;
        public List<Book> Books;
        HumanGenerator humanGenerator;
        Random random;
        string XMLDataPath = @"C:\Users\oleksandrv\Documents\visual studio 2015\Projects\VKAnalysis\VKAnalysis\bin\data.xml";
        public Model()
        {          
            random = new Random(DateTime.Now.Millisecond);
            humanGenerator = new HumanGenerator();
            users = new List<Human>();
            Books = new List<Book>();
            serializer = new DataSerializer<List<Human>>();
        }

        public void GenerateBooks()
        {
            for (int i = 0; i < humanGenerator.booksNames.Count; i++)
            {
                Books.Add(new Book(humanGenerator.booksNames[i], humanGenerator.authors[i]));
            }
        }

        public void GenerateUsers(int countOfUsers)
        {
            for (int i = 0; i < countOfUsers; i++)
            {
                users.Add(humanGenerator.GenerateHuman());
            }
        }

        public void DistributeBooks()
        {
            foreach (var user in users)
            {
                user.ReadedBooks.AddRange(getRangomBooks(random.Next(1,96)));
            }
        }

        List<Book> getRangomBooks(int count)
        {
            int i = 0;
            List<Book> randomBooks = new List<Book>();
            int randomIndex = random.Next(0,96);
            while(!randomBooks.Contains(Books[randomIndex]) && i < count)
            {
                randomBooks.Add(Books[randomIndex]);
                randomIndex = random.Next(0, 96);
                i++;
            }

            return randomBooks;
        }

        public void GenerateData()
        {
            GenerateBooks();
            GenerateUsers(10000);
            DistributeBooks();
        }

        public void SerializeData()
        {
             serializer.Serialize(users, XMLDataPath);         
        }

    }
}
