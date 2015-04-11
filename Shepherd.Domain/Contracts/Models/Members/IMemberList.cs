using Shepherd.Domain.Contracts.Infrastructure;
using Shepherd.Domain.Models.Members;

namespace Shepherd.Domain.Contracts.Models.Members
{
	public interface IMemberList : IModelListBase<MemberListItem>
	{
		void Fetch(MemberListSearchCriteria criteria);
	}
}