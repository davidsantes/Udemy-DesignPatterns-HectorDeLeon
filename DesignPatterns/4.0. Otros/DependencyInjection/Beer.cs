namespace DesignPatterns._4._0._Otros.DependencyInjection
{
    public class Beer
    {
        private readonly string _name;
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
