using Shepherd.WebApi.Infrastructure.Contracts;
using Shepherd.WebApi.Models.Members;
using System.Collections.Generic;
using System.Linq;

namespace Shepherd.WebApi.DTOs.Members
{
	public sealed class AddMemberRequest : IValidatable
	{
		public Member Member { get; set; }

		public IList<string> GetValidationErrors()
		{
			var errors = new List<string>();

			errors = errors.Concat(this.Member.GetValidationErrors()).ToList();

			return errors;
		}
	}
}