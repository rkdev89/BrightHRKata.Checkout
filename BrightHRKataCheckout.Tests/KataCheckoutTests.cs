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

            //Act
            checkout.Scan(new Sku { Name = "" });
            var result = checkout.GetTotal();

            //Assert
            Assert.That(result, Is.EqualTo(0));
        }

        [Test]
        public void CheckoutReceivesSingleItemAndReturnsPrice()
        {
            //Arrange
            var checkout = new Checkout();

            //Act
            checkout.Scan(new Sku { Name = "A", Price = 50 });
            var result = checkout.GetTotal();

            //Assert
            Assert.That(result, Is.EqualTo(50));
        }

        [Test]
        public void CheckoutReceivesMultipleItemsWithoutDiscountAndReturnsPrice()
        {
            //Arrange
            var checkout = new Checkout();

            //Act
            checkout
                .Scan(new Sku { Name = "A", Price = 50 })
                .Scan(new Sku { Name = "B", Price = 30 });

            var total = checkout.GetTotal();

            //Assert
            Assert.That(total, Is.EqualTo(80));
        }

        [Test]
        public void CheckoutScansThreeAsAndGetsDiscount()
        {
            //Arrange
            var checkout = new Checkout();

            //Act
            checkout.AddDiscount(new Discount { SkuName = "A", Threshold = 3, Value = 20});

            checkout
                .Scan(new Sku { Name = "A", Price = 50 })
                .Scan(new Sku { Name = "A", Price = 50 })
                .Scan(new Sku { Name = "A", Price = 50 });

            var total = checkout.GetTotal();

            //Assert
            Assert.That(total, Is.EqualTo(130));
        }

        [Test]
        public void CheckoutScansTwoBsAndAppliesADiscount()
        {
            //Arrange
            var checkout = new Checkout();

            //Act
            checkout.AddDiscount(new Discount { SkuName = "B", Threshold = 2, Value = 15 });

            checkout
                .Scan(new Sku { Name = "B", Price = 30 })
                .Scan(new Sku { Name = "B", Price = 30 });

            var total = checkout.GetTotal();

            //Assert
            Assert.That(total, Is.EqualTo(45));
        }

        [Test]
        public void CheckoutScansThreesAsAndTwoBsAndAppliesDiscountToBoth()
        {
            //Arrange
            var checkout = new Checkout();

            //Act
            checkout.AddDiscount(new Discount { SkuName = "A", Threshold = 3, Value = 20 });
            checkout.AddDiscount(new Discount { SkuName = "B", Threshold = 2, Value = 15 });

            checkout.Scan(new Sku { Name = "A", Price = 50 })
                    .Scan(new Sku { Name = "A", Price = 50 })
                    .Scan(new Sku { Name = "A", Price = 50 })
                    .Scan(new Sku { Name = "B", Price = 30 })
                    .Scan(new Sku { Name = "B", Price = 30 });

            var total = checkout.GetTotal();

            //Assert
            Assert.That(total, Is.EqualTo(175));
        }
    }
}