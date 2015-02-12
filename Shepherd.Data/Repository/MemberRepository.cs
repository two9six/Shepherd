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


		public Member GetByMemberId(string memberId)
		{
			if (string.IsNullOrEmpty(memberId))
			{
				throw new ArgumentException("Member Id cannot be Null or empty");
			}

			return this.DataContext.Members.Single(_ => _.MemberId == memberId && !_.IsDeleted);
		}
	}
}