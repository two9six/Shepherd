using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Shepherd.Data.Contracts.Infrastructure;
using Shepherd.Data.Contracts.Repository;
using Shepherd.Domain.Models;
using Shepherd.Domain.Services;
using Spackle;
using System;
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
				DateBaptized = generator.Generate<DateTime>(),
				MaritalStatus = generator.Generate<string>(),
				SpouseName = generator.Generate<string>(),
				StatusId = generator.Generate<int>(),
				MemberTypeId = generator.Generate<int>(),
				ChurchDesignationId = generator.Generate<int>()
			};

			// Act
			memberService.AddMember(member);

			// Assert
			mockMemberRepository.VerifyAll();
			mockUnitOfWork.VerifyAll();

			Assert.IsTrue(member.Id > 0);
		}
	}
}