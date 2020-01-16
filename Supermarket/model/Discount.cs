namespace Supermarket.model
{
    public class Discount
    {
        public Discount(Product product, string description, double discountAmount)
        {
            Product = product;
            Description = description;
            DiscountAmount = discountAmount;
        }

        public Product Product { get; }
        public string Description { get; }
        public double DiscountAmount { get; }

    }
}
