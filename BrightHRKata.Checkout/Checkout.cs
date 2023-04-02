using BrightHRKata.Checkout;

namespace BrightHRKataCheckout.Tests
{
    public class Checkout
    {
        public int Scan(Sku item)
        {
            if (item == null) 
            {
                return 0;
            }

            return item.Price;
        }
    }
}