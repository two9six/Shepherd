using Shepherd.Data.Contracts.Repository;
using Shepherd.Data.Infrastructure;
using Shepherd.Model.Models;

namespace Shepherd.Data.Repository
{
	public sealed class LookupTypeRepository
		: RepositoryBase<LookupType>,
		ILookupTypeRepository
	{
	}
}