using DesignPatternsInAsp.Tools.Factory;
using Microsoft.AspNetCore.Mvc;

namespace DesignPatternsInAsp.Controllers
{
    public class ProductDetailController : Controller
    {
        private readonly EarnFactory _localEarnFactory;
        private readonly EarnFactory _foreignEarnFactory;
        
        public ProductDetailController(LocalEarnFactory localEarnFactory, ForeignEarnFactory foreignEarnFactory)
        {
            _localEarnFactory = localEarnFactory;
            _foreignEarnFactory = foreignEarnFactory;
        }

        /// <summary>
        /// Indexes the specified total.
        /// Para llamar al controlado hay que poner en la ruta: /ProductDetail/?total=200
        /// </summary>
        /// <param name="total">The total.</param>
        /// <returns></returns>
        public IActionResult Index(decimal total)
        {
            // Products
            var localEarn = _localEarnFactory.GetEarn();
            var foreignEarn = _foreignEarnFactory.GetEarn();

            //Total
            ViewBag.totalLocal = total + localEarn.Earn(total);
            ViewBag.totalForeign = total + foreignEarn.Earn(total);

            return View();
        }
    }
}
