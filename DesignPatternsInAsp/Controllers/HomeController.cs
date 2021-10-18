using DesignPatternsInAsp.Configuration;
using DesignPatternsInAsp.Models.Data;
using DesignPatternsInAsp.Models.ViewModels;
using DesignPatternsInAsp.Repository.Repository;
using DesignPatternsInAsp.Tools.Singleton;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Diagnostics;

namespace DesignPatternsInAsp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IOptions<MyCustomConfig> _config;
        private readonly IRepository<Category> _repository;

        public HomeController(IOptions<MyCustomConfig> config, IRepository<Category> repository)
        {
            _config = config;
            _repository = repository;
        }

        public IActionResult Index()
        {
            Log.GetInstance(_config.Value.PathLog).Save("Entró a Index");

            IEnumerable<Category> categoryList = _repository.Get();

            return View("Index", categoryList);
        }

        public IActionResult Privacy()
        {
            Log.GetInstance(_config.Value.PathLog).Save("Entró a Privacy");
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
