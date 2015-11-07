using Shepherd.Core.Enums;
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


		public IEnumerable<Member> GetNonMembers(int committeeId)
		{
			var committeeMembers = this.Context.CommitteeMembers
										.Where(_ => _.CommitteeId == committeeId)
										.Select(_ => _.MemberId)
										.ToList();

			var query = (from m in this.Context.Members
						 where !committeeMembers.Contains(m.Id)
							&& m.IsDeleted == false
							&& m.MemberStatusId != (byte)MemberStatuses.Excommunicated
							&& m.MemberStatusId != (byte)MemberStatuses.Deceased
						 select new
						 {
							 Id = m.Id,
							 FirstName = m.Person.FirstName,
							 LastName = m.Person.LastName,
							 DesignationId = m.DesignationId,
							 DesignationTypeId = m.Designation.DesignationTypeId
						 }).ToList();

			var nonMembers = new List<Member>();

			if (query != null)
			{
				query.ForEach(_ =>
				{
					nonMembers.Add(new Member
					{
						Id = _.Id,
						Person = new Person
						{
							FirstName = _.FirstName,
							LastName = _.LastName,
						},
						DesignationId = _.DesignationId,
						Designation = new Designation
						{
							DesignationTypeId = _.DesignationTypeId
						}
					});
				});
			}

			return nonMembers;
		}
	}
}