using Shepherd.BusinessLogic.Infrastructure.Contracts;
using Shepherd.Model.Models;
using System;

namespace Shepherd.BusinessLogic.Entities.Contracts
{
	public interface IMemberDetails
	{
		int MemberId { get; }

		string GeneratedId { get; set; }

		string FirstName { get; set; }

		string LastName { get; set; }

		string MiddleName { get; set; }

		DateTime BirthDate { get; set; }

		void Fetch(int memberId);

		void CreateMember(Member member);

		void EditMember(Member memberToEdit);

		void DeleteMember(int memberId);

		void SaveMember();
	}
}