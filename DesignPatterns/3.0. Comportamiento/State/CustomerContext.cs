using DesignPatterns._3._0._Comportamiento.State.ConcreteStates;

namespace DesignPatterns._3._0._Comportamiento.State
{
    public class CustomerContext
    {
        private IState _state;
        public decimal Residue { get; set; }

        public CustomerContext()
        {
            _state = new ConcreteStateNew();
        }

        public void SetState(IState state) => _state = state;
        public IState GetState() => _state;

        public void Request(decimal amount) => _state.Handle(this, amount);
        public void Discount(decimal amount) => Residue -= amount;
    }
}
