using Shepherd.Data.Contracts.Infrastructure;
using Shepherd.Entities;
using System.Collections.Generic;

namespace Shepherd.Data.Contracts.Repository
{
	public interface IMemberRepository : IRepositoryBase<Member>
	{	
		Member GetByChurchId(string churchId);

		Member GetByIdWithPerson(int id);

		IEnumerable<Member> GetAllWithPerson();
	}
}