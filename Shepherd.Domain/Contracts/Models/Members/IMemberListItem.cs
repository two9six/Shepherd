using Shepherd.Domain.Contracts.Infrastructure;
using SMM = Shepherd.Model.Models;

namespace Shepherd.Domain.Contracts.Models.Members
{
	public interface IMemberListItem<T>
		: IModelListItemBase<T, SMM.Member>
		where T : class
	{
		int MemberId { get; }

		string Name { get; set; }

		int AgeInSpirit { get; set; }

		string Status { get; set; }
	}
}