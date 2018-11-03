using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NumberParser.ServiceClass;

namespace NumberParser.Tests.ServiceClass
{
    [TestClass]
    public class NumberToWordsServiceTest
    {
        [TestMethod]
        public void CheckWhetherTheFunctionReturnCorrectStringForaNumber()
        {
            // Arrange
            NumberToWordsService numberService = new NumberToWordsService();
            double value = 123.45;
            string numberInWord = "ONE HUNDRED AND TWENTY-THREE DOLLARS AND FORTY-FIVE CENTS";

            // Act
            string result = numberService.ConvertNumberToString(value);

            // Assert
            Assert.AreEqual(numberInWord, result);
        }

        [TestMethod]
        public void CheckWhetherTheFunctionReturnCorrectStringForaNumberWithDecimalOnly()
        {
            // Arrange
            NumberToWordsService numberService = new NumberToWordsService();
            double value = 0.45;
            string numberInWord = "ZERO DOLLARS AND FORTY-FIVE CENTS";

            // Act
            string result = numberService.ConvertNumberToString(value);

            // Assert
            Assert.AreEqual(numberInWord, result);
        }

        [TestMethod]
        public void CheckWhetherTheFunctionReturnCorrectStringForaNumberWithIntegerPartOnly()
        {
            // Arrange
            NumberToWordsService numberService = new NumberToWordsService();
            double value = 123.00;
            string numberInWord = "ONE HUNDRED AND TWENTY-THREE DOLLARS";

            // Act
            string result = numberService.ConvertNumberToString(value);

            // Assert
            Assert.AreEqual(numberInWord, result);
        }

        [TestMethod]
        public void CheckWhetherTheFunctionReturnZero()
        {
            // Arrange
            NumberToWordsService numberService = new NumberToWordsService();
            double value = 0.00;
            string numberInWord = "ZERO DOLLARS";

            // Act
            string result = numberService.ConvertNumberToString(value);

            // Assert
            Assert.AreEqual(numberInWord, result);
        }

        [TestMethod]
        public void CheckWhetherTheFunctionReturnNegativeNumber()
        {
            // Arrange
            NumberToWordsService numberService = new NumberToWordsService();
            double value = -123.45;
            string numberInWord = "NEGATIVE";

            // Act
            string result = numberService.ConvertNumberToString(value);

            // Assert
            Assert.AreEqual(numberInWord, result);
        }

    }
}
