using Shepherd.Core.Extensions;
using Shepherd.WebApi.Infrastructure.Contracts;
using System;
using System.Collections.Generic;

namespace Shepherd.WebApi.Models.Members
{
	public sealed class Member : IValidatable
	{
		public int Id { get; set; }

		public string ChurchId { get; set; }

		public string FirstName { get; set; }

		public string LastName { get; set; }

		public string MiddleName { get; set; }

		public DateTime BirthDate { get; set; }

		public string PlaceOfBirth { get; set; }

		public string Gender { get; set; }

		public string Citizenship { get; set; }

		public Address Address { get; set; }

		public DateTime DateBaptized { get; set; }

		public Baptizer Baptizer { get; set; }

		public string MaritalStatus { get; set; }

		public string SpouseName { get; set; }

		public ContactInformation ContactInformation { get; set; }

		public string Status { get; set; }

		public string Type { get; set; }

		public string Designation { get; set; }

		public int CreatedBy { get; set; }

		public DateTime DateCreated { get; set; }

		public int? ModifiedBy { get; set; }

		public DateTime? DateModified { get; set; }

		public IList<string> GetValidationErrors()
		{
			var errors = new List<string>();

			Domain.Models.Member.MemberStatus memberStatus = 0;
			if (!this.Status.TryParseAsEnum<Domain.Models.Member.MemberStatus>(out memberStatus))
				errors.Add(Member.ErrorMessages.UnknownMemberStatus);

			Domain.Models.Member.MemberType memberType = 0;
			if (!this.Status.TryParseAsEnum<Domain.Models.Member.MemberType>(out memberType))
				errors.Add(Member.ErrorMessages.UnknownMemberType);

			Domain.Models.Member.ChurchDesignation churchDesignation = 0;
			if (!this.Status.TryParseAsEnum<Domain.Models.Member.ChurchDesignation>(out churchDesignation))
				errors.Add(Member.ErrorMessages.UnknownMemberStatus);

			return errors;
		}

		public static class ErrorMessages
		{
			public const string UnknownMemberStatus = "Unknown Member Status."; 
			public const string UnknownMemberType= "Unknown Member Type.";
			public const string UnknownChurchDesignation = "Unknown Church Designation.";
		}
	}
}