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

        void GenerateBooks()
        {
            for (int i = 0; i < humanGenerator.booksNames.Count; i++)
            {
                Books.Add(new Book(humanGenerator.booksNames[i], humanGenerator.authors[i]));
            }
        }

        void GenerateUsers(int countOfUsers)
        {
            for (int i = 0; i < countOfUsers; i++)
            {
                users.Add(humanGenerator.GenerateHuman());
            }
        }

        void DistributeBooks()
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

        void GenerateData()
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
            if (File.Exists(XMLDataPath))
            {
                users.AddRange(serializer.Deserialize(XMLDataPath));
            }
            else
            {
                GenerateData();
                SerializeData();
            }
        }

        public string GetMoustPopularBook()
        {
            string moustPopularBook = null;

            var book = users.SelectMany(x => x.ReadedBooks).GroupBy(x => x.Name).OrderByDescending(x => x.Count()).First();

            moustPopularBook = $"{book.First().Author} - {book.First().Name}";

            return moustPopularBook;
        }

        public string GetLeastPopularBook()
        {
            string leastPopularBook = null;

            var book = users.SelectMany(x => x.ReadedBooks).GroupBy(x => x.Name).OrderByDescending(x => x.Count()).Last();

            leastPopularBook = $"{book.First().Author} - {book.First().Name}";

            return leastPopularBook;
        }

        public double GetAverageAmountOfBooks(string sex)
        {
            double averageCount = 0;

            var males = from user in users
                        where user.Sex == sex
                        select user;

            var count = males.Select(x => x.ReadedBooks.Count()).Average();
            averageCount = count;

            return averageCount;
        }

        public double GetAverageAmountOfBooks(int minAge, int maxAge, string sex)
        {
            double averageCount = 0;

            var females = from user in users
                        where (user.Age >= minAge && user.Age <= maxAge && user.Sex == sex)
                          select user;

            var count = females.Select(x => x.ReadedBooks.Count()).Average();
            averageCount = count;

            return averageCount;
        }

        public double GetMinAmountOfBooks(int minAge, int maxAge, string sex)
        {
            double minCount = 0;

            var females = from user in users
                          where (user.Age >= minAge && user.Age <= maxAge && user.Sex == sex)
                          select user;

            var count = females.Select(x => x.ReadedBooks.Count()).Min();
            minCount = count;

            return minCount;
        }

        public double GetMaxAmountOfBooks(int minAge, int maxAge, string sex)
        {
            double maxCount = 0;

            var females = from user in users
                          where (user.Age >= minAge && user.Age <= maxAge && user.Sex == sex)
                          select user;

            var count = females.Select(x => x.ReadedBooks.Count()).Max();
            maxCount = count;

            return maxCount;
        }
    }
}
