namespace DesignPatterns.Otros.DependencyInjection
{
    public class Beer
    {
        private string _name;
        private readonly string _brand;

        public string Name {
            get { return _name; }
        }

        public Beer(string name, string brand)
        {
            _name = name;
            _brand = brand;
        }
    }
}
