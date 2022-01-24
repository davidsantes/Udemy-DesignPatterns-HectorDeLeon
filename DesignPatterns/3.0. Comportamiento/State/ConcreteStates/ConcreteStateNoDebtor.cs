using System;

namespace DesignPatterns._3._0._Comportamiento.State.ConcreteStates
{
    public class ConcreteStateNoDebtor : IState
    {
        public void Handle(CustomerContext customerContext, decimal amount)
        {
            if (amount <= customerContext.Residue)
            {
                customerContext.Discount(amount);
                Console.WriteLine($"Solicitud permitida, gasta {amount} y le queda de saldo {customerContext.Residue}");
                if (customerContext.Residue <= 0)
                {
                    customerContext.SetState(new ConcreteStateYesDebtor());
                }
            }
            else
            {
                Console.WriteLine($"No ajustas a lo solicitado, " +
                    $"ya que tienes {customerContext.Residue} " +
                    $"y quieres gastar {amount}");
            }
        }
    }
}
