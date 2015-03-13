using Shepherd.Data.Contracts;
using Shepherd.Data.Infrastructure;
using Shepherd.Data.Repository.Contracts;
using Shepherd.Model.Models;

namespace Shepherd.Data.Repository
{
	public sealed class PersonRepository :
		RepositoryBase<Person>,
		IPersonRepository
	{
		//public PersonRepository(IShepherdEntities context)
		//	: base(context) { }
	}
}