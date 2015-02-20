using Shepherd.Data.Infrastructure;
using Shepherd.Data.Infrastructure.Contracts;
using Shepherd.Data.Repository.Contracts;
using Shepherd.Model.Models;

namespace Shepherd.Data.Repository
{
	public class LookupTypeRepository
		: RepositoryBase<LookupType>,
		ILookupTypeRepository
	{
		public LookupTypeRepository(IDatabaseFactory databaseFactory) :
			base(databaseFactory) { }
	}
}