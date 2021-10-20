using System;

namespace DesignPatterns._3._0._Comportamiento.Strategy
{
    public class MotoStrategy : IStrategy
    {
        public void Run()
        {
            Console.WriteLine("Soy una motocicleta y me muevo con dos ruedas");
        }
    }
}
