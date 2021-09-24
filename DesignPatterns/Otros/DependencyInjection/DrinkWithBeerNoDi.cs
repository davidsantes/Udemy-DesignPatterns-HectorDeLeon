using System;

namespace DesignPatterns.Otros.DependencyInjection
{
    public class DrinkWithBeerNoDi        
    {
        //No se está aplicando la inyección de dependencias, si cambia Beer, hay que cambiar esta clase
        private readonly Beer _beer = new Beer("Amstel", "Amstel brand");
        private readonly decimal _water;
        private readonly decimal _sugar;

        public DrinkWithBeerNoDi(decimal water, decimal sugar)
        {
            _water = water;
            _sugar = sugar;
        }

        public void Build()
        {
            Console.WriteLine($"Preparamos bebida que tiene agua {_water}" +
                $" azúcar {_sugar} y cerveza {_beer.Name}");
        }
    }
}
