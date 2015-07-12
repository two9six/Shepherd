using Shepherd.WebApi.Infrastructure.Common;

namespace Shepherd.WebApi.DTOs.Members
{
	public sealed class AddMemberResponse : APIResponse
	{
		public int MemberId { get; set; }
	}
}