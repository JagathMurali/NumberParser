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
            decimal value = 123.45M;
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
            decimal value = 0.45M;
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
            decimal value = 123.00M;
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
            decimal value = 0.00M;
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
            decimal value = -123.45M;
            string numberInWord = "NEGATIVE VALUE";

            // Act
            string result = numberService.ConvertNumberToString(value);

            // Assert
            Assert.AreEqual(numberInWord, result);
        }

    }
}
