using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace FileExplorer.Classes
{
    [Serializable]
    public class Product : BaseModel
    {
        public Product()
        {
            
        }
        public Product(int id, string name, string desription) : base(id, name, desription)
        {
            
        }
    }
}
