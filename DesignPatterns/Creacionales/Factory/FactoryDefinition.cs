using System;

namespace DesignPatterns.Creacionales.Factory
{
    /// <summary>
    /// Creator
    /// </summary>
    public abstract class SaleFactory
    {
        public abstract ISale GetSale();
    }

    /// <summary>
    /// ConcreteCreator
    /// </summary>
    /// <seealso cref="DesignPatterns.Creacionales.Factory.SaleFactory" />
    public class StoreSaleFactory : SaleFactory
    {
        private readonly decimal _extra;

        public StoreSaleFactory(decimal extra)
        {
            _extra = extra;
        }

        public override ISale GetSale()
        {
            return new StoreSale(_extra);
        }
    }

    /// <summary>
    /// ConcreteCreator
    /// </summary>
    /// <seealso cref="DesignPatterns.Creacionales.Factory.SaleFactory" />
    public class InternetSaleFactory : SaleFactory
    {
        private readonly decimal _discountForInternetSale;

        public InternetSaleFactory(decimal discountForInternetSale)
        {
            _discountForInternetSale = discountForInternetSale;
        }

        public override ISale GetSale()
        {
            return new InternetSale(_discountForInternetSale);
        }
    }

    /// <summary>
    /// ConcreteProduct
    /// </summary>
    /// <seealso cref="DesignPatterns.Creacionales.Factory.ISale" />
    public class StoreSale : ISale 
    {
        private readonly decimal _extraForStoreSale;

        public StoreSale(decimal extraForStoreSale) {
            _extraForStoreSale = extraForStoreSale;
        }

        public void Sell(decimal total)
        {
            Console.WriteLine($"La venta en la TIENDA tiene un total de {total + _extraForStoreSale}");
        }
    }

    /// <summary>
    /// ConcreteProduct
    /// </summary>
    /// <seealso cref="DesignPatterns.Creacionales.Factory.ISale" />
    public class InternetSale : ISale
    {
        private readonly decimal _discountForInternetSale;

        public InternetSale(decimal discountForInternetSale)
        {
            _discountForInternetSale = discountForInternetSale;
        }

        public void Sell(decimal total)
        {
            Console.WriteLine($"La venta en INTERNET tiene un total de {total - _discountForInternetSale}");
        }
    }

    /// <summary>
    /// Product
    /// </summary>
    public interface ISale
    {
        public void Sell(decimal total);
    }
}
