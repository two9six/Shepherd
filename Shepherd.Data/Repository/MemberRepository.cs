using Shepherd.Data.Infrastructure;
using Shepherd.Data.Infrastructure.Contracts;
using Shepherd.Data.Repository.Contracts;
using Shepherd.Model.Models;
using System;
using System.Linq;

namespace Shepherd.Data.Repository
{
	public class MemberRepository
		: RepositoryBase<Member>,
		IMemberRepository
	{
		public MemberRepository(IDatabaseFactory databaseFactory)
			: base(databaseFactory)
		{

		}

		public Member GetByGeneratedId(string generatedId)
		{
			if (string.IsNullOrEmpty(generatedId))
			{
				throw new ArgumentException("Member Id cannot be Null or empty");
			}

			return this.DataContext.Members.Single(_ => _.GeneratedId == generatedId && !_.IsDeleted);
		}
	}
}