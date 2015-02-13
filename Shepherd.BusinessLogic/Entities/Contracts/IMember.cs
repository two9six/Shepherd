using Shepherd.BusinessLogic.Infrastructure.Contracts;
using System;

namespace Shepherd.BusinessLogic.Entities.Contracts
{
	public interface IMember : IWriteableEntity<IMember>
	{
		int MemberId { get; }

		string GeneratedId { get; set; }

		string FirstName { get; set; }

		string LastName { get; set; }

		string MiddleName { get; set; }

		DateTime BirthDate { get; set; }

	}
}