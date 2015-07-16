using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shepherd.Core.Exceptions;
using Shepherd.Core.Helpers;
using Spackle;
using System.Collections.Generic;

namespace Shepherd.Core.Tests.Helpers
{
	[TestClass]
	public class DataValidatorHelperTests
	{
		[TestMethod]
		public void Validate_UsingValidData_ReturnsNoValidationErrors()
		{
			// Arrage
			var generator = new RandomObjectGenerator();

			var validationRules = new List<DataValidationRule>()
			{
				new DataValidationRule(generator.Generate<string>(), generator.Generate<string>(), true, typeof(string))
			};

			// Act
			DataValidatorHelper.ValidateFields(validationRules);
		}

		[TestMethod]
		[ExpectedException(typeof(RequiredDetailsException))]
		public void Validate_UsingNullRequiredField_ReturnsRequiredValidationError()
		{
			// Arrage
			var generator = new RandomObjectGenerator();
			var dataValidationRules = new List<DataValidationRule>()
			{
				new DataValidationRule(generator.Generate<string>(), null, true, typeof(string))
			};

			// Act
			DataValidatorHelper.ValidateFields(dataValidationRules);
		}

		[TestMethod]
		[ExpectedException(typeof(RequiredDetailsException))]
		public void Validate_UsingEmptyRequiredField_ReturnsRequiredValidationError()
		{
			// Arrage
			var generator = new RandomObjectGenerator();

			var dataValidationRules = new List<DataValidationRule>()
			{
				new DataValidationRule(generator.Generate<string>(), string.Empty, true, typeof(string))
			};

			// Act
			DataValidatorHelper.ValidateFields(dataValidationRules);
		}
	}
}