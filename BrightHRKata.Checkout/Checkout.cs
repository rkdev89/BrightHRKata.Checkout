using BrightHRKata.Checkout;
using BrightHRKata.Checkout.Services;
using System.Reflection.Metadata.Ecma335;

namespace BrightHRKataCheckout.Tests
{
    public class Checkout
    {
        private readonly List<Sku> _skuList;
        private readonly List<Discount> _discountList;
        private readonly ValidSkus _validSkus;

        public Checkout()
        {
            _validSkus = new ValidSkus();
            _skuList = new List<Sku>();
            _discountList = new List<Discount>();
        }

        public void Scan(Sku sku)
        {
            if (_validSkus.SkuList.Exists(s => s.Name == sku.Name && s.Price == sku.Price))
            { 
                _skuList.Add(sku);
            }
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