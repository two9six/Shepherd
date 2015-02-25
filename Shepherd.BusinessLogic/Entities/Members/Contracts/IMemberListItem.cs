using Shepherd.BusinessLogic.Infrastructure.Contracts;
using SMM = Shepherd.Model.Models;

namespace Shepherd.BusinessLogic.Entities.Members.Contracts
{
	public interface IMemberListItem<T>
		: IListEntityItemBase<T, SMM.Member>
		where T : class
	{
		int MemberId { get; }

		string Name { get; set; }

		int AgeInSpirit { get; set; }
	}
}