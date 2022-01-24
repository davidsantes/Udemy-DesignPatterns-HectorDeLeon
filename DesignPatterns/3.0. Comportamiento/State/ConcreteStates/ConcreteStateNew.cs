using System;

namespace DesignPatterns._3._0._Comportamiento.State.ConcreteStates
{
    public class ConcreteStateNew : IState
    {
        public void Handle(CustomerContext customerContext, decimal amount)
        {
            Console.WriteLine($"Se le pone dinero a su saldo {amount}");
            customerContext.Residue = amount;
            customerContext.SetState(new ConcreteStateNoDebtor());
        }
    }
}
