using System;

namespace DesignPatterns._4._0._Otros.DependencyInjection
{
    public class DrinkWithBeerDi
    {
        //No se está aplicando la inyección de dependencias, si cambia Beer, hay que cambiar esta clase
        private readonly Beer _beer;
        private readonly decimal _water;
        private readonly decimal _sugar;

        public DrinkWithBeerDi(decimal water, decimal sugar, Beer beer)
        {
            _water = water;
            _sugar = sugar;
            _beer = beer;
        }

        public void Build()
        {
            Console.WriteLine($"Preparamos bebida que tiene agua {_water}" +
                $" azúcar {_sugar} y cerveza {_beer.Name}");
        }
    }
}
