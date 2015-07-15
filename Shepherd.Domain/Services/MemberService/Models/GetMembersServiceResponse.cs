using Shepherd.Domain.Models;
using System.Collections.Generic;

namespace Shepherd.Domain.Services.MemberService.Models
{
	public sealed class GetMembersServiceResponse : ServiceResponse
	{
		public IEnumerable<Member> Members { get; set; }
	}
}