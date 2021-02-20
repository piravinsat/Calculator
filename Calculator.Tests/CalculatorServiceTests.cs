using System.ComponentModel.DataAnnotations;
using NUnit.Framework;
using Calculator.Services;

namespace Calculator.Tests
{
    [TestFixture]
    public class CalculatorServiceTests
    {
        private ICalculatorService _service;

        [SetUp]
        public void Setup()
        {
            //Arrange
            _service = new CalculatorService();
        }

        [Test]
        public void Check_NUNit_Works()
        {
            Assert.Pass();
        }

        [Test]
        public void Add_EmptyString_ReturnZero()
        {
            //Act
            var result = _service.Add("");

            //Assert
            Assert.AreEqual(0, result);
        }

        [Test]
        public void Add_0_ReturnZero()
        {
            //Act
            var result = _service.Add("0");

            //Assert
            Assert.AreEqual(0, result);
        }

        [Test]
        public void Add_1_ReturnOne()
        {
            //Act
            var result = _service.Add("1");

            //Assert
            Assert.AreEqual(1, result);
        }


        [TestCase("64", 64)]
        [TestCase("30", 30)]
        public void Add_Any_Number_Return(string numbers, int expected)
        {
            //Act
            var result = _service.Add(numbers);

            //Assert
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void Add_Any_Two_Numbers_Return()
        {
            //Act
            var result = _service.Add("1,2");

            //Assert
            Assert.AreEqual(3, result);
        }

        [Test]
        public void Add_Any_Three_Numbers_Return()
        {
            var result = _service.Add("1,2,3");

            Assert.AreEqual(6, result);
        }
    }
}
