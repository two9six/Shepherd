using Shepherd.Domain.Contracts.Infrastructure;
using SE = Shepherd.Entities;

namespace Shepherd.Domain.Contracts.Models.Members
{
	public interface IMemberListItem<T>
		: IModelListItemBase<T, SE.Member>
		where T : class
	{
		int MemberId { get; }

		string Name { get; set; }

		int AgeInSpirit { get; set; }

		string Status { get; set; }
	}
}