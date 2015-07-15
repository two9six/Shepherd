using Shepherd.Domain.Models;

namespace Shepherd.Domain.Services.MemberService.Models
{
	public sealed class AddMemberServiceResponse : ServiceResponse
	{
		public Member Member { get; set; }
	}
}