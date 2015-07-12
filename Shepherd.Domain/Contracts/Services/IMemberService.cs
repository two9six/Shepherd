using Shepherd.Domain.Models;
using Shepherd.Domain.Services.Models.Criteria;
using Shepherd.Domain.Services.Models.ServiceResponses;
using Shepherd.Domain.Services.Models.ServiceResponses.Members;

namespace Shepherd.Domain.Contracts.Services
{
	public interface IMemberService
	{
		AddMemberServiceResponse AddMember(Member newMember);

		GetMembersServiceResponse GetMembers(GetMembersCriteria getMembersCriteria);
	}
}