using BrightHRKata.Checkout;

namespace BrightHRKataCheckout
{
    public interface ICheckout
    {
        ICheckout Scan(Sku sku);
        int GetTotal();
    }
}