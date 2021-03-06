﻿using NUnit.Framework;
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
            //Act
            var result = _service.Add("1,2,3");

            //Assert
            Assert.AreEqual(6, result);
        }

        [Test]
        public void Add_Any_Three_Numbers_Return_Different_Delimiter()
        {
            //Act
            var result = _service.Add("1\n2,3");

            //Assert
            Assert.AreEqual(6, result);
        }

        [Test]
        public void Add_Any_Two_Numbers_Return_Multiple_Delimiters()
        {
            //Act
            var result = _service.Add("//;\n1;2");

            //Assert
            Assert.AreEqual(3, result);
        }

        [Test]
        public void Throw_Exception_When_Negative_Number_Given()
        {
            Assert.Throws<NegativeNumberException>(
                () => { _service.Add("2,-2"); });
        }

        [Test]
        public void CheckAddMethodRunOnce()
        {
            //Act
            _service.Add("1,2");
            //Assert
            Assert.AreEqual(1, _service.GetAddCalledCount());
        }

        [Test]
        public void CheckAddMethodRunTwice()
        {
            //Act
            _service.Add("1,2");
            _service.Add("3,5");
            //Assert
            Assert.AreEqual(2, _service.GetAddCalledCount());
        }

        [Test]
        public void IgnoreNumbersOverAThousand()
        {
            //Act
           var result = _service.Add("1;1001");
            //Assert
            Assert.AreEqual(1, result);
        }

        [Test]
        public void Subtract_EmptyString_ReturnZero()
        {
            //Act
            var result = _service.Subtract("");

            //Assert
            Assert.AreEqual(0, result);
        }


        [Test]
        public void Subtract_0_ReturnZero()
        {
            //Act
            var result = _service.Subtract("0");

            //Assert
            Assert.AreEqual(0, result);
        }

        [Test]
        public void Subtract_1_ReturnOne()
        {
            //Act
            var result = _service.Subtract("1");

            //Assert
            Assert.AreEqual(1, result);
        }

        [TestCase("99", 99)]
        [TestCase("66", 66)]
        public void Subtract_Any_Number_Return(string numbers, int expected)
        {
            //Act
            var result = _service.Subtract(numbers);

            //Assert
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void Subtract_Any_Two_Numbers_Return()
        {
            //Act
            var result = _service.Subtract("2,1");

            //Assert
            Assert.AreEqual(1, result);
        }

        [Test]
        public void Subtract_Any_Three_Numbers_Return()
        {
            //Act
            var result = _service.Subtract("1,2,3");

            //Assert
            Assert.AreEqual(-4, result);
        }

        [Test]
        public void Subtract_Any_Three_Numbers_Return_Different_Delimiter()
        {
            //Act
            var result = _service.Subtract("1\n2,3");

            //Assert
            Assert.AreEqual(-4, result);
        }

        [Test]
        public void Subtract_Any_Two_Numbers_Return_Multiple_Delimiters()
        {
            //Act
            var result = _service.Subtract("//;\n1;2");

            //Assert
            Assert.AreEqual(-1, result);
        }
        [Test]
        public void CheckSubtractMethodRunOnce()
        {
            //Act
            _service.Subtract("1,2");
            _service.Add("1,2");
            //Assert
            Assert.AreEqual(1, _service.GetSubtractCalledCount());
        }

        [Test]
        public void CheckSubtractMethodRunTwice()
        {
            //Act
            _service.Subtract("1,2");
            _service.Subtract("3,5");
            //Assert
            Assert.AreEqual(2, _service.GetSubtractCalledCount());
        }

        [Test]
        public void Multiply_EmptyString_ReturnZero()
        {
            //Act
            var result = _service.Multiply("");

            //Assert
            Assert.AreEqual(0, result);
        }

        [Test]
        public void Multiply_0_ReturnZero()
        {
            //Act
            var result = _service.Multiply("0");

            //Assert
            Assert.AreEqual(0, result);
        }

        [Test]
        public void Multiply_1_ReturnOne()
        {
            //Act
            var result = _service.Multiply("1");

            //Assert
            Assert.AreEqual(1, result);
        }


        [TestCase("14", 14)]
        [TestCase("10", 10)]
        public void Multiply_Any_Number_Return(string numbers, int expected)
        {
            //Act
            var result = _service.Multiply(numbers);

            //Assert
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void Multiply_Any_Two_Numbers_Return()
        {
            //Act
            var result = _service.Multiply("1,2");

            //Assert
            Assert.AreEqual(2, result);
        }

        [Test]
        public void Multiply_Any_Three_Numbers_Return()
        {
            //Act
            var result = _service.Multiply("1,2,3");

            //Assert
            Assert.AreEqual(6, result);
        }

        [Test]
        public void Multiply_Any_Three_Numbers_Return_Different_Delimiter()
        {
            //Act
            var result = _service.Multiply("1\n2,3");

            //Assert
            Assert.AreEqual(6, result);
        }

        [Test]
        public void Multiply_Any_Two_Numbers_Return_Multiple_Delimiters()
        {
            //Act
            var result = _service.Multiply("//;\n1;2");

            //Assert
            Assert.AreEqual(2, result);
        }

        [Test]
        public void CheckMultiplyMethodRunOnce()
        {
            //Act
            _service.Multiply("1,2");
            //Assert
            Assert.AreEqual(1, _service.GetMultiplyCalledCount());
        }

        [Test]
        public void CheckMultiplyMethodRunTwice()
        {
            //Act
            _service.Multiply("1,2");
            _service.Multiply("3,5");
            //Assert
            Assert.AreEqual(2, _service.GetMultiplyCalledCount());
        }

        [Test]
        public void Divide_EmptyString_ReturnZero()
        {
            //Act
            var result = _service.Divide("");

            //Assert
            Assert.AreEqual(0, result);
        }

        [Test]
        public void Divide_0_ReturnZero()
        {
            //Act
            var result = _service.Divide("0");

            //Assert
            Assert.AreEqual(0, result);
        }

        [Test]
        public void Divide_1_ReturnOne()
        {
            //Act
            var result = _service.Divide("1");

            //Assert
            Assert.AreEqual(1, result);
        }


        [TestCase("64", 64)]
        [TestCase("30", 30)]
        public void Divide_Any_Number_Return(string numbers, int expected)
        {
            //Act
            var result = _service.Divide(numbers);

            //Assert
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void Divide_Any_Two_Numbers_Return()
        {
            //Act
            var result = _service.Divide("2,1");

            //Assert
            Assert.AreEqual(2, result);
        }

        [Test]
        public void Divide_Any_Three_Numbers_Return()
        {
            //Act
            var result = _service.Divide("32,2,2");

            //Assert
            Assert.AreEqual(8, result);
        }

        [Test]
        public void Divide_Any_Three_Numbers_Return_Different_Delimiter()
        {
            //Act
            var result = _service.Divide("1\n2,3");

            //Assert
            Assert.AreEqual(0, result);
        }

        [Test]
        public void Divide_Any_Two_Numbers_Return_Multiple_Delimiters()
        {
            //Act
            var result = _service.Divide("//;\n1;2");

            //Assert
            Assert.AreEqual(0, result);
        }

        [Test]
        public void CheckDivideMethodRunOnce()
        {
            //Act
            _service.Divide("1,2");
            //Assert
            Assert.AreEqual(1, _service.GetDivideCalledCount());
        }

        [Test]
        public void CheckDivideMethodRunTwice()
        {
            //Act
            _service.Divide("1,2");
            _service.Divide("3,5");
            //Assert
            Assert.AreEqual(2, _service.GetDivideCalledCount());
        }
    }
}
