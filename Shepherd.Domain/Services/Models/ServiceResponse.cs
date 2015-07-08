using System.Collections.Generic;

namespace Shepherd.Domain.Services.Models
{
	public class ServiceResponse
	{
		public string Message { get; set; }

		public IEnumerable<string> Errors { get; set; }

		public ServiceResponse()
		{
			this.Errors = new List<string>();
		}
	}
}