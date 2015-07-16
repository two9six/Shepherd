using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Shepherd.Data.Contracts.Infrastructure;
using Shepherd.Data.Contracts.Repository;
using Shepherd.Domain.Models;
using Spackle;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Shepherd.Domain.Tests.Services
{
	[TestClass]
	public class MemberServiceTests
	{
		// Unit Test Naming Convention: MethodName_StateUnderTest_ExpectedBehavior

		//[TestMethod]
		//public void AddMember_WhenUsingValidData_SavesSuccessfully()
		//{
		//	// Arrange
		//	var generator = new RandomObjectGenerator();
		//	var expectedMemberId = Math.Abs(generator.Generate<int>());
		//	var mockMemberRepository = new Mock<IMemberRepository>(MockBehavior.Strict);

		//	mockMemberRepository
		//		.Setup<Entities.Member>(_ => _.Add(It.IsAny<Entities.Member>()))
		//		.Returns((Entities.Member pMember) =>
		//		{
		//			pMember.Id = expectedMemberId;
		//			return pMember;
		//		});

		//	var mockUnitOfWork = new Mock<IUnitOfWork>(MockBehavior.Strict);
		//	mockUnitOfWork
		//		.SetupGet<IMemberRepository>(_ => _.MemberRepository)
		//		.Returns(mockMemberRepository.Object);
		//	mockUnitOfWork
		//		.Setup(_ => _.Save())
		//		.Returns(It.IsAny<int>);

		//	var memberService = new MemberService(mockUnitOfWork.Object);

		//	var member = new Member()
		//	{
		//		ChurchId = generator.Generate<string>(),
		//		FirstName = generator.Generate<string>(),
		//		LastName = generator.Generate<string>(),
		//		BirthDate = generator.Generate<DateTime>(),
		//		DateBaptized = generator.Generate<DateTime>(),
		//		MaritalStatus = generator.Generate<string>(),
		//		SpouseName = generator.Generate<string>(),
		//		Status = Member.MemberStatus.Active,
		//		Type = Member.MemberType.Member,
		//		Designation = Member.ChurchDesignation.Member
		//	};

		//	// Act
		//	var actualResult = memberService.AddMember(member);

		//	// Assert
		//	mockMemberRepository.VerifyAll();
		//	mockUnitOfWork.VerifyAll();

		//	Assert.AreEqual(expectedMemberId, actualResult.Member.Id);
		//}

		//[TestMethod]
		//public void AddMember_WhenUsingEmptyOnRequiredFields_ReturnsValidationErrors()
		//{	
		//	// Arrange
		//	const int ExpectedValidationError = 5;
		//	var generator = new RandomObjectGenerator();
		//	var mockUnitOfWork = new Mock<IUnitOfWork>(MockBehavior.Strict);

		//	var memberService = new MemberService(mockUnitOfWork.Object);
		
		//	var member = new Member()
		//	{
		//		MaritalStatus = generator.Generate<string>(),
		//		SpouseName = generator.Generate<string>(),
		//		Status = Member.MemberStatus.Active,
		//		Type = Member.MemberType.Member,
		//		Designation = Member.ChurchDesignation.Member
		//	};

		//	// Act
		//	var actualResult = memberService.AddMember(member);

		//	// Assert
		//	mockUnitOfWork.VerifyAll();

		//	Assert.IsTrue(member.Id == 0);
		//	Assert.AreEqual(actualResult.Errors.Count(), ExpectedValidationError);
		//}

		//[TestMethod]
		//public void GetMembers_WhenUsingValidSearchCriteria_SearchSuccessfully()
		//{
		//	// Arrange
		//	var generator = new RandomObjectGenerator();
		//	var searchName = string.Empty;
		//	var searchChurchId = string.Empty;
		//	var expectedMembers = new List<Entities.Member> { 
		//		new Entities.Member 
		//		{					
		//			Id = Math.Abs(generator.Generate<int>()),
		//			StatusId = (int)Member.MemberStatus.Active,
		//			TypeId = (int)Member.MemberType.Member,
		//			DesignationId = (int)Member.ChurchDesignation.Member,
		//			Person = new Entities.Person
		//			{
		//				Id = Math.Abs(generator.Generate<int>()),
		//				FirstName = generator.Generate<string>(),
		//				LastName = generator.Generate<string>()
		//			}
		//		}
		//	};

		//	var mockMemberRepository = new Mock<IMemberRepository>(MockBehavior.Strict);
		//	mockMemberRepository
		//		.Setup<IEnumerable<Entities.Member>>(_ => _.FindBy(It.IsAny<Expression<Func<Entities.Member, bool>>>()))
		//		.Returns(expectedMembers);

		//	var mockUnitOfWork = new Mock<IUnitOfWork>(MockBehavior.Strict);
		//	mockUnitOfWork
		//		.SetupGet<IMemberRepository>(_ => _.MemberRepository)
		//		.Returns(mockMemberRepository.Object);

		//	var memberService = new MemberService(mockUnitOfWork.Object);

		//	// Act
		//	var result = memberService.GetMembers(searchName, searchChurchId);

		//	// Assert
		//	mockMemberRepository.VerifyAll();
		//	mockUnitOfWork.VerifyAll();

		//	Assert.IsTrue(result.Errors.Count() == 0);
		//	Assert.AreEqual(expectedMembers.Count, result.Members.Count());
		//	Assert.AreEqual(Member.MemberStatus.Active, result.Members.ElementAt(0).Status);
		//	Assert.AreEqual(Member.MemberType.Member, result.Members.ElementAt(0).Type);
		//	Assert.AreEqual(Member.ChurchDesignation.Member, result.Members.ElementAt(0).Designation);
		//}
	}
}