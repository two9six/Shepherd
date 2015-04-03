using Shepherd.Data.Contracts.Repository;
using System;

namespace Shepherd.Data.Contracts.Infrastructure
{
	public interface IUnitOfWork: IDisposable
	{
		IShepherdEntities Context { get; set; }

		ILookupRepository LookupRepository { get; set; }

		ILookupTypeRepository LookupTypeRepository { get; set; }

		IMemberRepository MemberRepository { get; set; }

		IPersonRepository PersonRepository { get; set; }

		int Save();
	}
}
