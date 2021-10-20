using DesignPatternsInAsp.Models.ViewModels;
using DesignPatternsInAsp.Repository.UnitOfWork;

namespace DesignPatternsInAsp.Strategies
{
    public interface IProductStrategy
    {
        public void Add(FormProductViewModel formProductVm, IUnitOfWork unitOfWork);
    }
}
