using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace VKAnalysis.Database
{
    public class DatabaseEngine
    {
        DataSerializer<List<Human>> serializer;
        public List<Human> users;
        string XMLDataPath = Path.Combine(Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location), "Database\\data.xml");

        public DatabaseEngine()
        {
            users = new List<Human>();
            serializer = new DataSerializer<List<Human>>();


        }
    }
}
