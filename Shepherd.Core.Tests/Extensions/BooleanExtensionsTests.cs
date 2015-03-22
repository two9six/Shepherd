using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shepherd.Core.Extensions;

namespace Shepherd.Core.Tests.Extensions
{
	[TestClass]
	public class BooleanExtensionsTests
	{
		[TestMethod]
		public void ToDisplayText_UsingTrue_ReturnsYes()
		{
			// arrange
			var testValue = true;
			var expectedResult = "Yes";

			// act
			var actualResult = testValue.ToDisplayText();

			// assert
			Assert.AreEqual(expectedResult, actualResult);
		}

		[TestMethod]
		public void ToDisplayText_UsingFalse_ReturnsNo()
		{
			// arrange
			var testValue = false;
			var expectedResult = "No";

			// act
			var actualResult = testValue.ToDisplayText();

			// assert
			Assert.AreEqual(expectedResult, actualResult);
		}

		[TestMethod]
		public void ToDisplayText_UsingNullableTrue_ReturnsYes()
		{
			// arrange
			bool? testValue = true;
			var expectedResult = "Yes";

			// act
			var actualResult = testValue.ToDisplayText();

			// assert
			Assert.AreEqual(expectedResult, actualResult);
		}

		[TestMethod]
		public void ToDisplayText_UsingNullableFalse_ReturnsNo()
		{
			// arrange
			bool? testValue = false;
			var expectedResult = "No";

			// act
			var actualResult = testValue.ToDisplayText();

			// assert
			Assert.AreEqual(expectedResult, actualResult);
		}

		[TestMethod]
		public void ToDisplayText_UsingNullBool_ReturnsEmptyString()
		{
			// arrange
			bool? testValue = null;
			var expectedResult = "";

			// act
			var actualResult = testValue.ToDisplayText();

			// assert
			Assert.AreEqual(expectedResult, actualResult);
		}
	}
}
