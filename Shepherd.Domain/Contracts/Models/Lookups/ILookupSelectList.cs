using Shepherd.Core.Common;
using Shepherd.Domain.Contracts.Infrastructure;
using Shepherd.Domain.Models.Lookups;

namespace Shepherd.Domain.Contracts.Models.Lookups
{
	public interface ILookupSelectList : IModelListBase<LookupSelectListItem>
	{
		void Fetch(Identifiers.LookupTypes lookupType);
	}
}