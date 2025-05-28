using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileExplorer.Classes
{
    public abstract class BaseModel
    {
        public int Id;
        public string Name;
        public string Description;

        protected BaseModel()
        {
            
        }
        protected BaseModel(int id, string name, string description)
        {
            Id = id;
            Name = name;
            Description = description;
        }
        public override string ToString()
        {
            return Id + " " + Name;
        }
    }
}
