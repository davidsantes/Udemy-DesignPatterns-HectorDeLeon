using System;
using DesignPatterns.Otros.UnitOfWork;
using DesignPatterns._1._0._Creacionales.Factory;
using DesignPatterns._1._0._Creacionales.Singleton;
using DesignPatterns._4._0._Otros.DependencyInjection;
using DesignPatterns._4._0._Otros.Repository.Models;
using DesignPatterns._4._0._Otros.Repository;
using DesignPatterns._3._0._Comportamiento.Strategy;
using DesignPatterns._1._0._Creacionales.Builder;

namespace DesignPatterns
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("******************* INICIO PATRONES CREACIONALES *******************" + Environment.NewLine);

            #region Singleton            

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

            #endregion Singleton

            #region Factory

            Console.WriteLine(". INICIO PATRÓN FACTORY");

            SaleFactory storeSaleFactory = new StoreSaleFactory(10);
            SaleFactory internetSaleFactory = new InternetSaleFactory(2);

            var productPrice = 15;
            ISale storeSale = storeSaleFactory.GetSale();
            storeSale.Sell(productPrice);
            ISale internetSale = internetSaleFactory.GetSale();
            internetSale.Sell(productPrice);

            Console.WriteLine(". FIN PATRÓN FACTORY" + Environment.NewLine);

            #endregion Factory

            #region Builder

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

            #endregion Builder

            Console.WriteLine("******************* FIN PATRONES CREACIONALES *******************");

            Console.WriteLine("******************* INICIO PATRONES ESTRUCTURALES *******************" + Environment.NewLine);

            Console.WriteLine("******************* FIN PATRONES ESTRUCTURALES *******************" + Environment.NewLine);

            Console.WriteLine("******************* INICIO PATRONES COMPORTAMIENTO *******************" + Environment.NewLine);

            #region Strategy            

            Console.WriteLine(". INICIO PATRÓN STRATEGY");

            var strategyContext = new StrategyContext(new CarStrategy());
            strategyContext.Run();
            strategyContext.Strategy = new MotoStrategy();
            strategyContext.Run();

            Console.WriteLine(". FIN PATRÓN STRATEGY" + Environment.NewLine);

            #endregion Strategy

            Console.WriteLine("******************* FIN PATRONES COMPORTAMIENTO *******************" + Environment.NewLine);
            
            Console.WriteLine("******************* INICIO PATRONES OTROS *******************" + Environment.NewLine);

            #region DependencyInjection

            Console.WriteLine(". INICIO PATRÓN FACTORY");

            var beer = new Beer("Amstel", "Amstel brand");
            var drinkWithBeer = new DrinkWithBeerDi(10, 1, beer);
            drinkWithBeer.Build();

            Console.WriteLine(". FIN PATRÓN FACTORY" + Environment.NewLine);

            #endregion DependencyInjection

            #region Repository

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

            #endregion Repository

            #region UnitOfWork

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

            #endregion UnitOfWork

            Console.WriteLine("******************* FIN PATRONES OTROS *******************");
        }
    }
}
