namespace DesignPatterns._3._0._Comportamiento.Strategy
{
    public class StrategyContext
    {
        private IStrategy _strategy;
        
        /// <summary>
        /// Permite cambiar en modo de ejecución la estrategia, para que se comporte
        /// como coche o como moto
        /// </summary>
        public IStrategy Strategy
        {
            set
            {
                _strategy = value;
            }
        }

        public StrategyContext(IStrategy strategy)
        {
            _strategy = strategy;
        }

        public void Run()
        {
            _strategy.Run();
        }
    }
}
