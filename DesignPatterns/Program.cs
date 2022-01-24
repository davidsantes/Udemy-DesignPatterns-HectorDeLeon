using DesignPatterns._1._0._Creacionales.Builder;
using DesignPatterns._1._0._Creacionales.Factory;
using DesignPatterns._1._0._Creacionales.Singleton;
using DesignPatterns._3._0._Comportamiento.State;
using DesignPatterns._3._0._Comportamiento.Strategy;
using DesignPatterns._4._0._Otros.DependencyInjection;
using DesignPatterns._4._0._Otros.Repository;
using DesignPatterns._4._0._Otros.Repository.Models;
using DesignPatterns.Otros.UnitOfWork;
using System;

namespace DesignPatterns
{
    internal class Program
    {
        private static void PatronSingletonEjecutar()
        {
            Console.WriteLine(". INICIO PATRÓN SINGLETON");

            var singletonA = SingletonDefinition.Instance;
            var singletonB = SingletonDefinition.Instance;
            //Verifico si ambos objetos son la misma instancia
            bool esMismaInstancia = singletonA == singletonB;
            Console.WriteLine("Es la misma instancia: " + esMismaInstancia);

            //Aplicación más práctica del Singleton
            var log = Log.Instance;
            log.Save("Esto es un mensaje para ver cómo funciona un log de tipo Singleton");

            Console.WriteLine(". FIN PATRÓN SINGLETON" + Environment.NewLine);
        }

        private static void Main(string[] args)
        {
            bool _ejecutarPatronSingleton = false;
            bool _ejecutarPatronFactory = false;
            bool _ejecutarPatronBuilder = false;
            bool _ejecutarPatronStrategy = false;
            bool _ejecutarPatronState = true;
            bool _ejecutarPatronDependencyInjection = false;
            bool _ejecutarPatronRepository = false;
            bool _ejecutarPatronUnitOfWork = false;

            Console.WriteLine("******************* INICIO PATRONES CREACIONALES *******************" + Environment.NewLine);

            if (_ejecutarPatronSingleton)
            {
                PatronSingletonEjecutar();
            }

            if (_ejecutarPatronFactory)
            {
                PatronFactoryEjecutar();
            }

            if (_ejecutarPatronBuilder)
            {
                PatronBuilderEjecutar();
            }

            Console.WriteLine("******************* FIN PATRONES CREACIONALES *******************");

            Console.WriteLine("******************* INICIO PATRONES ESTRUCTURALES *******************" + Environment.NewLine);

            Console.WriteLine("******************* FIN PATRONES ESTRUCTURALES *******************" + Environment.NewLine);

            Console.WriteLine("******************* INICIO PATRONES COMPORTAMIENTO *******************" + Environment.NewLine);

            if (_ejecutarPatronStrategy)
            {
                PatronStrategyEjecutar();
            }

            if (_ejecutarPatronState)
            {
                PatronStateEjecutar();
            }

            Console.WriteLine("******************* FIN PATRONES COMPORTAMIENTO *******************" + Environment.NewLine);

            Console.WriteLine("******************* INICIO PATRONES OTROS *******************" + Environment.NewLine);

            if (_ejecutarPatronDependencyInjection)
            {
                PatronDependencyInjectionEjecutar();
            }

            if (_ejecutarPatronRepository)
            {
                PatronRepositoryEjecutar();
            }

            if (_ejecutarPatronUnitOfWork)
            {
                PatronUnitOfWorkEjecutar();
            }

            Console.WriteLine("******************* FIN PATRONES OTROS *******************");
        }

        private static void PatronFactoryEjecutar()
        {
            Console.WriteLine(". INICIO PATRÓN FACTORY");

            SaleFactory storeSaleFactory = new StoreSaleFactory(10);
            SaleFactory internetSaleFactory = new InternetSaleFactory(2);

            var productPrice = 15;
            ISale storeSale = storeSaleFactory.GetSale();
            storeSale.Sell(productPrice);
            ISale internetSale = internetSaleFactory.GetSale();
            internetSale.Sell(productPrice);

            Console.WriteLine(". FIN PATRÓN FACTORY" + Environment.NewLine);
        }

