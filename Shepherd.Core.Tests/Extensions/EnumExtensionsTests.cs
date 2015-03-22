using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shepherd.Core.Extensions;
using System.Linq;

namespace Shepherd.Core.Tests.Extensions
{
	[TestClass]
	public class EnumExtensionsTests
	{
		[TestMethod]
		public void ToInt_UsingEnum1_ReturnsInt1()
		{
			// Arrange
			TestEnum testEnum = TestEnum.Enum1;
			var expectedValue = 1;

			// Act
			var actualValue = testEnum.ToInt();

			//Assert
			Assert.AreEqual(expectedValue, actualValue);
		}

		[TestMethod]
		public void GetValues_WithTwoEnumValues_ReturnsTwoValues()
		{
			// Arrange
			TestEnum testEnum = TestEnum.Enum1;
			var expectedCount = 2;

			// Act
			var values = testEnum.GetValues();

			//Assert
			Assert.AreEqual(expectedCount, values.ToList().Count);
		}

		public enum TestEnum
		{
			Enum1 = 1,
			Enum2 = 2
		}
	}
}