using Shepherd.Data.Contracts.Repository;
using Shepherd.Data.Infrastructure;
using Shepherd.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Shepherd.Data.Repository
{
	public sealed class MemberRepository
		: RepositoryBase<Member>,
		IMemberRepository
	{
		public Member GetByChurchId(string churchId)
		{
			return this.FindBy(_ => _.ChurchId == churchId && !_.IsDeleted).SingleOrDefault();
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