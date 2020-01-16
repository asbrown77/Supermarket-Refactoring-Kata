using System.Collections.Generic;
using Supermarket.model;

public class ShoppingCart
{
    private List<ProductQuantity> items = new List<ProductQuantity>();
    private Dictionary<Product, double> productQuantities = new Dictionary<Product, double>();

    public List<ProductQuantity> Items
    {
        get { return items; }
    }

    public Dictionary<Product, double> ProductQuantities
    {
        get { return productQuantities; }
    }

    public void AddItem(Product product)
    {
        this.AddItem(product, 1);
    }

    public void AddItem(Product product, double quantity)
    {
        items.Add(new ProductQuantity(product, quantity));
        if (productQuantities.ContainsKey(product))
        {
            productQuantities.Add(product, productQuantities[product] + quantity);
        }
        else
        {
            productQuantities.Add(product, quantity);
        }
    }

    public void HandleOffers(Receipt receipt, Dictionary<Product, Offer> offers, ISupermarketCatalog catalog)
    {
        foreach (var p in productQuantities.Keys)
        {
            double quantity = productQuantities[p];
            if (offers.ContainsKey(p))
            {
                var offer = offers[p];
                var unitPrice = catalog.GetUnitPrice(p);
                var quantityAsInt = (int) quantity;
                Discount discount = null;
                int x = 1;

                if (offer.OfferType == SpecialOfferType.ThreeForTwo)
                {
                    x = 3;
                }
                else if (offer.OfferType == SpecialOfferType.TwoForAmount)
                {
                    x = 2;
                    if (quantityAsInt >= 2)
                    {
                        var total = offer.Argument * (quantityAsInt / x) + quantityAsInt % 2 * unitPrice;
                        var discountN = unitPrice * quantity - total;
                        discount = new Discount(p, "2 for " + offer.Argument,discountN);
                    }
                }
                if (offer.OfferType == SpecialOfferType.FiveForAmount)
                {
                    x = 5;
                }
                int numberOfXs = quantityAsInt / x;
                if (offer.OfferType == SpecialOfferType.ThreeForTwo && quantityAsInt > 2)
                {
                    var discountAmount = quantity * unitPrice -
                                        ((numberOfXs * 2 * unitPrice) + quantityAsInt % 3 * unitPrice);
                    discount = new Discount(p, "3 for 2", discountAmount);
                }
                if (offer.OfferType == SpecialOfferType.TenPercentDiscount)
                {
                    discount = new Discount(p, offer.Argument + "% off", quantity * unitPrice * offer.Argument /100.00);
                }
                if (offer.OfferType == SpecialOfferType.FiveForAmount && quantityAsInt >= 5)
                {
                    var discountTotal = unitPrice * quantity -
                                        (offer.Argument * numberOfXs + quantityAsInt % 5 * unitPrice);
                    discount = new Discount(p,x + " for " + offer.Argument, discountTotal);
                }
                if (discount != null)
                    receipt.AddDiscount(discount);
            }
        }
    }
}