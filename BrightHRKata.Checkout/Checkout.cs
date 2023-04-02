using BrightHRKata.Checkout;
using System.Reflection.Metadata.Ecma335;

namespace BrightHRKataCheckout.Tests
{
    public class Checkout
    {
        private readonly List<Sku> _skuList;
        private readonly List<Discount> _discountList;

        public Checkout()
        {
            _skuList = new List<Sku>();
            _discountList = new List<Discount>();
        }

        public void Scan(Sku sku)
        {
            if (sku == null) 
            {
                throw new ArgumentNullException(nameof(sku));
            }

            _skuList.Add(sku);
        }

        public int GetTotal()
        {
            var grossTotal = _skuList.Sum(sku => sku.Price);
            var discountTotal = _discountList.Sum(disc => CalculateDiscount(disc, _skuList));

            return grossTotal - discountTotal;
        }

        public void AddDiscount(Discount discount)
        {
            _discountList.Add(discount);
        }

        public int CalculateDiscount(Discount discount, List<Sku> skus)
        {
            int countOfSkus = skus.Count(sku => sku.Name == discount.SkuName);
            return (countOfSkus / discount.Threshold) * discount.Value;
        }
    }
}