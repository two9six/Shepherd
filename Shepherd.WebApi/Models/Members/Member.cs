using Shepherd.Core.Extensions;
using Shepherd.WebApi.Contracts;
using Shepherd.WebApi.Infrastructure.Contracts;
using System;
using System.Collections.Generic;

namespace Shepherd.WebApi.Models.Members
{
	public sealed class Member : 
		IValidatable, 
		IDomainConvertible<Domain.Models.Member>
	{
		public int Id { get; set; }

		public string ChurchId { get; set; }

		public string FirstName { get; set; }

		public string LastName { get; set; }

		public string MiddleName { get; set; }

		public DateTime? BirthDate { get; set; }

		public string PlaceOfBirth { get; set; }

		public string Gender { get; set; }

		public string Citizenship { get; set; }

		public Address Address { get; set; }

		public DateTime? DateBaptized { get; set; }

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

		public Member()
		{
			this.Address = new Address();
			this.Baptizer = new Baptizer();
			this.ContactInformation = new ContactInformation();
		}

		public IList<string> GetValidationErrors()
		{
			var errors = new List<string>();

			Domain.Models.Member.MemberStatus memberStatus = 0;
			if (!this.Status.TryParseAsEnum<Domain.Models.Member.MemberStatus>(out memberStatus))
				errors.Add(Member.ErrorMessages.UnknownMemberStatus);

			Domain.Models.Member.MemberType memberType = 0;
			if (!this.Type.TryParseAsEnum<Domain.Models.Member.MemberType>(out memberType))
				errors.Add(Member.ErrorMessages.UnknownMemberType);

			Domain.Models.Member.ChurchDesignation churchDesignation = 0;
			if (!this.Designation.TryParseAsEnum<Domain.Models.Member.ChurchDesignation>(out churchDesignation))
				errors.Add(Member.ErrorMessages.UnknownChurchDesignation);

			return errors;
		}

		public Domain.Models.Member ToDomainObject()
		{
			return new Domain.Models.Member()
			{
				ChurchId = this.ChurchId,
				FirstName = this.FirstName,
				LastName = this.LastName,
				MiddleName = this.MiddleName,
				BirthDate = this.BirthDate,
				PlaceOfBirth = this.PlaceOfBirth,
				Gender = this.Gender,
				Citizenship = this.Citizenship,
				Address = this.Address.ToDomainObject(),
				DateBaptized = this.DateBaptized,
				Baptizer = this.Baptizer.ToDomainObject(),
				MaritalStatus = this.MaritalStatus,
				SpouseName = this.SpouseName,
				ContactInformation = this.ContactInformation.ToDomainObject(),
				Status = (Domain.Models.Member.MemberStatus)Enum.Parse(typeof(Domain.Models.Member.MemberStatus), this.Status),
				Type = (Domain.Models.Member.MemberType)Enum.Parse(typeof(Domain.Models.Member.MemberType), this.Type),
				Designation = (Domain.Models.Member.ChurchDesignation)Enum.Parse(typeof(Domain.Models.Member.ChurchDesignation), this.Designation)
			};
		}

		public void LoadFromDomainObject(Domain.Models.Member domainObject)
		{
			if (domainObject != null)
			{
				this.Id = domainObject.Id;
				this.ChurchId = domainObject.ChurchId;
				this.FirstName = domainObject.FirstName;
				this.LastName = domainObject.LastName;
				this.MiddleName = domainObject.MiddleName;
				this.BirthDate = domainObject.BirthDate;
				this.PlaceOfBirth = domainObject.PlaceOfBirth;
				this.Gender = domainObject.Gender;
				this.Citizenship = domainObject.Citizenship;
				this.Address.LoadFromDomainObject(domainObject.Address);
				this.DateBaptized = domainObject.DateBaptized;
				this.Baptizer.LoadFromDomainObject(domainObject.Baptizer);
				this.MaritalStatus = domainObject.MaritalStatus;
				this.SpouseName = domainObject.SpouseName;
				this.ContactInformation.LoadFromDomainObject(domainObject.ContactInformation);
				this.Status = domainObject.Status.ToString();
				this.Type = domainObject.Type.ToString();
				this.Designation = domainObject.Designation.ToString();
				this.CreatedBy = domainObject.CreatedBy;
				this.DateCreated = domainObject.DateCreated;
				this.ModifiedBy = domainObject.ModifiedBy;
				this.DateModified = domainObject.DateModified;
			}
		}

		public static Member Parse(Domain.Models.Member domainMember)
		{
			var member = new Member();
			member.LoadFromDomainObject(domainMember);
			return member;
		}

		public static class ErrorMessages
		{
			public const string UnknownMemberStatus = "Unknown Member Status.";
			public const string UnknownMemberType = "Unknown Member Type.";
			public const string UnknownChurchDesignation = "Unknown Church Designation.";
		}

	}
}