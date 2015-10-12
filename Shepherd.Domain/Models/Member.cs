using Shepherd.Core.Enums;
using Shepherd.Core.Exceptions;
using Shepherd.Core.Extensions;
using Shepherd.Data.Contracts.Infrastructure;
using Shepherd.Data.Infrastructure;
using Shepherd.Domain.Contracts.Models;
using Shepherd.Domain.Extensions;
using Shepherd.Domain.Helpers;
using System;
using System.Collections.Generic;

namespace Shepherd.Domain.Models
{
	public class Member
		: IMember
	{
		public int Id { get; set; }

		public string ChurchId { get; set; }

        public string LocaleChurchId { get; set; }

		public string FirstName { get; set; }

		public string LastName { get; set; }

		public string MiddleName { get; set; }

		public string NameExtension { get; set; }

		public DateTime? BirthDate { get; set; }

		public string PlaceOfBirth { get; set; }

		public string Gender { get; set; }

		public string Citizenship { get; set; }

		public Address Address { get; set; }

		public DateTime? DateBaptized { get; set; }

		public Baptizer Baptizer { get; set; }

		public MaritalStatuses MaritalStatus { get; set; }

		public string SpouseName { get; set; }

		public ContactInformation ContactInformation { get; set; }

		public MemberStatuses MemberStatus { get; set; }

		public Designations Designation { get; set; }

		public int CreatedBy { get;  set; }

		public DateTime DateCreated { get; set; }

		public int? ModifiedBy { get; set; }

		public DateTime? DateModified { get; set; }


        //public byte[] Avatar { get; set; }

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
			this.DateCreated = DateTime.Now;

			this.unitOfWork = unitOfWork;
		}

		public void Load()
		{
			var memberEntity = unitOfWork.MemberRepository.GetByIdWithPerson(this.Id);
			if (memberEntity == null)
				throw new ModelNotFoundException("Member not found.");

			this.LoadFromEntity(memberEntity);
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

			var createdMember = unitOfWork.MemberRepository.Add(this.ToEntity());

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