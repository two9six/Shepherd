using Shepherd.Core.Enums;
using Shepherd.Core.Exceptions;
using Shepherd.Core.Extensions;
using Shepherd.Data.Contracts.Infrastructure;
using Shepherd.Data.Infrastructure;
using Shepherd.Domain.Contracts.Models;
using Shepherd.Domain.Helpers;
using System;
using System.Collections.Generic;

namespace Shepherd.Domain.Models
{
	public sealed class Member
		: IMember
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

		public MemberStatuses MemberStatus { get; set; }

		public Designations Designation { get; set; }

		public int CreatedBy { get;  set; }

		public DateTime DateCreated { get; set; }

		public int? ModifiedBy { get; set; }

		public DateTime? DateModified { get; set; }

		private readonly IUnitOfWork unitOfWork;

		public Member()
			: this(UnitOfWork.Instance)
		{
		}

		public Member(IUnitOfWork unitOfWork)
		{
			this.Address = new Address();
			this.Baptizer = new Baptizer();
			this.ContactInformation = new ContactInformation();

			this.unitOfWork = unitOfWork;
		}

		public void Load()
		{
			var memberEntity = unitOfWork.MemberRepository.GetByIdWithPerson(this.Id);
			if (memberEntity == null)
				throw new ModelNotFoundException("Member not found.");

			this.LoadFromEntity(memberEntity);
		}

		internal void LoadFromEntity(Entities.Member memberEntity)
		{
			if (memberEntity != null)
			{
				this.Id = memberEntity.Id;
				this.ChurchId = memberEntity.ChurchId;
				this.FirstName = memberEntity.Person.FirstName;
				this.LastName = memberEntity.Person.LastName;
				this.MiddleName = memberEntity.Person.MiddleName;
				this.BirthDate = memberEntity.Person.BirthDate;
				this.PlaceOfBirth = memberEntity.Person.PlaceOfBirth;
				this.Gender = memberEntity.Person.Gender;
				this.Citizenship = memberEntity.Person.Citizenship;
				this.Address = new Address()
				{
					AddressLine1 = memberEntity.Person.AddressLine1,
					AddressLine2 = memberEntity.Person.AddressLine2,
					City = memberEntity.Person.City,
					StateProvince = memberEntity.Person.StateProvince,
					Country = memberEntity.Person.Country
				};
				this.Baptizer = new Baptizer()
				{
					Id = memberEntity.BaptizedById
				};
				this.MaritalStatus = memberEntity.MaritalStatus;
				this.SpouseName = memberEntity.SpouseName;
				this.ContactInformation = new ContactInformation
				{
					LandLine = memberEntity.LandLine,
					MobileNumber = memberEntity.MobileNumber,
					Email = memberEntity.Email
				};
				this.MemberStatus = (MemberStatuses)memberEntity.MemberStatusId;
				this.Designation = (Designations)memberEntity.DesignationId;
				this.CreatedBy = memberEntity.CreatedBy;
				this.DateCreated = memberEntity.DateCreated;
				this.ModifiedBy = memberEntity.ModifiedBy;
				this.DateModified = memberEntity.DateModified;
			}
		}

		public void Insert()
		{
			DataValidatorHelper.ValidateFields(new List<DataValidationRule>()
			{
				new DataValidationRule(Member.FieldNames.ChurchId, this.ChurchId, true, typeof(string)),
				new DataValidationRule(Member.FieldNames.FirstName, this.FirstName, true, typeof(string)),
				new DataValidationRule(Member.FieldNames.LastName, this.LastName, true, typeof(string)),
				new DataValidationRule(Member.FieldNames.BirthDate, this.BirthDate.TryGetString(), true, typeof(DateTime)),
				new DataValidationRule(Member.FieldNames.DateBaptized, this.DateBaptized.TryGetString(), true, typeof(DateTime))
			});

			var createdMember = unitOfWork.MemberRepository.Add(new Entities.Member
			{
				ChurchId = this.ChurchId,
				DateBaptized = this.DateBaptized.Value,
				BaptizedById = this.Baptizer.Id,
				MaritalStatus = this.MaritalStatus,
				SpouseName = this.SpouseName,
				LandLine = this.ContactInformation.LandLine,
				MobileNumber = this.ContactInformation.MobileNumber,
				Email = this.ContactInformation.Email,
                MemberStatusId = (byte)this.MemberStatus,//(byte)this.MemberStatus,
				DesignationId = (byte)this.Designation,
				DateCreated = DateTime.Now,
				Person = new Entities.Person
				{
					FirstName = this.FirstName,
					LastName = this.LastName,
					MiddleName = this.MiddleName,
					BirthDate = this.BirthDate.Value,
					PlaceOfBirth = this.PlaceOfBirth,
					Gender = this.Gender,
					Citizenship = this.Citizenship,
					AddressLine1 = this.Address.AddressLine1,
					AddressLine2 = this.Address.AddressLine2,
					City = this.Address.City,
					StateProvince = this.Address.StateProvince,
					Country = this.Address.Country,
					CreatedBy = 1,
					DateCreated = DateTime.Now
				},
				CreatedBy = 1
			});

			unitOfWork.Save();

			this.Id = createdMember.Id;
		}

        public void Update()
        {
            DataValidatorHelper.ValidateFields(new List<DataValidationRule>()
			{
				new DataValidationRule(Member.FieldNames.ChurchId, this.ChurchId, true, typeof(string)),
				new DataValidationRule(Member.FieldNames.FirstName, this.FirstName, true, typeof(string)),
				new DataValidationRule(Member.FieldNames.LastName, this.LastName, true, typeof(string)),
				new DataValidationRule(Member.FieldNames.BirthDate, this.BirthDate.TryGetString(), true, typeof(DateTime)),
				new DataValidationRule(Member.FieldNames.DateBaptized, this.DateBaptized.TryGetString(), true, typeof(DateTime))
			});

            var existingMember = unitOfWork.MemberRepository.GetById(this.Id);
            existingMember.Person.FirstName = this.FirstName;
            existingMember.Person.LastName = this.LastName;
            existingMember.Person.MiddleName = this.MiddleName;
            existingMember.DateBaptized = this.DateBaptized.Value;
            existingMember.Person.BirthDate = this.BirthDate.Value;

            unitOfWork.MemberRepository.Edit(existingMember);
            unitOfWork.Save();

        }

		public static class FieldNames
		{
			public const string ChurchId = "Church Id";
			public const string FirstName = "First Name";
			public const string LastName = "Last Name";
			public const string BirthDate = "Birth Date";
			public const string DateBaptized = "Date Baptized";
		}
	}
}