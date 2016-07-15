using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VKAnalysis
{
    public class Model
    {
        public List<Human> users;
        HumanGenerator humanGenerator;
        public Model()
        {
            humanGenerator = new HumanGenerator();
            users = new List<Human>();
        }

        public void GenerateUsers(int countOfUsers)
        {
            for (int i = 0; i < countOfUsers; i++)
            {
                users.Add(humanGenerator.GenerateHuman());
            }
        }
    }
}
