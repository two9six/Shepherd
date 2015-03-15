using System.Collections.Generic;

namespace Shepherd.Core
{
	public sealed class ProcessResult
	{
		public int Id { get; set; }

		public List<ValidationResult> ValidationResults { get; set; }
	}
}