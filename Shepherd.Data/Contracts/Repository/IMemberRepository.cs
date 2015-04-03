using Shepherd.Data.Contracts.Infrastructure;
using Shepherd.Model.Models;
using System.Collections.Generic;

namespace Shepherd.Data.Contracts.Repository
{
	public interface IMemberRepository : IRepositoryBase<Member>
	{	
		Member GetByGeneratedId(string generatedId);

		Member GetByIdWithPerson(int id);

		IEnumerable<Member> GetAllWithPerson();
	}
}