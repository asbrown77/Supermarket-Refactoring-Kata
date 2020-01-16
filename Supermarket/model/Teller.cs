using System.Collections.Generic;

namespace Supermarket.model
{
    public class Teller
    {
        private ISupermarketCatalog catalog;
        private Dictionary<Product, Offer> offers = new Dictionary<Product, Offer>();

        public Teller(ISupermarketCatalog catalog)
        {
            this.catalog = catalog;
        }

        public void AddSpecialOffer(SpecialOfferType offerType, Product product, double argument)
        {
               this.offers.Add(product, new Offer(offerType, product, argument));
        }
        public Receipt ChecksOutArticlesFrom(ShoppingCart theCart)
        {
            var receipt = new Receipt();
            List<ProductQuantity> productQuantities = theCart.Items;

            foreach (var pq in productQuantities)
            {
                var p = pq.Product;
                var quantity = pq.Quantity;
                var unitPrice = this.catalog.GetUnitPrice(p);
                var price = quantity * unitPrice;
                receipt.AddProduct(p, quantity, unitPrice, price);
            }

            theCart.HandleOffers(receipt,this.offers, this.catalog);

            return receipt;
        }
    }
}
