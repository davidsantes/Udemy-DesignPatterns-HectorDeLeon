using System;

namespace DesignPatterns._3._0._Comportamiento.Strategy
{
    public class CarStrategy : IStrategy
    {
        public void Run()
        {
            Console.WriteLine("Soy un coche y me muevo con cuatro ruedas");
        }
    }
}
