using Spackle;
using System;
using System.Collections.Generic;

namespace Shepherd.WebApi.Tests.Helpers
{
	public sealed class DomainMemberCreator
	{
		public static IEnumerable<Domain.Models.Member> CreateCompleteMembers(int itemCount = 1)
		{
			var generator = new RandomObjectGenerator();
			var members = new List<Domain.Models.Member>();

			for (var i = 0; i < itemCount; ++i)
			{
				members.Add(new Domain.Models.Member()
				{
					Id = Math.Abs(generator.Generate<int>()),
					ChurchId = generator.Generate<string>(),
					FirstName = generator.Generate<string>(),
					LastName = generator.Generate<string>(),
					MiddleName = generator.Generate<string>(),
					BirthDate = generator.Generate<DateTime>(),
					PlaceOfBirth = generator.Generate<string>(),
					Gender = generator.Generate<string>(),
					Citizenship = generator.Generate<string>(),
					Address = new Domain.Models.Common.Address()
					{
						AddressLine1 = generator.Generate<string>(),
						AddressLine2 = generator.Generate<string>(),
						StateProvince = generator.Generate<string>(),
						City = generator.Generate<string>(),
						Country = generator.Generate<string>(),
					},
					DateBaptized = generator.Generate<DateTime>(),
					Baptizer = new Domain.Models.Baptizer()
					{
						Id = generator.Generate<int>(),
					},
					MaritalStatus = generator.Generate<string>(),
					SpouseName = generator.Generate<string>(),
					ContactInformation = new Domain.Models.Common.ContactInformation()
					{
						MobileNumber = generator.Generate<string>(),
						LandLine = generator.Generate<string>(),
						Email = generator.Generate<string>(),
					},
					Status = Domain.Models.Member.MemberStatus.Active,
					Type = Domain.Models.Member.MemberType.Member,
					Designation = Domain.Models.Member.ChurchDesignation.Member,
					CreatedBy = generator.Generate<int>(),
					DateCreated = generator.Generate<DateTime>(),
					ModifiedBy = generator.Generate<int>(),
					DateModified = generator.Generate<DateTime>()
				});
			}

			return members;
		}
	}
}