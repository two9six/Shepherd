using Shepherd.Data.Contracts.Infrastructure;
using Shepherd.Domain.Constants;
using Shepherd.Domain.Contracts.Services;
using Shepherd.Domain.Models;
using Shepherd.Domain.Models.Common;
using Shepherd.Domain.Services.Models;
using Shepherd.Domain.Services.Models.Criteria;
using Shepherd.Domain.Services.Models.ServiceResponses;
using Shepherd.Domain.Services.Models.ServiceResponses.Members;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Shepherd.Domain.Services
{
	public sealed class MemberService : IMemberService
	{
		private readonly IUnitOfWork unitOfWork;

		public MemberService(IUnitOfWork unitOfWork)
		{
			this.unitOfWork = unitOfWork;
		}

		public AddMemberServiceResponse AddMember(Member newMember)
		{
			var serviceResponse = new AddMemberServiceResponse();

			if (!this.IsValidateAddMember(newMember, serviceResponse))
				return serviceResponse;

			var createdMember = unitOfWork.MemberRepository.Add(new Entities.Member
			{
				ChurchId = newMember.ChurchId,
				DateBaptized = newMember.DateBaptized,
				BaptizedById = newMember.Baptizer.Id,
				MaritalStatus = newMember.MaritalStatus,
				SpouseName = newMember.SpouseName,
				LandLine = newMember.ContactInformation.LandLine,
				MobileNumber = newMember.ContactInformation.MobileNumber,
				Email = newMember.ContactInformation.Email,
				StatusId = (int)newMember.Status,
				TypeId = (int)newMember.Type,
				DesignationId = (int)newMember.Designation,
				DateCreated = DateTime.Now,
				Person = new Entities.Person
				{
					FirstName = newMember.FirstName,
					LastName = newMember.LastName,
					MiddleName = newMember.MiddleName,
					BirthDate = newMember.BirthDate,
					PlaceOfBirth = newMember.PlaceOfBirth,
					Gender = newMember.Gender,
					Citizenship = newMember.Citizenship,
					AddressLine1 = newMember.Address.AddressLine1,
					AddressLine2 = newMember.Address.AddressLine2,
					City = newMember.Address.City,
					StateProvince = newMember.Address.StateProvince,
					Country = newMember.Address.Country,
					CreatedBy = 1,
					DateCreated = DateTime.Now
				},
				CreatedBy = 1
			});

			unitOfWork.Save();

			newMember.Id = createdMember.Id;

			return new AddMemberServiceResponse
			{
				Member = newMember
			};
		}

		public GetMembersServiceResponse GetMembers(GetMembersCriteria criteria)
		{
			var members = unitOfWork.MemberRepository
				.FindBy(_ => _.Person.FirstName.Contains(criteria.FirstName))
				.OrderByDescending(_ => _.DateCreated)
				.Select(_ => new Member()
				{
					Id = _.Id,
					ChurchId = _.ChurchId,
					FirstName = _.Person.FirstName,
					LastName = _.Person.LastName,
					MiddleName = _.Person.MiddleName,
					BirthDate = _.Person.BirthDate,
					PlaceOfBirth = _.Person.PlaceOfBirth,
					Gender = _.Person.Gender,
					Citizenship = _.Person.Citizenship,
					Address = new Address
					{
						AddressLine1 = _.Person.AddressLine1,
						AddressLine2 = _.Person.AddressLine2,
						City = _.Person.City,
						StateProvince = _.Person.StateProvince,
						Country = _.Person.Country
					},
					Baptizer = new Baptizer
					{
						Id = _.BaptizedById
					},
					MaritalStatus = _.MaritalStatus,
					SpouseName = _.SpouseName,
					ContactInformation = new ContactInformation
					{
						LandLine = _.LandLine,
						MobileNumber = _.MobileNumber,
						Email = _.Email
					},
					Status = (Member.MemberStatus)_.StatusId,
					Type = (Member.MemberType)_.TypeId,
					Designation = (Member.ChurchDesignation)_.DesignationId,
					CreatedBy = _.CreatedBy,
					DateCreated = _.DateCreated,
					ModifiedBy = _.ModifiedBy,
					DateModified = _.DateModified
				}).ToList();

			return new GetMembersServiceResponse
			{
				Members = members
			};
		}

		private bool IsValidateAddMember(Member member, ServiceResponse response)
		{
			var errors = new List<string>();

			if (string.IsNullOrEmpty(member.ChurchId))
				errors.Add(string.Format(GenericValidationMessages.Common.CannotBeNullOrEmpty, "Church Id"));

			if (string.IsNullOrEmpty(member.FirstName))
				errors.Add(string.Format(GenericValidationMessages.Common.CannotBeNullOrEmpty, "First Name"));

			if (string.IsNullOrEmpty(member.LastName))
				errors.Add(string.Format(GenericValidationMessages.Common.CannotBeNullOrEmpty, "Last Name"));

			if (member.BirthDate == DateTime.MinValue)
				errors.Add(string.Format(GenericValidationMessages.Common.CannotBeNullOrEmpty, "Birth Date"));

			if (member.DateBaptized == DateTime.MinValue)
				errors.Add(string.Format(GenericValidationMessages.Common.CannotBeNullOrEmpty, "Baptized Date"));

			response.Errors = response.Errors.ToList().Concat(errors.ToList());

			return errors.Count == 0;
		}
	}
}