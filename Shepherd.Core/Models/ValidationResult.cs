namespace Shepherd.Core.Models
{
	public class ValidationResult
	{
		public string MemberName { get; set; }

		public string Message { get; set; }

		public ValidationResult()
		{
		}

		public ValidationResult(string message)
		{
			this.Message = message;
		}

		public ValidationResult(string memberName, string message)
		{
			this.MemberName = memberName;
			this.Message = message;
		}
	}
}
