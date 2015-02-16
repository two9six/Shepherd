using Shepherd.Data.Infrastructure;
using Shepherd.Data.Infrastructure.Contracts;
using Shepherd.Data.Repository.Contracts;
using Shepherd.Model.Models;

namespace Shepherd.Data.Repository
{
	public class PersonRepository :
		RepositoryBase<Person>,
		IPersonRepository
	{
		public PersonRepository(IDatabaseFactory databaseFactory)
			: base(databaseFactory) { }
	}
}