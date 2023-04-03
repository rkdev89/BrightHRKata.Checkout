using BrightHRKata.Checkout;
using BrightHRKata.Checkout.Services;
using System.Reflection.Metadata.Ecma335;

namespace BrightHRKataCheckout
{
    public class Checkout : ICheckout
    {
        private readonly ICollection<Sku> _skuList;
        private readonly ICollection<Discount> _discountList;
        private readonly ValidSkus _validSkus;

        public Checkout()
        {
            _validSkus = new ValidSkus();
            _skuList = new List<Sku>();
            _discountList = new List<Discount>();
        }

        public ICheckout Scan(Sku sku)
        {
            if (_validSkus.SkuList.Exists(s => s.Name == sku.Name && s.Price == sku.Price))
            { 
                _skuList.Add(sku);
            }
            return this;
        }

        public int GetTotal()
        {
            var grossTotal = _skuList.Sum(sku => sku.Price);
            var discountTotal = _discountList.Sum(disc => CalculateDiscount(disc, _skuList));

            return grossTotal - discountTotal;
        }

        public ICheckout AddDiscount(Discount discount)
        {
            _discountList.Add(discount);
            return this;
        }

        public int CalculateDiscount(Discount discount, ICollection<Sku> skus)
        {
            int countOfSkus = skus.Count(sku => sku.Name == discount.SkuName);
            return (countOfSkus / discount.Threshold) * discount.Value;
        }
    }
}