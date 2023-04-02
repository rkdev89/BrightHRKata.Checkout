namespace BrightHRKataCheckout.Tests
{
    public class KataCheckoutTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        [TestCase("",0)]
        public void CheckoutReceivesEmptyStringReturnsZero(string item, int price)
        {
            //Arrange
            var checkout = new Checkout();

            //Act
            checkout.Scan(item);

            //Assert
            Assert.That(price, Is.EqualTo(0));
        }

        [Test]
        [TestCase("A", 50)]
        [TestCase("B", 30)]
        [TestCase("C", 20)]
        [TestCase("D", 15)]
        public void CheckoutReceivesSingleItemAndReturnsPrice(string item, int price)
        {
            //Arrange
            var checkout = new Checkout();

            //Act
           var result = checkout.Scan(item);

            //Assert
            Assert.That(price, Is.EqualTo(result));
        }
    }
}