using Shepherd.Data.Contracts.Repository;
using Shepherd.Data.Infrastructure;
using Shepherd.Entities;

namespace Shepherd.Data.Repository
{
	public sealed class PersonRepository :
		RepositoryBase<Person>,
		IPersonRepository
	{
	}
}