using Shepherd.Data.Contracts.Repository;
using Shepherd.Data.Infrastructure;
using Shepherd.Model.Models;
using System.Collections.Generic;
using System.Linq;

namespace Shepherd.Data.Repository
{
	public sealed class MemberRepository
		: RepositoryBase<Member>,
		IMemberRepository
	{
		public Member GetByGeneratedId(string generatedId)
		{
			return this.FindBy(_ => _.GeneratedId == generatedId && !_.IsDeleted).SingleOrDefault();
		}

		public Member GetByIdWithPerson(int id)
		{
			return this.Context.Set<Member>()
				.Include("Person")
				.Single(_ => _.Id == id);
		}

		public IEnumerable<Member> GetAllWithPerson()
		{
			return this.Context.Set<Member>()
				.Include("Person")
				.Where(_ => !_.IsDeleted);
		}
	}
}