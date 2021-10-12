namespace PRG282_Project_Group3
{
    internal class Modules
    {
        private string code;
        private string name;
        private string description;
        private string link;

        public Modules()
        {
        }

        public Modules(string code, string name, string description, string link)
        {
            Code = code;
            Name = name;
            Description = description;
            Link = link;
        }

        public string Code { get => code; set => code = value; }
        public string Name { get => name; set => name = value; }
        public string Description { get => description; set => description = value; }
        public string Link { get => link; set => link = value; }
    }
}