using Shepherd.Domain.Models;
using Shepherd.WebApi.Infrastructure.Contracts;
using System.Collections.Generic;

namespace Shepherd.WebApi.Models
{
	public class AddMemberRequest : IValidatable
	{
		public Member Member { get; set; }

		public IList<string> GetValidationErrors()
		{
			return new List<string>();
		}
	}
}