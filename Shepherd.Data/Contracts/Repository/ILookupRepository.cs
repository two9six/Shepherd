using Shepherd.Data.Contracts.Infrastructure;
using Shepherd.Model.Models;
using System.Collections.Generic;

namespace Shepherd.Data.Contracts.Repository
{
	public interface ILookupRepository : IRepositoryBase<Lookup>
	{
		IEnumerable<Lookup> GetByLookupTypeId(int lookupTypeId);
	}
}