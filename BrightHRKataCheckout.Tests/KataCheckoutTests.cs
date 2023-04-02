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
            var price = 0;
            var checkout = new Checkout();
            var skuNull = new Sku { Name = "", Price = 0 };

            //Act
            checkout.Scan(skuNull);

            //Assert
            Assert.That(price, Is.EqualTo(0));
        }

        [Test]
        public void CheckoutReceivesSingleItemAndReturnsPrice()
        {

            //Arrange
            var price = 50;
            var checkout = new Checkout();
            var skuA = new Sku { Name = "A", Price = 50 };

            //Act
           var result = checkout.Scan(skuA);

            //Assert
            Assert.That(price, Is.EqualTo(result));
        }

        [Test]
        public void CheckoutReceivesMultipleItemsWithoutDiscountAndReturnsPrice()
        {
            Assert.Fail();
        }
    }
}