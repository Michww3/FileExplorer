using System.Collections.Generic;

namespace FileExplorer.Classes
{
    internal class NavigatorObject
    {
        public List<Product> Products { get; set; }
        public List<Notification> Notifications { get; set; }
        public List<Document> Documents { get; set; }
    }
}
