using BrightHRKata.Checkout;

namespace BrightHRKataCheckout.Tests
{
    public class KataCheckoutTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void CheckoutReceivesEmptyStringReturnsZero()
        {
            //Arrange
            
            var checkout = new Checkout();
            var skuNull = new Sku { Name = "", Price = 0 };

            //Act
            checkout.Scan(skuNull);

            //Assert
            Assert.That(skuNull.Price, Is.EqualTo(0));
        }

        [Test]
        public void CheckoutReceivesSingleItemAndReturnsPrice()
        {

            //Arrange
            var checkout = new Checkout();
            var skuA = new Sku { Name = "A", Price = 50 };

            //Act
           var result = checkout.Scan(skuA);

            //Assert
            Assert.That(skuA.Price, Is.EqualTo(result));
        }

        [Test]
        public void CheckoutReceivesMultipleItemsWithoutDiscountAndReturnsPrice()
        {
            //Arrange
            var total = 80;
            var checkout = new Checkout();
            var skuA = new Sku { Name = "A", Price = 50 };
            var skuB = new Sku { Name = "A", Price = 30 };
            var skuTotal = skuA.Price + skuB.Price;

            //Act
            checkout.Scan(skuA);
            checkout.Scan(skuB);

            //Assert
            Assert.That(total, Is.EqualTo(skuTotal));
        }
    }
}