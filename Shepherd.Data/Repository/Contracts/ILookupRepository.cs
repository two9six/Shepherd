using Shepherd.Data.Infrastructure.Contracts;
using Shepherd.Model.Models;
using System.Collections.Generic;

namespace Shepherd.Data.Repository.Contracts
{
	public interface ILookupRepository : IRepositoryBase<Lookup>
	{
		IEnumerable<Lookup> GetByLookupTypeId(int lookupTypeId);
	}
}