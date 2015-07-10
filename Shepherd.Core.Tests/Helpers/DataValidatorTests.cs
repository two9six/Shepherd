using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shepherd.Core.Helpers;
using Spackle;
using System.Collections.Generic;
using System.Linq;

namespace Shepherd.Core.Tests.Helpers
{
	[TestClass]
	public class DataValidatorTests
	{
		[TestMethod]
		public void Validate_UsingValidData_ReturnsNoValidationErrors()
		{
			// Arrage
			var generator = new RandomObjectGenerator();
			var expectedErrors = 0;

			var validationRules = new List<DataValidationRule>()
			{
				new DataValidationRule(generator.Generate<string>(), generator.Generate<string>(), true, typeof(string))
			};

			// Act
			var result = new DataValidator().Validate(validationRules);

			// Assert
			Assert.AreEqual(expectedErrors, result.Count());
		}

		[TestMethod]
		public void Validate_UsingEmptyOrNullRequiredField_ReturnsRequiredValidationError()
		{
			// Arrage
			var generator = new RandomObjectGenerator();
			var expectedErrors = 2;
			var dataValidationRules = new List<DataValidationRule>()
			{
				new DataValidationRule(generator.Generate<string>(), string.Empty, true, typeof(string)),
				new DataValidationRule(generator.Generate<string>(), null, true, typeof(string))
			};

			// Act
			var result = new DataValidator().Validate(dataValidationRules);

			// Assert
			Assert.AreEqual(expectedErrors, result.Count());
			Assert.AreEqual(string.Format(DataValidator.DataValidatorMessages.Required, dataValidationRules[0].MemberName),
				result.ElementAt(0));
			Assert.AreEqual(string.Format(DataValidator.DataValidatorMessages.Required, dataValidationRules[1].MemberName),
				result.ElementAt(1));
		}

		[TestMethod]
		public void Validate_UsingValidInt_ReturnsNoValidationErrors()
		{
			// Arrage
			var generator = new RandomObjectGenerator();
			var expectedErrors = 0;
			var dataValidationRules = new List<DataValidationRule>()
			{
				new DataValidationRule(generator.Generate<string>(), generator.Generate<int>().ToString(), true, typeof(int))
			};

			// Act
			var result = new DataValidator().Validate(dataValidationRules);

			// Assert
			Assert.AreEqual(expectedErrors, result.Count());
		}

		[TestMethod]
		public void Validate_UsingInvalidInt_ReturnsInvalidValidationError()
		{
			// Arrage
			var generator = new RandomObjectGenerator();
			var expectedErrors = 1;
			var dataValidationRules = new List<DataValidationRule>()
			{
				new DataValidationRule(generator.Generate<string>(), generator.Generate<string>(), true, typeof(int))
			};

			// Act
			var result = new DataValidator().Validate(dataValidationRules);

			// Assert
			Assert.AreEqual(expectedErrors, result.Count());
			Assert.AreEqual(string.Format(DataValidator.DataValidatorMessages.InvalidType, dataValidationRules[0].MemberName, dataValidationRules[0].DataType),
				result.ElementAt(0));
		}
	}
}