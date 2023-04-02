namespace BrightHRKataCheckout.Tests
{
    public class Checkout
    {
        public Checkout()
        {
        }

        public int Scan(String item)
        {
            if (item == null) 
            {
                return 0;
            }
            return 1;
        }
    }
}