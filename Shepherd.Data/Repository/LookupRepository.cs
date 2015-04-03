using Shepherd.Data.Contracts.Repository;
using Shepherd.Data.Infrastructure;
using Shepherd.Model.Models;
using System.Collections.Generic;

namespace Shepherd.Data.Repository
{
	public sealed class LookupRepository
		: RepositoryBase<Lookup>,
		ILookupRepository
	{

		public IEnumerable<Lookup> GetByLookupTypeId(int lookupTypeId)
		{
			return this.FindBy(_ => !_.IsDeleted && _.LookupTypeId == lookupTypeId);
		}
	}
}