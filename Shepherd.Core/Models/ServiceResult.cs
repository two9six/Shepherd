using System.Collections.Generic;

namespace Shepherd.Core.Models
{
	public sealed class ServiceResponse
	{
		public string Message { get; set; }

		public IEnumerable<string> Errors { get; set; }

		public ServiceResponse()
		{
			this.Errors = new List<string>();
		}
	}
}