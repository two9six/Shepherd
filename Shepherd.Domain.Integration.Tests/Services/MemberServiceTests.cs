﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shepherd.Domain.Services;
using Shepherd.Domain.Models;
using Spackle;
using Shepherd.Data.Infrastructure;

namespace Shepherd.Domain.Integration.Tests.Services
{
	[TestClass]
	public class MemberServiceTests
	{
		[TestMethod]
		public void AddMember_UsingValidData_SavesSuccessfully()
		{
			var generator = new RandomObjectGenerator();

			var unitOfWork = new UnitOfWork();
			var memberService = new MemberService(unitOfWork);

			var member = new Member()
			{
				FirstName = "XXX",
				LastName = "YYY",
				BirthDate = DateTime.Now,
				Gender = "M",
				CreatedBy = 1,
				ChurchId = "GUAXXX",
				DateBaptized = DateTime.Now,
				Baptizer = new Baptizer
				{
					Id = 1
				},
				Status = Member.MemberStatus.Active,
				Type = Member.MemberType.Member,
				ChurchDesignationId = 1
			};

			// Act
			var result = memberService.AddMember(member);

			Assert.AreEqual(result.ValidationResults.Count, 0);
		}
	}
}