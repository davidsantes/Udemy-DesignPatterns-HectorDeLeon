using DesignPatternsInAsp.Models.Data;
using DesignPatternsInAsp.Models.ViewModels;
using DesignPatternsInAsp.Repository.UnitOfWork;
using DesignPatternsInAsp.Strategies;
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
            GetCategoriesData();
            return View();
        }

        [HttpPost]
        public IActionResult Add(FormProductViewModel formProductVm)
        {
            //Si no es válido, regresa a la vista de get, pero con los datos rellenados
            if (!ModelState.IsValid)
            {
                GetCategoriesData();
                return View("Add", formProductVm);
            }

            //Diferente estrategia si existe la marca o no:
            var context = string.IsNullOrEmpty(formProductVm.CategoryId) ?
                new ProductContext(new ProductWithoutCategoryStrategy()) :
                new ProductContext(new ProductWithCategoryStrategy());
            context.Add(formProductVm, _unitOfWork);

            return RedirectToAction("Index");
        }

        #region HELPERS

        /// <summary>
        /// Retorna al ViewBag las categorías
        /// </summary>
        private void GetCategoriesData()
        {
            var categories = _unitOfWork.Categories.Get();
            ViewBag.Categories = new SelectList(categories, "CategoryId", "CategoryName");
        }

        #endregion HELPERS
    }
}
