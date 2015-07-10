using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Shepherd.Data.Contracts.Infrastructure;
using Shepherd.Data.Contracts.Repository;
using Shepherd.Domain.Models;
using Shepherd.Domain.Services;
using Shepherd.Domain.Services.Models.Criteria;
using Spackle;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using SE = Shepherd.Entities;

namespace Shepherd.Domain.Tests.Services
{
	[TestClass]
	public class MemberServiceTests
	{
		// Unit Test Naming Convention: MethodName_StateUnderTest_ExpectedBehavior

		[TestMethod]
		public void AddMember_UsingValidData_SavesSuccessfully()
		{
			// Arrange
			var generator = new RandomObjectGenerator();

			var mockMemberRepository = new Mock<IMemberRepository>(MockBehavior.Strict);
			mockMemberRepository
				.Setup<SE.Member>(_ => _.Add(It.IsAny<SE.Member>()))
				.Returns((SE.Member pMember) =>
				{
					pMember.Id = Math.Abs(generator.Generate<int>());
					return pMember;
				});

			var mockUnitOfWork = new Mock<IUnitOfWork>(MockBehavior.Strict);
			mockUnitOfWork
				.SetupGet<IMemberRepository>(_ => _.MemberRepository)
				.Returns(mockMemberRepository.Object);
			mockUnitOfWork
				.Setup(_ => _.Save())
				.Returns(It.IsAny<int>);

			var memberService = new MemberService(mockUnitOfWork.Object);

			var member = new Member()
			{
				ChurchId = generator.Generate<string>(),
				FirstName = generator.Generate<string>(),
				LastName = generator.Generate<string>(),
				BirthDate = generator.Generate<DateTime>(),
				DateBaptized = generator.Generate<DateTime>(),
				MaritalStatus = generator.Generate<string>(),
				SpouseName = generator.Generate<string>(),
				Status = Member.MemberStatus.Active,
				Type = Member.MemberType.Member,
				Designation = Member.ChurchDesignation.Member
			};

			// Act
			memberService.AddMember(member);

			// Assert
			mockMemberRepository.VerifyAll();
			mockUnitOfWork.VerifyAll();

			Assert.IsTrue(member.Id > 0);
		}

		[TestMethod]
		public void AddMember_WithEmptyRequiredFields_RespondWithValidationErrors()
		{	
			// Arrange
			const int ExpectedValidationError = 5;
			var generator = new RandomObjectGenerator();
			var mockUnitOfWork = new Mock<IUnitOfWork>(MockBehavior.Strict);

			var memberService = new MemberService(mockUnitOfWork.Object);

			
			var member = new Member()
			{
				MaritalStatus = generator.Generate<string>(),
				SpouseName = generator.Generate<string>(),
				Status = Member.MemberStatus.Active,
				Type = Member.MemberType.Member,
				Designation = Member.ChurchDesignation.Member
			};

			// Act
			var response = memberService.AddMember(member);

			// Assert
			mockUnitOfWork.VerifyAll();

			Assert.IsTrue(member.Id == 0);
			Assert.AreEqual(response.Errors.Count(), ExpectedValidationError);
		}

		[TestMethod]
		public void GetMembers_UsingValidSearchCriteria_SearchSuccessfully()
		{
			// Arrange
			var generator = new RandomObjectGenerator();
			var expectedMembers = new List<SE.Member> { 
				new SE.Member 
				{					
					Id = Math.Abs(generator.Generate<int>()),
					StatusId = (int)Member.MemberStatus.Active,
					TypeId = (int)Member.MemberType.Member,
					DesignationId = (int)Member.ChurchDesignation.Member,
					Person = new SE.Person
					{
						Id = Math.Abs(generator.Generate<int>()),
						FirstName = generator.Generate<string>(),
						LastName = generator.Generate<string>()
					}
				}
			};

			var mockMemberRepository = new Mock<IMemberRepository>(MockBehavior.Strict);
			mockMemberRepository
				.Setup<IEnumerable<SE.Member>>(_ => _.FindBy(It.IsAny<Expression<Func<SE.Member, bool>>>()))
				.Returns(expectedMembers);

			var mockUnitOfWork = new Mock<IUnitOfWork>(MockBehavior.Strict);
			mockUnitOfWork
				.SetupGet<IMemberRepository>(_ => _.MemberRepository)
				.Returns(mockMemberRepository.Object);

			var memberService = new MemberService(mockUnitOfWork.Object);

			var criteria = new GetMembersCriteria();

			// Act
			var result = memberService.GetMembers(criteria);

			// Assert
			mockMemberRepository.VerifyAll();
			mockUnitOfWork.VerifyAll();

			Assert.IsTrue(result.Errors.Count() == 0);
			Assert.AreEqual(expectedMembers.Count, result.Members.Count());
			Assert.AreEqual(Member.MemberStatus.Active, result.Members.ElementAt(0).Status);
			Assert.AreEqual(Member.MemberType.Member, result.Members.ElementAt(0).Type);
			Assert.AreEqual(Member.ChurchDesignation.Member, result.Members.ElementAt(0).Designation);
		}
	}
}