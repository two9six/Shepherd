using Shepherd.Model.Models;
using System;

namespace Shepherd.BusinessLogic.Entities.Members.Contracts
{
	public interface IMemberDetails
	{
		int MemberId { get; set; }

		string GeneratedId { get; set; }

		string FirstName { get; set; }

		string LastName { get; set; }

		string MiddleName { get; set; }

		DateTime BirthDate { get; set; }

		DateTime DateBabtized { get; set; }

		void Fetch(int memberId);

		void Create(Member member);

		void Update();

		void Delete(int memberId);

		void Save();
	}
}