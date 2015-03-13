using Shepherd.Data.Contracts;
using Shepherd.Data.Infrastructure;
using Shepherd.Data.Repository.Contracts;
using Shepherd.Model.Models;
using System.Collections.Generic;

namespace Shepherd.Data.Repository
{
	public sealed class LookupRepository
		: RepositoryBase<Lookup>,
		ILookupRepository
	{
		//public LookupRepository(IShepherdEntities context)
		//	: base(context) { }

		public IEnumerable<Lookup> GetByLookupTypeId(int lookupTypeId)
		{
			return this.FindBy(_ => !_.IsDeleted && _.LookupTypeId == lookupTypeId);
		}
	}
}