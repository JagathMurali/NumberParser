using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using NumberParser;
using NumberParser.Controllers;
using NumberParser.Models;
using NumberParser.ServiceClass.Interface;

namespace NumberParser.Tests.Controllers
{
    [TestClass]
    public class ValuesControllerTest
    {
       

        [TestMethod]
        public void CheckingWhetherPostCallReturnsWithCorrectStringForaValidData()
        {
            // Arrange
            string numberInWord = "ONE HUNDRED AND TWENTY-THREE DOLLARS AND FORTY-FIVE CENTS";
            Mock<INumberToWordsService> mockService = new Mock<INumberToWordsService>();            
            mockService.Setup(mock => mock.ConvertNumberToString(It.IsAny<decimal>())).Returns(numberInWord);
            ValuesController controller = new ValuesController(mockService.Object);
            UserDetails userData = new UserDetails();
            userData.Name = "John Smith";
            userData.Number = "123.45";

            // Act
            var result = controller.SubmitValues(userData);

            // Assert
            Assert.AreEqual(userData.Name, result.Name);
            Assert.AreEqual(numberInWord, result.NumberInWords);
        }

        [TestMethod]
        public void CheckingWhetherPostCallReturnsWithCorrectStringForanInvalidData()
        {
            // Arrange
            string numberInWord = "INCORRECT";
            Mock<INumberToWordsService> mockService = new Mock<INumberToWordsService>();           
            ValuesController controller = new ValuesController(mockService.Object);
            UserDetails userData = new UserDetails();
            userData.Name = "John Smith";
            userData.Number = "123.45.5";

            // Act
            var result = controller.SubmitValues(userData);

            // Assert
            Assert.AreEqual(userData.Name, result.Name);
            Assert.AreEqual(numberInWord, result.NumberInWords);
        }

        [TestMethod]
        public void CheckingWhetherExpectionIsHappenedForInAppropriateData()
        {
            // Arrange
            string numberInWord = "NOT PROCESSED.";
            Mock<INumberToWordsService> mockService = new Mock<INumberToWordsService>();
            ValuesController controller = new ValuesController(mockService.Object);
            mockService.Setup(mock => mock.ConvertNumberToString(It.IsAny<decimal>())).Throws(new Exception());
            UserDetails userData = new UserDetails();
            userData.Name = "John Smith";
            userData.Number = "123.34";

            // Act
            var result = controller.SubmitValues(userData);

            // Assert
            Assert.AreEqual(userData.Name, result.Name);
            Assert.AreEqual(numberInWord, result.NumberInWords);
        }
    }
}
