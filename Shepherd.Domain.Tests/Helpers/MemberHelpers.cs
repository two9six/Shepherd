using Shepherd.Core.Enums;
using Spackle;
using System;

namespace Shepherd.Domain.Tests.Helpers
{
	public static class MemberHelpers
	{
		public static RandomObjectGenerator generator = new RandomObjectGenerator();

		public static Entities.Member CreateEntityMember()
		{
			return new Entities.Member
			{
				Id = Math.Abs(generator.Generate<int>()),
				ChurchId = generator.Generate<string>(),
				StatusId = (int)MemberStatus.Active,
				TypeId = (int)MemberType.Member,
				DesignationId = (int)ChurchDesignation.Member,
				Person = new Entities.Person
				{
					Id = Math.Abs(generator.Generate<int>()),
					FirstName = generator.Generate<string>(),
					LastName = generator.Generate<string>()
				}
			};
		}
	}
}