using Shepherd.Data.Contracts.Repository;
using Shepherd.Data.Infrastructure;
using Shepherd.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Shepherd.Data.Repository
{
	public sealed class CommitteeRepository
		: RepositoryBase<Committee>,
		ICommitteeRepository
	{
		public IEnumerable<Committee> GetAllWithCommitteeMember()
		{
			return this.Context.Set<Committee>()
				.Include("CommitteeMembers")
				.Where(_ => !_.IsDeleted);
		}
	}
}