using System.Collections.Generic;

namespace Shepherd.Core.Models
{
	public sealed class ServiceResult
	{
		public int Id { get; set; }

		public List<ValidationResult> ValidationResults { get; set; }

		public ServiceResult()
		{
			this.ValidationResults = new List<ValidationResult>();
		}
	}
}