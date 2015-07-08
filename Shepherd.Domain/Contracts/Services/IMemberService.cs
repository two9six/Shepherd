using Shepherd.Domain.Models;
using Shepherd.Domain.Models.SearchCriteria;
using Shepherd.Domain.Services.Models;

namespace Shepherd.Domain.Contracts.Services
{
	public interface IMemberService
	{
		ServiceResponse AddMember(Member member);

		GetMembersServiceResponse GetMembers(SearchMembersCriteria getMembersCriteria);
	}
}