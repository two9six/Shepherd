using Shepherd.Domain.Models;
using System.Collections.Generic;

namespace Shepherd.Domain.Services.Models.ServiceResponses.Members
{
	public sealed class GetMembersServiceResponse : ServiceResponse
	{
		public IEnumerable<Member> Members { get; set; }
	}
}