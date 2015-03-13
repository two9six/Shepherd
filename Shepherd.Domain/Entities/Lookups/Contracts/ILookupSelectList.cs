using Shepherd.Domain.Infrastructure.Contracts;
using Shepherd.Core.Common;

namespace Shepherd.Domain.Entities.Lookups.Contracts
{
	public interface ILookupSelectList : IListEntityBase<LookupSelectListItem>
	{
		void Fetch(Identifiers.LookupTypes lookupType);
	}
}