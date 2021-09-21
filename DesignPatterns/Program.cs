using DesignPatterns.Creacionales.Factory;
using DesignPatterns.Creacionales.Singleton;
using System;

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
        }
    }
}
