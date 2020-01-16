using System.Collections.Generic;

namespace Supermarket.model
{
    public class Receipt
    {
        public Receipt()
        {
            this.Items = new List<ReceiptItem>();
            this.Discounts = new List<Discount>();           
        }

        public List<ReceiptItem> Items { get; }
        public List<Discount> Discounts { get; }

        public double TotalPrice
        {
            get
            {
                double total = 0;
                foreach (var item in this.Items)
                {
                    total += item.TotalPrice;
                }

                foreach (var discount in this.Discounts)
                {
                    total -= discount.DiscountAmount;
                }

                return total;
            }
        }

        public void AddProduct(Product p, double quantity, double price, double totalPrice)
        {
            this.Items.Add(new ReceiptItem(p, quantity,price,totalPrice));
        }

        public void AddDiscount(Discount discount)
        {
            this.Discounts.Add(discount);
        }
    }
}
