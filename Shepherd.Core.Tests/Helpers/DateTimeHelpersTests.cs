using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shepherd.Core.Helpers;

namespace Shepherd.Core.Tests.Helpers
{
	[TestClass]
	public class DateTimeHelpersTests
	{
		[TestMethod]
		public void ComputeAge_UsingValidDate_Calculates()
		{
			// arrange
			var expected = 30;
			var testValue = DateTime.Today.AddYears((expected * -1));

			// act
			var actual = DateTimeHelpers.ComputeAge(testValue);

			// assert
			Assert.AreEqual(expected, actual);
		}
	}
}
