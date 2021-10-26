using DesignPatternsInAsp.Repository.UnitOfWork;
using DesignPatternsInAsp.Tools.Generator;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DesignPatternsInAsp.Controllers
{
    public class GeneratorFileController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly GeneratorConcreteBuilder _generatorConcreteBuilder;

        public GeneratorFileController(IUnitOfWork unitOfWork, GeneratorConcreteBuilder generatorConcreteBuilder)
        {
            _unitOfWork = unitOfWork;
            _generatorConcreteBuilder = generatorConcreteBuilder;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult CreateFile(int optionFile)
        {
            //Todo este código debería estar en una capa de servicio
            try
            {
                var products = _unitOfWork.Products.Get();
                List<string> content = products.Select(d => d.ProductName).ToList();
                string path = "file" + DateTime.Now.Ticks + new Random().Next(1000) + ".txt";
                var generatorDirector = new GeneratorDirector(_generatorConcreteBuilder);

                if (optionFile == 1)
                {
                    generatorDirector.CreateSimpleJsonGenerator(content, path);
                }
                else
                {
                    generatorDirector.CreateSimplePipeGenerator(content, path);
                }

                var generator = _generatorConcreteBuilder.GetGenerator();
                generator.Save();

                return Json("Archivo generado");
            }
            catch (Exception ex)
            {
                return BadRequest();
            }            
        }
    }
}
