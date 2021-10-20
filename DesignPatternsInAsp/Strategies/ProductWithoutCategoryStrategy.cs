using DesignPatternsInAsp.Models.Data;
using DesignPatternsInAsp.Models.ViewModels;
using DesignPatternsInAsp.Repository.UnitOfWork;
using System;

namespace DesignPatternsInAsp.Strategies
{
    /// <summary>
    /// Cuando el producto tiene una categoría ya existente
    /// </summary>
    public class ProductWithoutCategoryStrategy : IProductStrategy
    {
        public void Add(FormProductViewModel formProductVm, IUnitOfWork unitOfWork)
        {
            var newProduct = new Product
            {
                ProductId = formProductVm.ProductId,
                ProductName = formProductVm.ProductName,
                ProductDescription = formProductVm.ProductDescription
            };

            var newCategory = new Category
            {
                CategoryId = Guid.NewGuid().ToString(),
                CategoryName = $"{"Categoría - "}{formProductVm.ProductName}"
            };

            newProduct.CategoryId = newCategory.CategoryId;

            unitOfWork.Categories.Add(newCategory);
            unitOfWork.Products.Add(newProduct);
            unitOfWork.Save();
        }
    }
}
