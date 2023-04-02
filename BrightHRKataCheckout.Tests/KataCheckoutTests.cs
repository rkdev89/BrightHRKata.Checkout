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
    }
}