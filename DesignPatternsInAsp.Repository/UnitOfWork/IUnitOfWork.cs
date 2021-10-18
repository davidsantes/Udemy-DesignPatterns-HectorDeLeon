using DesignPatternsInAsp.Models.Data;
using DesignPatternsInAsp.Repository.Repository;

namespace DesignPatternsInAsp.Repository.UnitOfWork
{
    public interface IUnitOfWork
    {
        public IRepository<Category> Categories { get; }
        public IRepository<Product> Products { get; }
        public void Save();
    }
}
