using Shepherd.Data.Contracts;
using Shepherd.Data.Infrastructure;
using Shepherd.Data.Repository.Contracts;
using Shepherd.Model.Models;

namespace Shepherd.Data.Repository
{
	public sealed class LookupTypeRepository
		: RepositoryBase<LookupType>,
		ILookupTypeRepository
	{
		//public LookupTypeRepository(IShepherdEntities context) :
		//	base(context) { }
	}
}