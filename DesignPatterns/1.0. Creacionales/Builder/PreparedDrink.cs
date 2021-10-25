using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns._1._0._Creacionales.Builder
{
    /// <summary>
    /// Product
    /// </summary>
    public class PreparedDrink
    {
        public List<string> Ingredients = new List<string>();
        public int Milk;
        public int Water;
        public decimal Alcohol;
        public string Result;
    }
}
