using System;
using System.Text;
using Supermarket.model;

namespace Supermarket
{
    public class ReceiptPrinter
    {
        private int columns;

        public ReceiptPrinter(int columns = 40)
        {
            this.columns = columns;
        }


        public string PrintReceipt(Receipt receipt)
        {
            var result = new StringBuilder();
            foreach (var item in receipt.Items)
            {
                var receiptItem = presentReceiptItem(item);
                result.Append(receiptItem);
            }

            foreach (var discount in receipt.Discounts)
            {
                string discountPresentation = presentDiscount(discount);
                result.Append(discountPresentation);
            }

            result.Append("\n");
            result.Append(presentTotal(receipt));
            return result.ToString();
        }

        private string presentTotal(Receipt receipt)
        {
            var name = "Total";
            var value = presentPrice(receipt.TotalPrice);
            return formatLineWithWhiteSpace(name, value);
        }

        private string presentDiscount(Discount discount)
        {
            var name = discount.Description + "(" + discount.Product.Name + ")";
            var value = "-" + presentPrice(discount.DiscountAmount);

            return formatLineWithWhiteSpace(name, value);
        }

        private string presentReceiptItem(ReceiptItem item)
        {
            var totalPricePresentation = presentPrice(item.TotalPrice);
            var name = item.Product.Name;

            var line = formatLineWithWhiteSpace(name, totalPricePresentation);

            if (item.Quantity != 1)
            {
                line += "  " + presentPrice(item.Price) + " * " + presentQuantity(item) + "\n";
            }

            return line;
        }

        private string presentQuantity(ReceiptItem item)
        {
            foreach (var pu in (ProductUnitType[])Enum.GetValues(typeof(ProductUnitType)))
            {
                if(pu.Equals(item.Product.UnitType))
                    return String.Format("%x", (int)item.Quantity);
                else
                {
                    return String.Format("%.3f", item.Quantity);
                }
            }

            return "";
        }

        private string presentPrice(double price)
        {
            return String.Format("%.2f",price);
        }

        private string formatLineWithWhiteSpace(string name, string value)
        {
            var line = new StringBuilder();
            line.Append(name);
            int whitespaceSize = this.columns - name.Length - value.Length;
            for (int i = 0; i < whitespaceSize; i++)
            {
                line.Append(" ");
            }
            line.Append(value);
            line.Append('\n');
            return line.ToString();
        }
    }
}
