using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Shepherd.Core.Exceptions;
using Shepherd.Data.Contracts.Infrastructure;
using Shepherd.Data.Contracts.Repository;
using Shepherd.Domain.Models;
using Shepherd.Domain.Tests.Helpers;
using Spackle;
using System.Collections.Generic;

namespace Shepherd.Domain.Tests.Models
{
	[TestClass]
	public class MemberTests
	{
		[TestMethod]
		public void Load_WhenUsingValidId_LoadSuccessfully()
		{
			// Arrange
			var generator = new RandomObjectGenerator();

			var expectedMember = MemberHelpers.CreateEntityMember();

			var mockMemberRepository = new Mock<IMemberRepository>(MockBehavior.Strict);
			mockMemberRepository
				.Setup<Entities.Member>(_ => _.GetByIdWithPerson(It.IsAny<int>()))
				.Returns(expectedMember);

			var mockUnitOfWork = new Mock<IUnitOfWork>(MockBehavior.Strict);
			mockUnitOfWork
				.SetupGet<IMemberRepository>(_ => _.MemberRepository)
				.Returns(mockMemberRepository.Object);

			var member = new Member(mockUnitOfWork.Object);
			member.Id = expectedMember.Id;

			// Act
			member.Load();

			// Assert
			mockMemberRepository.VerifyAll();
			mockUnitOfWork.VerifyAll();

			Assert.AreEqual(expectedMember.ChurchId, member.ChurchId);
			Assert.AreEqual(expectedMember.Person.FirstName, member.FirstName);
			Assert.AreEqual(expectedMember.Person.LastName, member.LastName);
		}

		[TestMethod]
		[ExpectedException(typeof(ModelNotFoundException))]
		public void Load_WhenUsingInvalidId_ThrowsModelNotFoundException()
		{
			// Arrange
			var generator = new RandomObjectGenerator();

			var expectedMember = MemberHelpers.CreateEntityMember();

			var mockMemberRepository = new Mock<IMemberRepository>(MockBehavior.Strict);
			mockMemberRepository
				.Setup<Entities.Member>(_ => _.GetByIdWithPerson(It.IsAny<int>()))
				.Returns<Entities.Member>(null);

			var mockUnitOfWork = new Mock<IUnitOfWork>(MockBehavior.Strict);
			mockUnitOfWork
				.SetupGet<IMemberRepository>(_ => _.MemberRepository)
				.Returns(mockMemberRepository.Object);

			var member = new Member(mockUnitOfWork.Object);
			member.Id = generator.Generate<int>(new HashSet<int> { expectedMember.Id });

			// Act
			member.Load();

			// Assert
			// No assertion needed, will throw exception
		}

	}
}