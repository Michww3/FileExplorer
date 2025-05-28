using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileExplorer.Classes
{
    [Serializable]
    public class Document : BaseModel
    {
        public Document()
        {
            
        }
        public Document(int id, string name, string desription) : base(id, name, desription)
        {

        }
    }
}
