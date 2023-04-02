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
        public void CheckoutReceivesNullItemReturnsZero()
        {
            //Arrange
            var checkout = new Checkout();
            var skuNull = new Sku { Name = ""};

            //Act
            checkout.Scan(skuNull);
            var result = checkout.GetTotal();

            //Assert
            Assert.That(result, Is.EqualTo(0));
        }

        [Test]
        public void CheckoutReceivesSingleItemAndReturnsPrice()
        {

            //Arrange
            var checkout = new Checkout();
            var skuA = new Sku { Name = "A", Price = 50 };

            //Act
            checkout.Scan(skuA);
            var result = checkout.GetTotal();

            //Assert
            Assert.That(skuA.Price, Is.EqualTo(result));
        }

        [Test]
        public void CheckoutReceivesMultipleItemsWithoutDiscountAndReturnsPrice()
        {
            //Arrange
            var expected = 80;
            var checkout = new Checkout();
            var skuA = new Sku { Name = "A", Price = 50 };
            var skuB = new Sku { Name = "B", Price = 30 };

            //Act
            checkout.Scan(skuA);
            checkout.Scan(skuB);
            var total = checkout.GetTotal();

            //Assert
            Assert.That(expected, Is.EqualTo(total));
        }

        [Test]
        public void CheckoutScansThreeAsAndGetsDiscount()
        {
            //Arrange
            var checkout = new Checkout();
            var result = 130;

            //Act
            checkout.Scan(new Sku { Name = "A", Price = 50 });
            checkout.Scan(new Sku { Name = "A", Price = 50 });
            checkout.Scan(new Sku { Name = "A", Price = 50 });
            var total = checkout.GetTotal();

            //Assert
            Assert.That(result, Is.EqualTo(total));

        }
    }
}