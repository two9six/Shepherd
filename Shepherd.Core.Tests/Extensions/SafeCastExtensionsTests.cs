using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shepherd.Core.Extensions;

namespace Shepherd.Core.Tests.Extensions
{
    [TestClass]
    public class SafeCastExtensionsTests
    {
        [TestMethod]
        public void ToSafeInt_UsingValidStringInt_ReturnsValidInt()
        {
            //Arrange
            var testValue = "1";
            var expectedResult = 1;

            //Act
            var actualResult = testValue.ToSafeInt();


            //Assert
            Assert.AreEqual(expectedResult, actualResult);

        }

        [TestMethod]
        public void ToSafeInt_UsingInvalidStringInt_ReturnsZero()
        {
            //Arrange
            var testValue = "jayson";
            var expectedResult = 0;

            //Act
            var actualResult = testValue.ToSafeInt();

            //Assert
            Assert.AreEqual(expectedResult, actualResult);

        }

        [TestMethod]
        public void ToSafeDateTime_UsingValidStringDateTime_ReturnsValidDateTime()
        { 
            //Arrange
            var testValue = "10/24/1991";
            var expectedResult = new DateTime(1991, 10, 24);

            //Act
            var actualResult = testValue.ToSafeDateTime();

            //Assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void ToSafeDateTime_UsingInvalidStringDateTime_ReturnsDateTimeMin()
        { 
            //Arrange
            var testValue = "jayson";
            var expectedResult = DateTime.MinValue;

            //Act
            var actualResult = testValue.ToSafeDateTime();

            //Assert
            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}
