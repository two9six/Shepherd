using Shepherd.Data.Contracts.Infrastructure;
using Shepherd.Domain.Constants;
using Shepherd.Domain.Contracts.Services;
using Shepherd.Domain.Models;
using Shepherd.Domain.Models.Common;
using Shepherd.Domain.Services.Models;
using Shepherd.Domain.Services.Models.Criteria;
using Shepherd.Domain.Services.Models.ServiceResponses;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Shepherd.Domain.Services
{
	public class MemberService : IMemberService
	{
		private readonly IUnitOfWork unitOfWork;

		public MemberService(IUnitOfWork unitOfWork)
		{
			this.unitOfWork = unitOfWork;
		}

		public ServiceResponse AddMember(Member member)
		{
			// TODO: Implement transaction

			var serviceResponse = new ServiceResponse();

			if (!this.IsValidateAddMember(member, serviceResponse))
				return serviceResponse;

			var createdMember = unitOfWork.MemberRepository.Add(new Entities.Member
			{
				ChurchId = member.ChurchId,
				DateBaptized = member.DateBaptized,
				BaptizedById = member.Baptizer.Id,
				MaritalStatus = member.MaritalStatus,
				SpouseName = member.SpouseName,
				LandLine = member.ContactInformation.LandLine,
				MobileNumber = member.ContactInformation.MobileNumber,
				Email = member.ContactInformation.Email,
				StatusId = (int)member.Status,
				TypeId = (int)member.Type,
				DesignationId = (int)member.Designation,
				DateCreated = DateTime.Now,
				Person = new Entities.Person
				{
					FirstName = member.FirstName,
					LastName = member.LastName,
					MiddleName = member.MiddleName,
					BirthDate = member.BirthDate,
					PlaceOfBirth = member.PlaceOfBirth,
					Gender = member.Gender,
					Citizenship = member.Citizenship,
					AddressLine1 = member.Address.AddressLine1,
					AddressLine2 = member.Address.AddressLine2,
					City = member.Address.City,
					StateProvince = member.Address.StateProvince,
					Country = member.Address.Country,
					CreatedBy = 1,
					DateCreated = DateTime.Now
				},
				CreatedBy = 1
			});

			unitOfWork.Save();

			member.Id = createdMember.Id;

			return serviceResponse;
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