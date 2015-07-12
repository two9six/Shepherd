using Shepherd.WebApi.Infrastructure.Common;
using Shepherd.WebApi.Models.Members;
using System.Collections.Generic;

namespace Shepherd.WebApi.DTOs.Members
{
	public sealed class GetMembersResponse : APIResponse
	{
		public IEnumerable<Member> Members { get; set; }
	}
}