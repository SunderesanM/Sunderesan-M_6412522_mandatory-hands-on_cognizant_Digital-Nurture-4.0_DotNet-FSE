using System;
using NUnit.Framework;
using CalcLibrary;

namespace CalcLibrary.Tests
{
    [TestFixture]
    public class UnitTest1
    {

        private SimpleCalculator _calc;
        [SetUp]
        [Test]
        public void setup()
        {
            _calc = new SimpleCalculator();
        }

        [TearDown]
        public void TearDown()
        {
            _calc.AllClear();
        }

        [Test]
        [TestCase(10.0, 7.0, ExpectedResult = 17.0)]
        [TestCase(1.0, 0.7, ExpectedResult = 1.7)]

        public double AdditionTest(double a, double b)
        {
            return _calc.Addition(a, b);
        }

        [Test]
        public void GetResultTest()
        {
            _calc.Addition(20.0, 5.0);
            NUnit.Framework.Assert.That(_calc.GetResult, Is.EqualTo(25.0));

            _calc.Subtraction(20.0, 3.0);
            NUnit.Framework.Assert.That(_calc.GetResult, Is.EqualTo(17.0));
        }

        [Test]
        public void AllClearTest()
        {
            _calc.Multiplication(10.0, 7.0);
            NUnit.Framework.Assert.That(_calc.GetResult, Is.EqualTo(70.0));
            _calc.AllClear();
            NUnit.Framework.Assert.That(_calc.GetResult, Is.EqualTo(0.0));
        }
    }
}
