using BrightHRKata.Checkout;

namespace BrightHRKataCheckout.Tests
{
    public class Checkout
    {
        private readonly List<Sku> _itemsList;

        public Checkout()
        {
            _itemsList = new List<Sku>();
        }

        public void Scan(Sku item)
        {
            if (item == null) 
            {
                throw new ArgumentNullException(item.Name);
            }

            _itemsList.Add(item);
        }

        public int GetTotal()
        {
            return _itemsList.Sum(sku => sku.Price);
        }
    }
}