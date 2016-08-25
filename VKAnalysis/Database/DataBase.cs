using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VKAnalysis.Database
{
    public class DataBase
    {
        public List<string> maleNames;
        public List<string> femaleNames;
        public List<string> surnames;
        public List<Human> humans;
        public DataBase()
        {

        }
        void GetMaleNames()
        {
            maleNames = new List<string>();


        }
    }
}
