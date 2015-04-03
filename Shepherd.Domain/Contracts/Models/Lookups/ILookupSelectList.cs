using Shepherd.Core.Common;
using Shepherd.Domain.Infrastructure.Contracts;
using Shepherd.Domain.Models.Lookups;

namespace Shepherd.Domain.Contracts.Models.Lookups
{
	public interface ILookupSelectList : IListEntityBase<LookupSelectListItem>
	{
		void Fetch(Identifiers.LookupTypes lookupType);
	}
}