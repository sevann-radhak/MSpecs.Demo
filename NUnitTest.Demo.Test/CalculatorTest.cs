using NUnit.Framework;
using System;

namespace NUnitTest.Demo.Test
{
    [TestFixture]
    public class CalculatorTest
    {
        Calculator calc;

        [SetUp]
        public void Setup()
        {
            calc = new Calculator();
        }

        [TearDown]
        public void Teardown()
        {
            calc.Dispose();
        }

        [Test]
        public void Test_Addition_With_Valid_Integeres()
        {
            var result = calc.Addition(3, 5);
            Assert.AreEqual(8, result);
        }

        [Test, Order(1)]
        public void Test_Substraction_Argument_Exception()
        {
            Assert.Catch<ArgumentException>(() => calc.Substraction(3, 4));
        }

        [TestCase(0, 1, 1)]
        [TestCase(1, 1, 2)]
        [TestCase(1, 2, 3)]
        [TestCase(3, 2, 5)]
        [TestCase(0, 0, 0)]
        public void Test_Addition_Multiple(int first, int second, int result)
        {
            var calculated = calc.Addition(first, second);

            Assert.AreEqual(result, calculated);
        }

        [TestCase(0, true)]
        [TestCase(1, false)]
        [TestCase(2, true)]
        public void Test_Number_Is_Par(int number, bool response)
        {
            var isPar = calc.IsPar(number);
            Assert.AreEqual(isPar, response);

            Assert.Catch<FormatException>(() => calc.IsPar(Convert.ToInt32("")));
        }

        [Test]
        public void Test_Divide_By_Zero_Exception()
        {
            Assert.Catch<DivideByZeroException>(() => calc.Divide(5, 0));
        }

        [TestCase(9, 3, 3)]
        [TestCase(12, 4, 3)]
        [TestCase(0, 1, 0)]
        public void Test_Divide(int first, int second, int response)
        {
            var result = calc.Divide(first, second);
            Assert.AreEqual(result, response);
        }

        [Test]
        [Ignore("Ignore test")]
        public void Test_To_Ignore()
        {

        }
    }
}
