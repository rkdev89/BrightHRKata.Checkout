using BrightHRKata.Checkout;
using System.Reflection.Metadata.Ecma335;

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
                throw new ArgumentNullException(nameof(item));
            }

            _itemsList.Add(item);
        }

        public int GetTotal()
        {
            return _itemsList.Sum(sku => sku.Price);
        }

    }
}