
using NUnit.Framework;
using Supermarket.model;

namespace Supermarket.UnitTests
{
    [TestFixture]
    class WhenCheckingOutArticlesAtTheSupermarket
    {
        [Test]
        public void AnEmptyShoppingCart_ShouldCostNothing()
        {
            ISupermarketCatalog catalog = new FakeCatalog();
            var teller = new Teller(catalog);
            var theCart = new ShoppingCart();
            
            var receipt = teller.ChecksOutArticlesFrom(theCart);

            Assert.That(receipt.TotalPrice, Is.EqualTo(0.00));
        }
    }
}
