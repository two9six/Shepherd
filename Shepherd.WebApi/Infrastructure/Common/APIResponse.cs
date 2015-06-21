using System.Collections.Generic;

namespace Shepherd.WebApi.Infrastructure.Common
{
	public abstract class APIResponse
	{
		public string Message { get; set; }

		public IEnumerable<string> Errors { get; set; }

		public APIResponse()
		{
			Errors = new List<string>();
		}
	}
}