using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shepherd.Core.Extensions;

namespace Shepherd.Core.Tests.Extensions
{
    [TestClass]
    public class SafeStringCastExtensionsTests
    {
        [TestMethod]
        public void TryGetString_UsingValidDateTime_ReturnsValidString()
        {
            //Arrange
            DateTime? testValue = new DateTime(1991, 10, 24);
            var expectedValue = "10/24/1991 12:00:00 AM";

            //Act
            var actualResult = testValue.TryGetString();

            //Assert
            Assert.AreEqual(expectedValue, actualResult);
        }

        [TestMethod]
        public void TryGetString_UsingNullDateTime_ReturnsEmptyString()
        {

            //Arrange
            DateTime? testValue = null;
            var expectedValue = String.Empty;

            //Act
            var actualResult = testValue.TryGetString();

            //Assert
            Assert.AreEqual(expectedValue, actualResult);

        }
    }
}
