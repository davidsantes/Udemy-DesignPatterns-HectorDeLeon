using DesignPatternsInAsp.Models.ViewModels;
using DesignPatternsInAsp.Repository.UnitOfWork;

namespace DesignPatternsInAsp.Strategies
{
    public class ProductContext : IProductStrategy
    {
        private IProductStrategy _strategy;
        public IProductStrategy Strategy
        {
            set {
                _strategy = value;
            }
        }

        public ProductContext(IProductStrategy strategy)
        {
            _strategy = strategy;
        }

        public void Add(FormProductViewModel formProductVm, IUnitOfWork unitOfWork)
        {
            _strategy.Add(formProductVm, unitOfWork);
        }
    }
}
