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

            //Act
            checkout.Scan(item);

            //Assert
            Assert.Fail();
        }
    }
}