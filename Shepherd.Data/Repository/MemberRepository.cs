using Shepherd.Data.Infrastructure;
using Shepherd.Data.Infrastructure.Contracts;
using Shepherd.Data.Repository.Contracts;
using Shepherd.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Shepherd.Data.Repository
{
	public class MemberRepository
		: RepositoryBase<Member>,
		IMemberRepository
	{
		public MemberRepository(IDatabaseFactory databaseFactory)
			: base(databaseFactory) { }

		public Member GetByGeneratedId(string generatedId)
		{
			if (string.IsNullOrEmpty(generatedId))
			{
				throw new ArgumentException("Member Id cannot be Null or empty");
			}

			return this.DataContext.Members.Single(_ => _.GeneratedId == generatedId && !_.IsDeleted);
		}

		public Member GetByIdWithPerson(int id)
		{
			return this.DataContext.Members.Include("Person").Single(_ => _.Id == id);
		}

		public IEnumerable<Member> GetAllWithPerson()
		{
			return this.DataContext.Members
				.Include("Person")
				.Where(_ => !_.IsDeleted)
				.ToList();
		}
	}
}