using System.Collections.Generic;

namespace Shepherd.Core.Models
{
	public sealed class ProcessResult
	{
		public int Id { get; set; }

		public List<ValidationResult> ValidationResults { get; set; }

		public ProcessResult()
		{
			this.ValidationResults = new List<ValidationResult>();
		}
	}
}