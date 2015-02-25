using Shepherd.BusinessLogic.Infrastructure.Contracts;
using Shepherd.Core.Common;

namespace Shepherd.BusinessLogic.Entities.Lookup.Contracts
{
	public interface ILookupSelectList : IListEntityBase<LookupSelectListItem>
	{
		void Fetch(Identifiers.LookupTypes lookupType);
	}
}