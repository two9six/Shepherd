using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Shepherd.Core.Exceptions;
using Shepherd.Data.Contracts.Infrastructure;
using Shepherd.Data.Contracts.Repository;
using Shepherd.Domain.Models;
using Shepherd.Domain.Tests.Helpers;
using Spackle;
using System.Collections.Generic;
using SE = Shepherd.Entities;

namespace Shepherd.Domain.Tests.Models
{
	[TestClass]
	public class MemberTests
	{
		[TestMethod]
		public void Test_Constructor()
		{
			// Arrange
			Member member;

			// Act
			member = new Member();

			// Assert
			Assert.IsNotNull(member.Address);
			Assert.IsNotNull(member.Baptizer);
			Assert.IsNotNull(member.ContactInformation);
			Assert.AreNotEqual(System.DateTime.MinValue, member.DateCreated);
		}

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

		[TestMethod]
		public void Add_WhenUsingValidData_AddSuccessfully()
		{
			// Arrange
			var mockMemberRepository = new Mock<IMemberRepository>(MockBehavior.Strict);
			mockMemberRepository
				.Setup<SE.Member>(_ => _.Add(It.IsAny<SE.Member>()))
				.Returns(new SE.Member() { Id = 1 });

			var mockUnitOfWork = new Mock<IUnitOfWork>(MockBehavior.Strict);
			mockUnitOfWork
				.SetupGet<IMemberRepository>(_ => _.MemberRepository)
				.Returns(mockMemberRepository.Object);
			mockUnitOfWork
				.Setup<int>(_ => _.Save())
				.Returns(1);

			var member = new Member(mockUnitOfWork.Object);
			MemberHelpers.FillDomainMember(member);
			member.Id = 0;

			// Act
			member.Insert();

			// Assert
			mockMemberRepository.VerifyAll();
			mockUnitOfWork.VerifyAll();
			Assert.IsTrue(member.Id > 0);
		}

		[TestMethod]
		[ExpectedException(typeof(RequiredDetailsException))]
		public void Add_WhenUsingEmptyChurchId_ThrowsRequiredDetailsException()
		{
			// Arrange
			var mockMemberRepository = new Mock<IMemberRepository>(MockBehavior.Strict);
			mockMemberRepository
				.Setup<SE.Member>(_ => _.Add(It.IsAny<SE.Member>()))
				.Returns(new SE.Member() { Id = 1 });

			var mockUnitOfWork = new Mock<IUnitOfWork>(MockBehavior.Strict);
			mockUnitOfWork
				.SetupGet<IMemberRepository>(_ => _.MemberRepository)
				.Returns(mockMemberRepository.Object);
			mockUnitOfWork
				.Setup<int>(_ => _.Save())
				.Returns(1);

			var member = new Member(mockUnitOfWork.Object);
			MemberHelpers.FillDomainMember(member);
			member.ChurchId = string.Empty;

			// Act
			member.Insert();

			// Assert
			// No assertion needed, should throw exception
		}

		[TestMethod]
		[ExpectedException(typeof(RequiredDetailsException))]
		public void Add_WhenUsingEmptyFirstName_ThrowsRequiredDetailsException()
		{
			// Arrange
			var mockMemberRepository = new Mock<IMemberRepository>(MockBehavior.Strict);
			mockMemberRepository
				.Setup<SE.Member>(_ => _.Add(It.IsAny<SE.Member>()))
				.Returns(new SE.Member() { Id = 1 });

			var mockUnitOfWork = new Mock<IUnitOfWork>(MockBehavior.Strict);
			mockUnitOfWork
				.SetupGet<IMemberRepository>(_ => _.MemberRepository)
				.Returns(mockMemberRepository.Object);
			mockUnitOfWork
				.Setup<int>(_ => _.Save())
				.Returns(1);

			var member = new Member(mockUnitOfWork.Object);
			MemberHelpers.FillDomainMember(member);
			member.FirstName = string.Empty;

			// Act
			member.Insert();

			// Assert
			// No assertion needed, should throw exception
		}

		[TestMethod]
		[ExpectedException(typeof(RequiredDetailsException))]
		public void Add_WhenUsingEmptyLastName_ThrowsRequiredDetailsException()
		{
			// Arrange
			var mockMemberRepository = new Mock<IMemberRepository>(MockBehavior.Strict);
			mockMemberRepository
				.Setup<SE.Member>(_ => _.Add(It.IsAny<SE.Member>()))
				.Returns(new SE.Member() { Id = 1 });

			var mockUnitOfWork = new Mock<IUnitOfWork>(MockBehavior.Strict);
			mockUnitOfWork
				.SetupGet<IMemberRepository>(_ => _.MemberRepository)
				.Returns(mockMemberRepository.Object);
			mockUnitOfWork
				.Setup<int>(_ => _.Save())
				.Returns(1);

			var member = new Member(mockUnitOfWork.Object);
			MemberHelpers.FillDomainMember(member);
			member.LastName = string.Empty;

			// Act
			member.Insert();

			// Assert
			// No assertion needed, should throw exception
		}

		[TestMethod]
		[ExpectedException(typeof(RequiredDetailsException))]
		public void Add_WhenUsingEmptyBirthDate_ThrowsRequiredDetailsException()
		{
			// Arrange
			var mockMemberRepository = new Mock<IMemberRepository>(MockBehavior.Strict);
			mockMemberRepository
				.Setup<SE.Member>(_ => _.Add(It.IsAny<SE.Member>()))
				.Returns(new SE.Member() { Id = 1 });

			var mockUnitOfWork = new Mock<IUnitOfWork>(MockBehavior.Strict);
			mockUnitOfWork
				.SetupGet<IMemberRepository>(_ => _.MemberRepository)
				.Returns(mockMemberRepository.Object);
			mockUnitOfWork
				.Setup<int>(_ => _.Save())
				.Returns(1);

			var member = new Member(mockUnitOfWork.Object);
			MemberHelpers.FillDomainMember(member);
			member.BirthDate = null;

			// Act
			member.Insert();

			// Assert
			// No assertion needed, should throw exception
		}

		[TestMethod]
		[ExpectedException(typeof(RequiredDetailsException))]
		public void Add_WhenUsingEmptyDateBaptized_ThrowsRequiredDetailsException()
		{
			// Arrange
			var mockMemberRepository = new Mock<IMemberRepository>(MockBehavior.Strict);
			mockMemberRepository
				.Setup<SE.Member>(_ => _.Add(It.IsAny<SE.Member>()))
				.Returns(new SE.Member() { Id = 1 });

			var mockUnitOfWork = new Mock<IUnitOfWork>(MockBehavior.Strict);
			mockUnitOfWork
				.SetupGet<IMemberRepository>(_ => _.MemberRepository)
				.Returns(mockMemberRepository.Object);
			mockUnitOfWork
				.Setup<int>(_ => _.Save())
				.Returns(1);

			var member = new Member(mockUnitOfWork.Object);
			MemberHelpers.FillDomainMember(member);
			member.DateBaptized = null;

			// Act
			member.Insert();

			// Assert
			// No assertion needed, should throw exception
		}
	}
}