using System;
using System.Collections.Generic;
using Supermarket.model;

namespace Supermarket.UnitTests
{
    public class FakeCatalog : ISupermarketCatalog
    {
        private readonly Dictionary<String, Product> products = new Dictionary<string, Product>();
        private readonly Dictionary<String, double> prices = new Dictionary<string, double>();

        public void AddProduct(Product product, double price)
        {
             this.products.Add(product.Name, product);
            this.prices.Add(product.Name, price);
        }

        public double GetUnitPrice(Product product)
        {
            return this.prices[product.Name];
        }
    }
}
