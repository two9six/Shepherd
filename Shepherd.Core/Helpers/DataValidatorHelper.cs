using Shepherd.Core.Exceptions;
using System;
using System.Collections.Generic;

namespace Shepherd.Core.Helpers
{
	public sealed class DataValidatorHelper
	{
		public static void ValidateFields(IEnumerable<DataValidationRule> dataValidationRules)
		{
			var errors = new List<string>();

			foreach (var rule in dataValidationRules)
			{
				if (string.IsNullOrEmpty(rule.MemberValue))
				{
					if (rule.IsRequired)
						errors.Add(string.Format(DataValidatorHelper.DataValidatorMessages.Required, rule.MemberName));
					continue;
				}
			}

			if (errors.Count > 0)
				throw new RequiredDetailsException(string.Format("Missing or invalid details fields: {0}", string.Join(", ", errors)));
		}

		public static class DataValidatorMessages
		{
			public const string Required = "{0} is required for Member.";
			public const string InvalidType = "{0} must be a valid {1}.";
		}
	}

	public sealed class DataValidationRule
	{
		public string MemberName { get; private set; }
		public string MemberValue { get; private set; }
		public bool IsRequired { get; private set; }
		public Type DataType { get; private set; }
		public int Size { get; private set; }

		public DataValidationRule(
			string memberName,
			string memberValue,
			bool isRequired,
			Type dataType,
			int size = 0)
		{
			this.MemberName = memberName;
			this.MemberValue = memberValue;
			this.IsRequired = isRequired;
			this.DataType = dataType;
			this.Size = size;
		}
	}

}