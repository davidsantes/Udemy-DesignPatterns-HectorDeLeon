using DesignPatterns.Otros.Repository;
using DesignPatterns.Otros.Repository.Models;

namespace DesignPatterns.Otros.UnitOfWork
{
    public interface IUnitOfWork
    {
        public IRepository<Category> Categories { get; }
        public IRepository<Product> Products { get; }
        public void Save();
    }
}
