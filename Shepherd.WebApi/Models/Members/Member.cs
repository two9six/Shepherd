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

			if(string.IsNullOrEmpty(this.ChurchId))
			{
				errors.Add(Member.ErrorMessages.RequiredChurchId);
			}

			if (string.IsNullOrEmpty(this.FirstName))
			{
				errors.Add(Member.ErrorMessages.RequiredChurchId);
			}

			return errors;
		}

		public static class ErrorMessages
		{
			public const string RequiredChurchId = "Church Id is required.";
		}
	}
}