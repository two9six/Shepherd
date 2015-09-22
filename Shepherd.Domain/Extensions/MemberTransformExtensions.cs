using Shepherd.Core.Enums;
using Shepherd.Domain.Models;
using System;

namespace Shepherd.Domain.Extensions
{
	public static class MemberTransformExtensions
	{
		public static void LoadFromEntity(this Member member, Entities.Member memberEntity)
		{
			if (memberEntity != null)
			{
				member.Id = memberEntity.Id;
				member.ChurchId = memberEntity.ChurchId;
				member.FirstName = memberEntity.Person.FirstName;
				member.LastName = memberEntity.Person.LastName;
				member.MiddleName = memberEntity.Person.MiddleName;
				member.BirthDate = memberEntity.Person.BirthDate;
				member.PlaceOfBirth = memberEntity.Person.PlaceOfBirth;
				member.Gender = memberEntity.Person.Gender;
				member.Citizenship = memberEntity.Person.Citizenship;
				member.Address = new Address()
				{
					AddressLine1 = memberEntity.Person.AddressLine1,
					AddressLine2 = memberEntity.Person.AddressLine2,
					City = memberEntity.Person.City,
					StateProvince = memberEntity.Person.StateProvince,
					Country = memberEntity.Person.Country
				};
				member.Baptizer = new Baptizer()
				{
					Id = memberEntity.BaptizedById
				};
				member.MaritalStatus = memberEntity.MaritalStatus;
				member.SpouseName = memberEntity.SpouseName;
				member.ContactInformation = new ContactInformation
				{
					LandLine = memberEntity.LandLine,
					MobileNumber = memberEntity.MobileNumber,
					Email = memberEntity.Email
				};
				member.MemberStatus = (MemberStatuses)memberEntity.MemberStatusId;
				member.Designation = (Designations)memberEntity.DesignationId;
				member.CreatedBy = memberEntity.CreatedBy;
				member.DateCreated = memberEntity.DateCreated;
				member.ModifiedBy = memberEntity.ModifiedBy;
				member.DateModified = memberEntity.DateModified;
			}
		}

		public static Entities.Member ToEntity(this Member member)
		{
			var memberEntity = new Entities.Member();

			if (member != null)
			{
				memberEntity = new Entities.Member()
				{
					ChurchId = member.ChurchId,
					DateBaptized = member.DateBaptized.Value,
					BaptizedById = member.Baptizer.Id,
					MaritalStatus = member.MaritalStatus,
					SpouseName = member.SpouseName,
					LandLine = member.ContactInformation.LandLine,
					MobileNumber = member.ContactInformation.MobileNumber,
					Email = member.ContactInformation.Email,
					MemberStatusId = (byte)member.MemberStatus,
					DesignationId = (byte)member.Designation,
					DateCreated = DateTime.Now,
					Person = new Entities.Person
					{
						FirstName = member.FirstName,
						LastName = member.LastName,
						MiddleName = member.MiddleName,
						BirthDate = member.BirthDate.Value,
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
				};
			}

			return memberEntity;
		}
	}
}