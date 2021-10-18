using DesignPatternsInAsp.Models.Data;
using DesignPatternsInAsp.Models.ViewModels;
using DesignPatternsInAsp.Repository.UnitOfWork;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;

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

        [HttpGet]
        public IActionResult Add()
        {
            var categories = _unitOfWork.Categories.Get();
            ViewBag.Categories = new SelectList(categories, "CategoryId", "CategoryName");
            return View();
        }

        [HttpPost]
        public IActionResult Add(FormProductViewModel formProductVm)
        {
            //Si no es válido, regresa a la vista de get, pero con los datos rellenados
            if (!ModelState.IsValid)
            {
                var categories = _unitOfWork.Categories.Get();
                ViewBag.Categories = new SelectList(categories, "CategoryId", "CategoryName");
                return View("Add", formProductVm);
            }

            var newProduct = new Product
            {
                ProductId = formProductVm.ProductId,
                ProductName = formProductVm.ProductName,
                ProductDescription = formProductVm.ProductDescription,
            };

            //Si no existe la marca, se crea
            if (string.IsNullOrEmpty(formProductVm.CategoryId))
            {
                var newCategory = new Category
                {
                    CategoryId = Guid.NewGuid().ToString(),
                    CategoryName = $"{"Categoría - "}{formProductVm.ProductName}"
                };

                newProduct.CategoryId = newCategory.CategoryId;
                _unitOfWork.Categories.Add(newCategory);
            }
            else
            {
                newProduct.CategoryId = formProductVm.CategoryId;
            }

            _unitOfWork.Products.Add(newProduct);
            _unitOfWork.Save();

            return RedirectToAction("Index");
        }
    }
}
