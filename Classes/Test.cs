using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileExplorer.Classes
{
    internal class Test
    {
        public int Id;
        public string Name;
        public string Description;
        public Test()
        {

        }
        public Test(int id, string name, string desription)
        {
            Id = id;
            Name = name;
            Description = desription;
        }
    }
}
