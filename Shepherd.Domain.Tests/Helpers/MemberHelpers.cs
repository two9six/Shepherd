using Shepherd.Core.Enums;
using Shepherd.Domain.Models;
using Spackle;
using System;

namespace Shepherd.Domain.Tests.Helpers
{
	public static class MemberHelpers
	{
		public static RandomObjectGenerator generator = new RandomObjectGenerator();

		public static Entities.Member CreateEntityMember()
		{
			return new Entities.Member()
			{
				ChurchId = generator.Generate<string>(),
				DateBaptized = generator.Generate<DateTime>(),
				BaptizerId = Math.Abs(generator.Generate<int>()),
				MaritalStatusId = (byte)MaritalStatuses.Single,
				SpouseName = generator.Generate<string>(),
				LandLine = generator.Generate<string>(),
				MobileNumber = generator.Generate<string>(),
				Email = generator.Generate<string>(),
				MemberStatusId = (byte)MemberStatuses.Active,
				DesignationId = (byte)Designations.Member,
				DateCreated = generator.Generate<DateTime>(),
				CreatedBy = Math.Abs(generator.Generate<int>()),
				Person = new Entities.Person
				{
					FirstName = generator.Generate<string>(),
					LastName = generator.Generate<string>(),
					MiddleName = generator.Generate<string>(),
					BirthDate = generator.Generate<DateTime>(),
					PlaceOfBirth = generator.Generate<string>(),
					Gender = generator.Generate<string>().Substring(0, 1),
					Citizenship = generator.Generate<string>(),
					AddressLine1 = generator.Generate<string>(),
					AddressLine2 = generator.Generate<string>(),
					City = generator.Generate<string>(),
					StateProvince = generator.Generate<string>(),
					Country = generator.Generate<string>(),
					CreatedBy = Math.Abs(generator.Generate<int>()),
					DateCreated = generator.Generate<DateTime>()
				}				
			};
		}

		public static Member CreateDomainMember()
		{
			return new Member
			{
				Id = Math.Abs(generator.Generate<int>()),
				ChurchId = generator.Generate<string>(),
				FirstName = generator.Generate<string>(),
				LastName = generator.Generate<string>(),
				MiddleName = generator.Generate<string>(),
				BirthDate = generator.Generate<DateTime>(),
				PlaceOfBirth = generator.Generate<string>(),
				Gender = generator.Generate<string>().Substring(0, 1),
				Citizenship = generator.Generate<string>(),
				Address = new Address()
				{
					AddressLine1 = generator.Generate<string>(),
					AddressLine2 = generator.Generate<string>(),
					City = generator.Generate<string>(),
					StateProvince = generator.Generate<string>(),
					Country = generator.Generate<string>()
				},
				DateBaptized = generator.Generate<DateTime>(),
				Baptizer = new Baptizer()
				{
					Id = Math.Abs(generator.Generate<int>())
				},
				MaritalStatus = MaritalStatuses.Single,
				SpouseName = generator.Generate<string>(),
				ContactInformation = new ContactInformation
				{
					LandLine = generator.Generate<string>(),
					MobileNumber = generator.Generate<string>(),
					Email = generator.Generate<string>()
				},
				MemberStatus = MemberStatuses.Active,
				Designation = Designations.Member,
				CreatedBy = Math.Abs(generator.Generate<int>()),
				DateCreated = generator.Generate<DateTime>(),
				ModifiedBy = Math.Abs(generator.Generate<int>()),
				DateModified = generator.Generate<DateTime>()
			};
		}
	}
}