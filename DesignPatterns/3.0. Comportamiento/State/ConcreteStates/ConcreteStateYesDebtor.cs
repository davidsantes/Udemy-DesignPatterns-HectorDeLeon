using System;

namespace DesignPatterns._3._0._Comportamiento.State.ConcreteStates
{
    public class ConcreteStateYesDebtor : IState
    {
        public void Handle(CustomerContext customerContext, decimal amount)
        {
            Console.WriteLine("No puedes comprar porque eres un deudor");
        }
    }
}
