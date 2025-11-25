using System;
using NUnit.Framework;

namespace TestProject7
{
    [TestFixture]
    public class CombinedTests
    {
        private const double DELTA = 1e-5;
        private Function _function;

        [SetUp]
        public void Setup()
        {
            _function = new Function();
        }

        // Модульные тесты для базовых функций
        [Test]
        public void Sin_Zero_ReturnsZero()
        {
            Assert.AreEqual(0.0, Maths.Sin(0), DELTA);
        }

        [Test]
        public void Sin_PiOver2_ReturnsOne()
        {
            Assert.AreEqual(1.0, Maths.Sin(Math.PI / 2), DELTA);
        }

        [Test]
        public void Sin_Pi_ReturnsZero()
        {
            Assert.AreEqual(0.0, Maths.Sin(Math.PI), DELTA);
        }

        [Test]
        public void Cos_Zero_ReturnsOne()
        {
            Assert.AreEqual(1.0, Maths.Cos(0), DELTA);
        }

        [Test]
        public void Cos_PiOver2_ReturnsZero()
        {
            Assert.AreEqual(0.0, Maths.Cos(Math.PI / 2), DELTA);
        }

        [Test]
        public void Cos_Pi_ReturnsMinusOne()
        {
            Assert.AreEqual(-1.0, Maths.Cos(Math.PI), DELTA);
        }

        [Test]
        public void Ln_One_ReturnsZero()
        {
            Assert.AreEqual(0.0, Maths.Ln(1), DELTA);
        }

        [Test]
        public void Ln_E_ReturnsOne()
        {
            Assert.AreEqual(1.0, Maths.Ln(Math.E), DELTA);
        }

        [Test]
        public void Ln_Zero_ThrowsException()
        {
            Assert.Throws<ArgumentException>(() => Maths.Ln(0));
        }

        [Test]
        public void Ln_Negative_ThrowsException()
        {
            Assert.Throws<ArgumentException>(() => Maths.Ln(-1));
        }

        [Test]
        public void Pow_PositiveExponent_ReturnsCorrectValue()
        {
            Assert.AreEqual(8.0, Maths.Pow(2, 3), DELTA);
            Assert.AreEqual(1.0, Maths.Pow(5, 0), DELTA);
        }

        [Test]
        public void Pow_NegativeExponent_ReturnsCorrectValue()
        {
            Assert.AreEqual(0.25, Maths.Pow(2, -2), DELTA);
        }

        [Test]
        public void Abs_Positive_ReturnsSameValue()
        {
            Assert.AreEqual(5.0, Maths.Abs(5.0), DELTA);
        }

        [Test]
        public void Abs_Negative_ReturnsPositiveValue()
        {
            Assert.AreEqual(5.0, Maths.Abs(-5.0), DELTA);
        }

        [Test]
        public void Factorial_ValidValues_ReturnsCorrectResult()
        {
            Assert.AreEqual(1, Maths.Factorial(0));
            Assert.AreEqual(1, Maths.Factorial(1));
            Assert.AreEqual(2, Maths.Factorial(2));
            Assert.AreEqual(6, Maths.Factorial(3));
            Assert.AreEqual(24, Maths.Factorial(4));
            Assert.AreEqual(120, Maths.Factorial(5));
        }

        [Test]
        public void Sqrt_ValidValues_ReturnsCorrectResult()
        {
            Assert.AreEqual(0.0, Maths.Sqrt(0), DELTA);
            Assert.AreEqual(1.0, Maths.Sqrt(1), DELTA);
            Assert.AreEqual(2.0, Maths.Sqrt(4), DELTA);
            Assert.AreEqual(3.0, Maths.Sqrt(9), DELTA);
        }

        [Test]
        public void Sqrt_Negative_ThrowsException()
        {
            Assert.Throws<ArgumentException>(() => Maths.Sqrt(-1));
        }

        // Интеграционные тесты для главной функции
        [Test]
        public void Execute_PositiveX_ReturnsCorrectValue()
        {
            // f(x) = (1 - cos(x)) / sin(x) для x > 0
            double x = Math.PI / 4;
            double expected = (1 - Maths.Cos(x)) / Maths.Sin(x);
            Assert.AreEqual(expected, _function.Execute(x), DELTA);
        }

        [Test]
        public void Execute_VariousPositiveValues_ReturnsCorrectResults(
            [Values(0.1, 0.5, 1.0, 1.3)] double x)
        {
            double expected = (1 - Maths.Cos(x)) / Maths.Sin(x);
            double actual = _function.Execute(x);
            Assert.AreEqual(expected, actual, DELTA);
        }

        [Test]
        public void Execute_VariousNegativeValues_ReturnsCorrectResults(
            [Values(-0.1, -0.5, -1.0, -2.0)] double x)
        {
            double sinValue = Maths.Sin(x);
            double lnAbsX = Maths.Ln(Maths.Abs(x));
            double cosLnValue = Maths.Cos(lnAbsX);
            double product = sinValue * cosLnValue;

            if (product >= 0)
            {
                double expected = Math.Sqrt(product);
                double actual = _function.Execute(x);
                Assert.AreEqual(expected, actual, DELTA);
            }
            else
            {
                Assert.Throws<ArithmeticException>(() => _function.Execute(x));
            }
        }

        [Test]
        public void Integration_AllFunctionsWorkTogether()
        {
            // Комплексный интеграционный тест
            double x = 0.7;

            // Проверяем работу всех базовых функций
            double sinResult = Maths.Sin(x);
            double cosResult = Maths.Cos(x);
            double lnResult = Maths.Ln(x);
            double absResult = Maths.Abs(x);

            // Проверяем корректность основных операций
            Assert.IsTrue(sinResult >= -1 && sinResult <= 1);
            Assert.IsTrue(cosResult >= -1 && cosResult <= 1);
            Assert.IsTrue(absResult >= 0);

            // Проверяем конечный результат основной функции
            double result = _function.Execute(x);
            Assert.IsNotNull(result);
            Assert.IsFalse(double.IsNaN(result));
            Assert.IsFalse(double.IsInfinity(result));
        }
    }
}