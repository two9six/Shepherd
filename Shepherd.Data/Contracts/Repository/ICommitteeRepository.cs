using Shepherd.Data.Contracts.Infrastructure;
using Shepherd.Entities;
using System.Collections.Generic;

namespace Shepherd.Data.Contracts.Repository
{
	public interface ICommitteeRepository : IRepositoryBase<Committee>
	{
		IEnumerable<Committee> GetAllWithCommitteeMember();
	}
}