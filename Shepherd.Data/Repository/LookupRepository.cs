using Shepherd.Data.Infrastructure;
using Shepherd.Data.Infrastructure.Contracts;
using Shepherd.Data.Repository.Contracts;
using Shepherd.Model.Models;

namespace Shepherd.Data.Repository
{
	public class LookupRepository
		: RepositoryBase<Lookup>,
		ILookupRepository
	{

		public LookupRepository(IDatabaseFactory databaseFactory)
			: base(databaseFactory) { }
	}
}