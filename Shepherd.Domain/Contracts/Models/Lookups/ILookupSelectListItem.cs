using Shepherd.Domain.Infrastructure.Contracts;
using SMM = Shepherd.Model.Models;

namespace Shepherd.Domain.Contracts.Models.Lookups
{
	public interface ILookupSelectListItem<T>
		: IListEntityItemBase<T, SMM.Lookup>
		where T : class
	{
		int LookupTypeId { get; }

		string Name { get; set; }

		bool IsDefault { get; set; }
	}
}