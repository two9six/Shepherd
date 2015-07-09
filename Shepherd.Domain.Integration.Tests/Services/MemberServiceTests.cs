using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shepherd.Data.Infrastructure;
using Shepherd.Domain.Models;
using Shepherd.Domain.Services;
using Shepherd.Domain.Services.Models.Criteria;
using Spackle;
using System;
using System.Linq;

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
				Designation = Member.ChurchDesignation.Member
			};

			// Act
			var result = memberService.AddMember(member);

			Assert.AreEqual(result.Errors.ToList().Count, 0);
		}

		[TestMethod]
		public void GetMembers_UsingValidFirstNameCriteria_RetrievesOneRecord()
		{
			var generator = new RandomObjectGenerator();

			var unitOfWork = new UnitOfWork();
			var searchMembersCriteria = new GetMembersCriteria { FirstName = "Liliana" };
			var memberService = new MemberService(unitOfWork);

			// Act
			var result = memberService.GetMembers(searchMembersCriteria);

			Assert.AreEqual(result.Errors.Count(), 0);
			Assert.AreEqual(result.Members.Count(), 1);
		}

		[TestMethod]
		public void GetMembers_UsingEmptyFirstNameCriteria_RetrievesAllRecord()
		{
			var generator = new RandomObjectGenerator();

			var unitOfWork = new UnitOfWork();
			var searchMembersCriteria = new GetMembersCriteria { FirstName = "" };
			var memberService = new MemberService(unitOfWork);

			// Act
			var result = memberService.GetMembers(searchMembersCriteria);

			Assert.AreEqual(result.Errors.Count(), 0);
			Assert.IsTrue(result.Members.Count() > 1);
		}
	}
}