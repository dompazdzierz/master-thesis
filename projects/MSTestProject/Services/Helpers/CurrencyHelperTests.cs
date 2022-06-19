using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TwojeWesele.Services.Helpers.Tests
{
    [TestClass()]
    public class CurrencyHelperTests

    {
        [TestMethod]
        public void FormatToDoubleTest()
        {
            // Arrange 
            var price = "2.00 zł";
            var expected = 2.0;
            var currencyHelper = new CurrencyHelper();

            // Act
            var priceDecimal = currencyHelper.FormatToDouble(price);

            // Assert
            Assert.AreEqual(expected, priceDecimal);
        }

        [DataTestMethod]
        [DataRow(3.15, "3.15 zł")]
        [DataRow(-2.23, "-2.23 zł")]
        [DataRow(0.672, "0.67 zł")]
        [DataRow(123.212, "123.21 zł")]
        public void FormatToDecimalTest(double price, string expected)
        {
            // Arrange 
            var currencyHelper = new CurrencyHelper();

            // Act
            var priceString = currencyHelper.FormatToString(price);

            // Assert
            Assert.AreEqual(priceString, expected);
        }

        [DynamicData(nameof(TestData100), DynamicDataSourceType.Method)]
        [TestMethod, TestCategory("Category100")]
        public void FormatToStringTest100(double price, string expected)
        {
            // Arrange 
            var currencyHelper = new CurrencyHelper();

            // Act
            var priceString = currencyHelper.FormatToString(price);

            // Assert
            Assert.AreEqual(priceString, expected);
        }

        [DynamicData(nameof(TestData1000), DynamicDataSourceType.Method)]
        [TestMethod, TestCategory("Category1000")]
        public void FormatToStringTest1000(double price, string expected)
        {
            // Arrange 
            var currencyHelper = new CurrencyHelper();

            // Act
            var priceString = currencyHelper.FormatToString(price);

            // Assert
            Assert.AreEqual(priceString, expected);
        }

        [DynamicData(nameof(TestData10000), DynamicDataSourceType.Method)]
        [TestMethod, TestCategory("Category10000")]
        public void FormatToStringTest10000(double price, string expected)
        {
            // Arrange 
            var currencyHelper = new CurrencyHelper();

            // Act
            var priceString = currencyHelper.FormatToString(price);

            // Assert
            Assert.AreEqual(priceString, expected);
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
                    randomValue.ToString("F2") + " zł"
                });
            }

            return data;
        }
    }
}