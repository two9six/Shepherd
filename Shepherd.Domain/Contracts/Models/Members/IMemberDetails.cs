using Shepherd.Core.Models;
using System;

namespace Shepherd.Domain.Contracts.Models.Members
{
	public interface IMemberDetails
	{
		int MemberId { get; set; }

		string ChurchId { get; set; }

		string FirstName { get; set; }

		string LastName { get; set; }

		string MiddleName { get; set; }

		DateTime BirthDate { get; set; }

		DateTime DateBabtized { get; set; }

		void Fetch(int memberId);

		ProcessResult Add();

		ProcessResult Update();

		void Delete(int memberId);
	}
}