using Shepherd.Domain.Models;
using Shepherd.Domain.Services.MemberService.Models;

namespace Shepherd.Domain.Contracts.Services
{
	public interface IMemberService
	{
		AddMemberServiceResponse AddMember(Member newMember);

		GetMembersServiceResponse GetMembers(GetMembersCriteria getMembersCriteria);
	}
}