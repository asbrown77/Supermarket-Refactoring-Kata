namespace Supermarket.model
{
    public class ProductQuantity
    {
        public ProductQuantity(Product product, double quantity)
        {
            Product = product;
            Quantity = quantity;
        }

        public Product Product { get; }
        public double Quantity { get;}
    }
}
