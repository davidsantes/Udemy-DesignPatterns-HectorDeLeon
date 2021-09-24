using DesignPatternsInAsp.Tools.Factory;
using Microsoft.AspNetCore.Mvc;

namespace DesignPatternsInAsp.Controllers
{
    public class ProductDetailController : Controller
    {
        /// <summary>
        /// Indexes the specified total.
        /// Para llamaro hay que poner en la ruta: /ProductDetail/?total=200
        /// </summary>
        /// <param name="total">The total.</param>
        /// <returns></returns>
        public IActionResult Index(decimal total)
        {
            // Factories
            LocalEarnFactory localEarnFactory = new LocalEarnFactory(0.20m);
            ForeignEarnFactory foreignEarnFactory = new ForeignEarnFactory(0.30m, 20);

            // Products
            var localEarn = localEarnFactory.GetEarn();
            var foreignEarn = foreignEarnFactory.GetEarn();

            //Total
            ViewBag.totalLocal = total + localEarn.Earn(total);
            ViewBag.totalForeign = total + foreignEarn.Earn(total);

            return View();
        }
    }
}
