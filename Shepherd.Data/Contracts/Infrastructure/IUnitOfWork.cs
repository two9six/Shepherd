using Shepherd.Data.Contracts.Repository;
using Shepherd.Entities.Contracts;
using System;

namespace Shepherd.Data.Contracts.Infrastructure
{
	public interface IUnitOfWork: IDisposable
	{
		IShepherdContext Context { get; set; }

		IDesignationRepository DesignationRepository { get; set; }

		IGatheringTypeRepository GatheringTypeRepository { get; set; }	

		IMemberRepository MemberRepository { get; set; }

		IMemberStatusRepository MemberStatusRepository { get; set; }

		IDesignationTypeRepository MemberTypeRepository { get; set; }

		IPersonRepository PersonRepository { get; set; }

		ICommitteeRepository CommitteeRepository { get; set; }

		int Save();
	}
}
