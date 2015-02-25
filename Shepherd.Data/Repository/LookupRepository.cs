using Shepherd.Data.Infrastructure;
using Shepherd.Data.Infrastructure.Contracts;
using Shepherd.Data.Repository.Contracts;
using Shepherd.Model.Models;
using System.Collections.Generic;
using System.Linq;

namespace Shepherd.Data.Repository
{
	public class LookupRepository
		: RepositoryBase<Lookup>,
		ILookupRepository
	{
		public LookupRepository(IDatabaseFactory databaseFactory)
			: base(databaseFactory) { }

		public IEnumerable<Lookup> GetByLookupTypeId(int lookupTypeId)
		{
			return this.DataContext.Lookups
				.Where(_ => !_.IsDeleted && _.LookupTypeId == lookupTypeId)
				.ToList();
		}
	}
}