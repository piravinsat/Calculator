using NUnit.Framework;
using Calculator.Services;

namespace Calculator.Tests
{
    [TestFixture]
    public class CalculatorServiceTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Check_NUNit_Works()
        {
            Assert.Pass();
        }

        [Test]
        public void Add_EmptyString_ReturnZero()
        {
            //Arrange
            var service = new CalculatorService();

            //Act
            var result = service.Add("");

            //Assert
            Assert.AreEqual(0, result);
        }
    }
}
