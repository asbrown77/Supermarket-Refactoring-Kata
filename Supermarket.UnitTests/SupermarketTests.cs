using NUnit.Framework;
using Supermarket.model;

namespace Supermarket.UnitTests
{
    public class SupermarketTests
    {
        [Test]
        public void TenPercentDiscount()
        {
            var catalog = new FakeCatalog();
            var toothbrush = new Product("toothbrush", ProductUnitType.Each);
            catalog.AddProduct(toothbrush, 0.99);
            var apples = new Product("apples", ProductUnitType.Kilo);
            catalog.AddProduct(apples, 1.99);

            var teller = new Teller(catalog);
            teller.AddSpecialOffer(SpecialOfferType.TenPercentDiscount, toothbrush, 10.0);

            var cart = new ShoppingCart();
            cart.AddItem(apples, 2.5);

            var receipt = teller.ChecksOutArticlesFrom(cart);
       
            Assert.That(receipt.TotalPrice, Is.EqualTo(4.975).Within(0.01));
            Assert.IsEmpty(receipt.Discounts);
            Assert.That(receipt.Items.Count, Is.EqualTo(1));
            var receiptItem = receipt.Items[0];
            Assert.That(receiptItem.Product, Is.EqualTo(apples));
            Assert.That(receiptItem.Price, Is.EqualTo(1.99));
            Assert.That(receiptItem.TotalPrice, Is.EqualTo(2.5*1.99));
            Assert.That(receiptItem.Quantity, Is.EqualTo(2.5));
        }


    }
}
