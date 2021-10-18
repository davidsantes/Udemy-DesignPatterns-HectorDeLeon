using DesignPatterns.Creacionales.Factory;
using DesignPatterns.Creacionales.Singleton;
using DesignPatterns.Otros.DependencyInjection;
using DesignPatterns.Otros.Repository.Models;
using System;
using DesignPatterns.Otros.Repository;

namespace DesignPatterns
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("******************* INICIO PATRONES CREACIONALES *******************" + Environment.NewLine);

            #region Singleton            

            Console.WriteLine("01. INICIO PATRÓN SINGLETON");

            var singletonA = SingletonDefinition.Instance;
            var singletonB = SingletonDefinition.Instance;
            //Verifico si ambos objetos son la misma instancia
            bool esMismaInstancia = singletonA == singletonB;
            Console.WriteLine("Es la misma instancia: " + esMismaInstancia);

            //Aplicación más práctica del Singleton
            var log = Log.Instance;
            log.Save("Esto es un mensaje para ver cómo funciona un log de tipo Singleton");
            
            Console.WriteLine("01. FIN PATRÓN SINGLETON" + Environment.NewLine);            

            #endregion Singleton

            #region Factory

            Console.WriteLine("02. INICIO PATRÓN FACTORY");

            SaleFactory storeSaleFactory = new StoreSaleFactory(10);
            SaleFactory internetSaleFactory = new InternetSaleFactory(2);

            var productPrice = 15;
            ISale storeSale = storeSaleFactory.GetSale();
            storeSale.Sell(productPrice);
            ISale internetSale = internetSaleFactory.GetSale();
            internetSale.Sell(productPrice);

            Console.WriteLine("02. FIN PATRÓN FACTORY" + Environment.NewLine);

            #endregion Factory

            Console.WriteLine("******************* FIN PATRONES CREACIONALES *******************");

            Console.WriteLine("******************* INICIO PATRONES ESTRUCTURALES *******************" + Environment.NewLine);

            #region Repository

            Console.WriteLine("03. INICIO PATRÓN REPOSITORY");

            using (var context = new InventoryDbContext()) {
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

            Console.WriteLine("03. FIN PATRÓN REPOSITORY" + Environment.NewLine);

            #endregion Repository

            Console.WriteLine("******************* FIN PATRONES ESTRUCTURALES *******************" + Environment.NewLine);

            Console.WriteLine("******************* INICIO PATRONES OTROS *******************" + Environment.NewLine);

            #region DependencyInjection

            Console.WriteLine("04. INICIO PATRÓN FACTORY");

            var beer = new Beer("Amstel", "Amstel brand");
            var drinkWithBeer = new DrinkWithBeerDi(10, 1, beer);
            drinkWithBeer.Build();

            Console.WriteLine("04. FIN PATRÓN FACTORY" + Environment.NewLine);

            #endregion DependencyInjection

            Console.WriteLine("******************* FIN PATRONES OTROS *******************");
        }
    }
}
