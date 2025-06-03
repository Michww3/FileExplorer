using System;

namespace FileExplorer.Classes
{
    public abstract class BaseModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreateDate { get; set; }
    }
}