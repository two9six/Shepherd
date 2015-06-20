using Shepherd.Core.Models;
using Shepherd.Data.Contracts.Infrastructure;
using Shepherd.Domain.Contracts.Services;
using Shepherd.Domain.Models;
using System;

namespace Shepherd.Domain.Services
{
	public class MemberService : IMemberService
	{
		private readonly IUnitOfWork unitOfWork;

		public MemberService(IUnitOfWork unitOfWork)
		{
			this.unitOfWork = unitOfWork;
		}

		public ServiceResult AddMember(Member member)
		{
			// TODO: Implement transaction

			var serviceResult = new ServiceResult();

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
				MemberTypeId = (int)member.Type,
				ChurchDesignationId = member.ChurchDesignationId,
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

			return serviceResult;
		}
	}
}