        private static void PatronBuilderEjecutar()
        {
            Console.WriteLine(". INICIO PATRÓN BUILDER");

            var builder = new PreparedAlcoholicDrinkConcreteBuilder();
            var barmanDirector = new BarmanDirector(builder);

            barmanDirector.PreparedMargarita();
            var preparedMargaritaDrink = builder.GetPreparedDrink();
            Console.WriteLine(preparedMargaritaDrink.Result);

            barmanDirector.PreparedPiñaColada();
            var preparedPiñaColadaDrink = builder.GetPreparedDrink();
            Console.WriteLine(preparedPiñaColadaDrink.Result);

            Console.WriteLine(". FIN PATRÓN BUILDER" + Environment.NewLine);
        }

        private static void PatronStrategyEjecutar()
        {
            Console.WriteLine(". INICIO PATRÓN STRATEGY");

            var strategyContext = new StrategyContext(new CarStrategy());
            strategyContext.Run();
            strategyContext.Strategy = new MotoStrategy();
            strategyContext.Run();

            Console.WriteLine(". FIN PATRÓN STRATEGY" + Environment.NewLine);
        }

        private static void PatronStateEjecutar()
        {
            Console.WriteLine(". INICIO PATRÓN STATE");

            var customerContext = new CustomerContext();
            Console.WriteLine($"Estado inicial: {customerContext.GetState()}");
            customerContext.Request(100);
            Console.WriteLine($"Estado tras introducir una cantidad de saldo: {customerContext.GetState()}");
            customerContext.Request(50);
            Console.WriteLine($"Estado tras bajar la cantidad de saldo: {customerContext.GetState()}");
            customerContext.Request(100);
            Console.WriteLine($"Estado tras bajar la cantidad de saldo a algo no permitido: {customerContext.GetState()}");
            customerContext.Request(50);
            Console.WriteLine($"Estado tras bajar la cantidad de saldo: {customerContext.GetState()}");
            customerContext.Request(50);
            Console.WriteLine($"Estado tras bajar la cantidad de saldo: {customerContext.GetState()}");

            Console.WriteLine(". FIN PATRÓN STATE" + Environment.NewLine);
        }

        private static void PatronDependencyInjectionEjecutar()
        {
            Console.WriteLine(". INICIO PATRÓN DEPENDENCY INJECTION");

            var beer = new Beer("Amstel", "Amstel brand");
            var drinkWithBeer = new DrinkWithBeerDi(10, 1, beer);
            drinkWithBeer.Build();

            Console.WriteLine(". FIN PATRÓN DEPENDENCY INJECTION" + Environment.NewLine);
        }

        private static void PatronRepositoryEjecutar()
        {
            Console.WriteLine(". INICIO PATRÓN REPOSITORY");

            using (var context = new InventoryDbContext())
            {
                var categoryRepository = new Repository<Category>(context);

                var newCategory = new Category
                {
                    CategoryId = "testId",
                    CategoryName = "testName"
                };
                categoryRepository.Add(newCategory);
                categoryRepository.Save();

                var categoryList = categoryRepository.Get();
                foreach (var category in categoryList)
                {
                    Console.WriteLine($"{category.CategoryId}{"-"}{category.CategoryName}");
                }
                categoryRepository.Delete("testId");
                categoryRepository.Save();
            }

            Console.WriteLine(". FIN PATRÓN REPOSITORY" + Environment.NewLine);
        }

        private static void PatronUnitOfWorkEjecutar()
        {
            Console.WriteLine(". INICIO PATRÓN UnitOfWork");

            using (var context = new InventoryDbContext())
            {
                var unitOfWork = new UnitOfWork(context);

                var categories = unitOfWork.Categories;
                var newCategory = new Category
                {
                    CategoryId = "testIdCategory" + Guid.NewGuid().ToString(),
                    CategoryName = "testNameCategory"
                };
                categories.Add(newCategory);

                var products = unitOfWork.Products;
                var newProduct = new Product
                {
                    ProductId = "TestId" + Guid.NewGuid().ToString(),
                    ProductName = "TestName",
                    ProductDescription = "TestDescription",
                    CategoryId = newCategory.CategoryId
                };
                products.Add(newProduct);

                //Realiza todas las operaciones en una sola solicitud, sin hacer varias conexiones a BDD
                unitOfWork.Save();
            }

            Console.WriteLine(". FIN PATRÓN UnitOfWork" + Environment.NewLine);
        }
    }
}