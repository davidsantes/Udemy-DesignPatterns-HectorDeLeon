using DesignPatternsInAsp.Models.ViewModels;
using DesignPatternsInAsp.Repository.UnitOfWork;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesignPatternsInAsp.Controllers
{
    public class ProductController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProductController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            IEnumerable<ProductViewModel> products = from d in _unitOfWork.Products.Get()
                                                     select new ProductViewModel
                                                     {
                                                         ProductId = d.ProductId,
                                                         ProductName = d.ProductName,
                                                         ProductDescription = d.ProductDescription,
                                                         CategoryId = d.CategoryId
                                                     };

            return View("Index", products);
        }
    }
}
