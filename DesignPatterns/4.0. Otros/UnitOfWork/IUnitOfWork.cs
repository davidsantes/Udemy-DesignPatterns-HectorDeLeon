using DesignPatterns._4._0._Otros.Repository;
using DesignPatterns._4._0._Otros.Repository.Models;

namespace DesignPatterns.Otros.UnitOfWork
{
    public interface IUnitOfWork
    {
        public IRepository<Category> Categories { get; }
        public IRepository<Product> Products { get; }
        public void Save();
    }
}
