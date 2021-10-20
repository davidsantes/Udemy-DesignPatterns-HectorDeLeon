using DesignPatternsInAsp.Models.Data;
using DesignPatternsInAsp.Models.ViewModels;
using DesignPatternsInAsp.Repository.UnitOfWork;

namespace DesignPatternsInAsp.Strategies
{
    /// <summary>
    /// Cuando el producto tiene una categoría ya existente
    /// </summary>
    public class ProductWithCategoryStrategy : IProductStrategy
    {
        public void Add(FormProductViewModel formProductVm, IUnitOfWork unitOfWork)
        {
            var newProduct = new Product
            {
                ProductId = formProductVm.ProductId,
                ProductName = formProductVm.ProductName,
                ProductDescription = formProductVm.ProductDescription,
                CategoryId = formProductVm.CategoryId
            };

            unitOfWork.Products.Add(newProduct);
            unitOfWork.Save();
        }
    }
}
