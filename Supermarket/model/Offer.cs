namespace Supermarket.model
{
    public class Offer
    {
        public SpecialOfferType OfferType; 
        public double Argument;

        public Offer(SpecialOfferType offerType, Product product, double argument)
        {
            OfferType = offerType;
            Argument = argument;
            Product = product;
        }
        public Product Product { get;}
    }
}
