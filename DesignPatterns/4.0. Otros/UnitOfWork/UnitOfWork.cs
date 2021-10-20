using DesignPatterns._4._0._Otros.Repository;
using DesignPatterns._4._0._Otros.Repository.Models;

namespace DesignPatterns.Otros.UnitOfWork
{
    /// <summary>
    /// Agrupa todos los repositorios
    /// </summary>
    public class UnitOfWork : IUnitOfWork
    {
        private InventoryDbContext _context;
        public IRepository <Category> _categories;
        public IRepository<Product> _products;

        public IRepository<Category> Categories
        {
            get
            {
                return _categories == null ?
                    _categories = new Repository<Category>(_context) :
                    _categories;
            }
        }
        public IRepository<Product> Products
        {
            get
            {
                return _products == null ?
                    _products = new Repository<Product>(_context) :
                    _products;
            }
        }

        public UnitOfWork(InventoryDbContext context)
        {
            _context = context;
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
