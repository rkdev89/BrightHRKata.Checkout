using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrightHRKata.Checkout.Services
{
    public class ValidSkus
    {
        public List<Sku> SkuList { get; }
        public ValidSkus()
        {
            SkuList = new List<Sku>
            {
                new Sku{Name = "A", Price = 50},
                new Sku{Name = "B", Price = 30},
                new Sku{Name = "C", Price = 20},
                new Sku{Name = "D", Price = 15},
            };
        }
    }
}
