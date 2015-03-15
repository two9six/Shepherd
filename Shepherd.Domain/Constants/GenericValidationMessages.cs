
namespace Shepherd.Domain.Constants
{
	public static class GenericValidationMessages
	{
		public static class ArgumentException
		{
			public static readonly string InvalidId = "Invalid Id";
		}

		public static class NullReferenceException
		{
			public static readonly string UpdateFailed = "Update operation failed. Object to update is null.";
		}

		public static class Common
		{
			public static readonly string CannotBeNullOrEmpty = "Field cannot be null or empty";
		}
	}
}
