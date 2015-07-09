using Shepherd.Domain.Models;
using Shepherd.Domain.Services.Models.Criteria;
using Shepherd.Domain.Services.Models.ServiceResponses;

namespace Shepherd.Domain.Contracts.Services
{
	public interface IMemberService
	{
		ServiceResponse AddMember(Member member);

		GetMembersServiceResponse GetMembers(GetMembersCriteria getMembersCriteria);
	}
}