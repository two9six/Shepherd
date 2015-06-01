using Shepherd.Domain.Contracts.Infrastructure;
using SE = Shepherd.Entities;

namespace Shepherd.Domain.Contracts.Models.Lookups
{
	public interface ILookupSelectListItem<T>
		: IModelListItemBase<T, SE.Lookup>
		where T : class
	{
		int LookupTypeId { get; }

		string Name { get; set; }

		bool IsDefault { get; set; }
	}
}