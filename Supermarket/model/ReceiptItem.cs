using System;

namespace Supermarket.model
{
    public class ReceiptItem : IEquatable<ReceiptItem>
    {
        public ReceiptItem(Product p, double quantity, double price, double totalPrice)
        {
            Product = p;
            Quantity = quantity;
            Price = price;
            TotalPrice = totalPrice;
        }

        public Product Product { get; private set; }
        public double Quantity { get; private set; }
        public double Price { get; private set; }
        public double TotalPrice { get; private set; }

        public bool Equals(ReceiptItem other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Equals(Product, other.Product) && Quantity.Equals(other.Quantity) && Price.Equals(other.Price) && TotalPrice.Equals(other.TotalPrice);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((ReceiptItem) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = (Product != null ? Product.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ Quantity.GetHashCode();
                hashCode = (hashCode * 397) ^ Price.GetHashCode();
                hashCode = (hashCode * 397) ^ TotalPrice.GetHashCode();
                return hashCode;
            }
        }
    }
}