namespace FileExplorer.Classes
{
    internal class Test
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
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
