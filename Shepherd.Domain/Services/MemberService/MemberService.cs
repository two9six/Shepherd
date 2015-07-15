using Shepherd.Core.Extensions;
using Shepherd.Core.Helpers;
using Shepherd.Data.Contracts.Infrastructure;
using Shepherd.Domain.Contracts.Services;
using Shepherd.Domain.Models;
using Shepherd.Domain.Models.Common;
using Shepherd.Domain.Services.MemberService.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Shepherd.Domain.Services.MemberService
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
				DateBaptized = newMember.DateBaptized.Value,
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
					BirthDate = newMember.BirthDate.Value,
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
			// TODO: Implement reflection to get member name, no magic strings
			var errors = new DataValidator().Validate(new List<DataValidationRule>()
			{
				new DataValidationRule("Church Id", member.ChurchId, true, typeof(string)),
				new DataValidationRule("First Name", member.FirstName, true, typeof(string)),
				new DataValidationRule("Last Name", member.LastName, true, typeof(string)),
				new DataValidationRule("Birth Date", member.BirthDate.TryGetString(), true, typeof(DateTime)),
				new DataValidationRule("Baptized Date", member.DateBaptized.TryGetString(), true, typeof(DateTime))
			});
			response.Errors = errors.Concat(response.Errors);
			return errors.Count() == 0;
		}
	}
}