using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace VKAnalysis
{
    public class Model
    {
        DataSerializer<List<Human>> serializer;
        public List<Human> users;
        public List<Book> Books;
        HumanGenerator humanGenerator;
        Random random;
        string XMLDataPath = Path.Combine(Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location), "Database\\data.xml");
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

        public void DeSerializeData()
        {
            users.AddRange(serializer.Deserialize(XMLDataPath));
        }

        string MoustPopularBook()
        {
            string bookName = null;

            
            foreach (var user in users)
            {

            }
            return bookName;
        }

        public string GetMoustPopularBook()
        {
            string moustPopularBook = null;

            //var book = users.SelectMany(a=>a.ReadedBooks.GroupBy(x => x.Name).OrderByDescending(x => x.Count()));

            //moustPopularBook = $"{book.First().First().Author} - {book.First().First().Name}, Count: {book.First().Key.Count()}";
            //var popularBook = (from user in users
            //                   from readedBooks in user.ReadedBooks
            //                   group readedBooks by readedBooks.Name).OrderByDescending(x => x.Count()).Select(x => x.Last());


            //moustPopularBook = popularBook.First().Author + " - " + popularBook.First().Name + ", Count: " + popularBook.Count();
            int count = 0;
            int result = 0;
            foreach (var b in Books)
            {
                foreach (var user in users)
                {
                    if (user.ReadedBooks.Contains(b))
                    {
                        count++;
                    }
                }
                if (count > result)
                {
                    result = count;
                    moustPopularBook = $"{b.Author} - {b.Name}, Count: {result}";
                }
            }

            return moustPopularBook;
        } 
    }
}
