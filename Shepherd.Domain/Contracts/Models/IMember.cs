using Shepherd.Core.Enums;
using Shepherd.Domain.Models;
using System;

namespace Shepherd.Domain.Contracts.Models
{
	public interface IMember
	{
		int Id { get; set; }
		string ChurchId { get; set; }
        string LocaleChurchId { get; set; }
		string FirstName { get; set; }
		string LastName { get; set; }
		string MiddleName { get; set; }
		string NameExtension { get; set; }
		DateTime? BirthDate { get; set; }
		string PlaceOfBirth { get; set; }
		string Gender { get; set; }
		string Citizenship { get; set; }
		Address Address { get; set; }
		DateTime? DateBaptized { get; set; }
		Baptizer Baptizer { get; set; }
		MaritalStatuses MaritalStatus { get; set; }
		string SpouseName { get; set; }
		ContactInformation ContactInformation { get; set; }
		MemberStatuses MemberStatus { get; set; }
		Designations Designation { get; set; }
		int CreatedBy { get; set; }
		DateTime DateCreated { get; set; }
		int? ModifiedBy { get; set; }
		DateTime? DateModified { get; set; }

		void Load();
		void Insert();
        void Update();
	}
}