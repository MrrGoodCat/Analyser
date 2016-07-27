using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VKAnalysis.Database
{
    public class DatabaseEngine
    {
        DataSerializer<List<Human>> serializer;
        public List<Human> users;
        string XMLDataPath = @"C:\XMLData\data.xml";

        public DatabaseEngine()
        {
            users = new List<Human>();
            serializer = new DataSerializer<List<Human>>();
        }
    }
}
