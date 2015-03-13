using Shepherd.Data.Infrastructure.Contracts;
using Shepherd.Model.Models;
using System.Collections.Generic;

namespace Shepherd.Data.Repository.Contracts
{
	public interface IMemberRepository : IRepositoryBase<Member>
	{	
		Member GetByGeneratedId(string generatedId);

		Member GetByIdWithPerson(int id);

		IEnumerable<Member> GetAllWithPerson();
	}
}