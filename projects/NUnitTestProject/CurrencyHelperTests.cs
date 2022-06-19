using NUnit.Framework;
using System;
using System.Collections.Generic;
using TwojeWesele.Services.Helpers;

namespace NUnitTestProject
{
    public class CurrencyHelperTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void FormatToDoubleTest()
        {
            // Arrange 
            var price = "2.00 z³";
            var expected = 2.0;
            var currencyHelper = new CurrencyHelper();

            // Act
            var priceDecimal = currencyHelper.FormatToDouble(price);

            // Assert
            Assert.That(priceDecimal, Is.EqualTo(expected));
        }

        [TestCase(3.15, "3.15 z³")]
        [TestCase(-2.23, "-2.23 z³")]
        [TestCase(0.672, "0.67 z³")]
        [TestCase(123.212, "123.21 z³")]

        public void FormatToDecimalTest(double price, string expected)
        {
            // Arrange 
            var currencyHelper = new CurrencyHelper();

            // Act
            var priceString = currencyHelper.FormatToString(price);

            // Assert
            Assert.That(priceString, Is.EqualTo(expected));
            var actual = "";

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test, TestCaseSource(nameof(TestData100)), Category("Category100")]
        public void FormatToStringTest100(double price, string expected)
        {
            // Arrange 
            var currencyHelper = new CurrencyHelper();

            // Act
            var priceString = currencyHelper.FormatToString(price);

            // Assert
            Assert.That(priceString, Is.EqualTo(expected));
        }

        [Test, TestCaseSource(nameof(TestData1000)), Category("Category1000")]
        public void FormatToStringTest1000(double price, string expected)
        {
            // Arrange 
            var currencyHelper = new CurrencyHelper();

            // Act
            var priceString = currencyHelper.FormatToString(price);

            // Assert
            Assert.That(priceString, Is.EqualTo(expected));
        }

        [Test, TestCaseSource(nameof(TestData10000)), Category("Category10000")]
        public void FormatToStringTest10000(double price, string expected)
        {
            // Arrange 
            var currencyHelper = new CurrencyHelper();

            // Act
            var priceString = currencyHelper.FormatToString(price);

            // Assert
            Assert.That(priceString, Is.EqualTo(expected));
        }

        public static List<object[]> TestData100() => TestData(100);
        public static List<object[]> TestData1000() => TestData(1000);
        public static List<object[]> TestData10000() => TestData(10000);

        public static List<object[]> TestData(int testCaseCount)
        {
            var seed = 1231;

            var data = new List<object[]>();
            var random = new Random(seed);

            for (int i = 0; i < testCaseCount; i++)
            {
                var randomValue = random.NextDouble() * random.Next(100000);

                data.Add(new object[]
                {
                    randomValue,
                    randomValue.ToString("F2") + " z³"
                });
            }

            return data;
        }
    }
}