using Autofac;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Shepherd.BusinessLogic.Constants;
using Shepherd.BusinessLogic.Entities.Members;
using Shepherd.Core;
using Shepherd.Data.Contracts;
using Shepherd.Data.Infrastructure.Contracts;
using Shepherd.Data.Repository.Contracts;
using Shepherd.Model.Models;
using Spackle;
using System;
using System.Data.Entity;

namespace Shepherd.BusinessLogic.Tests.Entities
{
	[TestClass]
	public class MemberDetailsTests
	{
		[TestMethod]
		public void PassesWhen_FetchCorrectData()
		{
			// Arrange
			var generator = new RandomObjectGenerator();

			var mockMemberRepository = new Mock<IMemberRepository>(MockBehavior.Strict);
			var mockUnitOfWork = new Mock<IUnitOfWork>(MockBehavior.Strict);

			var expectedMemberId = 1;

			var expectedMember = EntityCreator.Create<Member>(_ =>
			{
				_.Id = expectedMemberId;
				_.GeneratedId = generator.Generate<string>();
				_.DateBabtized = generator.Generate<DateTime>();
				_.Person = EntityCreator.Create<Person>(__ =>
				{
					__.LastName = generator.Generate<string>();
					__.FirstName = generator.Generate<string>();
					__.MiddleName = generator.Generate<string>();
					__.BirthDate = generator.Generate<DateTime>();
				});
			});

			mockMemberRepository
				.Setup<Member>(_ => _.GetByIdWithPerson(It.IsAny<int>()))
				.Returns(expectedMember);

			// Act
			var memberDetails = new MemberDetails(mockMemberRepository.Object, mockUnitOfWork.Object);
			memberDetails.Fetch(expectedMemberId);

			// Assert
			mockMemberRepository.VerifyAll();
			mockUnitOfWork.VerifyAll();

			Assert.AreEqual(expectedMember.Id, memberDetails.MemberId);
			Assert.AreEqual(expectedMember.GeneratedId, memberDetails.GeneratedId);
			Assert.AreEqual(expectedMember.DateBabtized, memberDetails.DateBabtized);
			Assert.AreEqual(expectedMember.Person.LastName, memberDetails.LastName);
			Assert.AreEqual(expectedMember.Person.FirstName, memberDetails.FirstName);
			Assert.AreEqual(expectedMember.Person.MiddleName, memberDetails.MiddleName);
			Assert.AreEqual(expectedMember.Person.BirthDate, memberDetails.BirthDate);
		}

		[TestMethod]
		public void FailsWhen_FetchInvalidMemberId()
		{
			// Arrange
			var generator = new RandomObjectGenerator();

			var mockMemberRepository = new Mock<IMemberRepository>(MockBehavior.Strict);
			var mockUnitOfWork = new Mock<IUnitOfWork>(MockBehavior.Strict);
			var actualException = default(ArgumentException);

			var expectedMemberId = -1;
			MemberDetails memberDetails;

			// Act
			try
			{
				memberDetails = new MemberDetails(mockMemberRepository.Object, mockUnitOfWork.Object);
				memberDetails.Fetch(expectedMemberId);
			}
			catch (ArgumentException ex)
			{
				actualException = ex;
			}

			// Assert
			mockMemberRepository.VerifyAll();
			mockUnitOfWork.VerifyAll();

			Assert.IsNotNull(actualException);
			Assert.IsTrue(actualException.GetType() == typeof(ArgumentException), "Exception is not ArgumentException type");
			Assert.AreEqual(new ArgumentException(ValidationMessages.ArgumentException.InvalidId, MemberDetails.FieldLabels.MemberId).Message,
				actualException.Message);
		}

		[TestMethod]
		public void PassesWhen_UpdateSuccess()
		{
			// Arrange
			var generator = new RandomObjectGenerator();
			var mockMemberRepository = new Mock<IMemberRepository>(MockBehavior.Strict);
			var mockUnitOfWork = new Mock<IUnitOfWork>(MockBehavior.Strict);
			var memberHasBeenUpdated = false;
			var savedMember = new Member();

			var memberEntity = EntityCreator.Create<Member>(_ =>
			{
				_.Id = generator.Generate<int>();
				_.GeneratedId = generator.Generate<string>();
				_.DateBabtized = generator.Generate<DateTime>();
				_.Person = EntityCreator.Create<Person>(__ =>
				{
					__.LastName = generator.Generate<string>();
					__.FirstName = generator.Generate<string>();
					__.MiddleName = generator.Generate<string>();
					__.BirthDate = generator.Generate<DateTime>();
				});
			});

			var memberDetails = new MemberDetails(mockMemberRepository.Object, mockUnitOfWork.Object)
			{
				MemberId = memberEntity.Id,
				GeneratedId = memberEntity.GeneratedId,
				DateBabtized = memberEntity.DateBabtized,
				LastName = memberEntity.Person.LastName,
				FirstName = memberEntity.Person.FirstName,
				MiddleName = memberEntity.Person.MiddleName,
				BirthDate = memberEntity.Person.BirthDate
			};

			mockMemberRepository
				.Setup<Member>(_ => _.GetByIdWithPerson(It.IsAny<int>()))
				.Returns(memberEntity);
			mockMemberRepository
				.Setup(_ => _.Update(It.IsAny<Member>()))
				.Callback<Member>((member) =>
				{
					savedMember = member;
				})
				.Returns(new Member());

			mockUnitOfWork
				.Setup(_ => _.Commit())
				.Callback(() =>
				{
					memberHasBeenUpdated = true;
				});

			// Act
			memberDetails.FirstName = generator.Generate<string>();
			memberDetails.GeneratedId = generator.Generate<string>();
			memberDetails.DateBabtized = generator.Generate<DateTime>();
			memberDetails.Update();

			// Assert
			mockMemberRepository.VerifyAll();
			mockUnitOfWork.VerifyAll();

			Assert.AreEqual(memberDetails.FirstName, savedMember.Person.FirstName);
			Assert.AreEqual(memberDetails.GeneratedId, savedMember.GeneratedId);
			Assert.AreEqual(memberDetails.DateBabtized, savedMember.DateBabtized);
			Assert.IsTrue(memberHasBeenUpdated);
		}

		[TestMethod]
		public void FailsWhen_MemberIdDoesNotExist()
		{
			// Arrange
			var mockMemberRepository = new Mock<IMemberRepository>(MockBehavior.Strict);
			var mockUnitOfWork = new Mock<IUnitOfWork>(MockBehavior.Strict);
			MemberDetails memberDetails;
			var actualException = default(NullReferenceException);

			mockMemberRepository
				.Setup<Member>(_ => _.GetByIdWithPerson(It.IsAny<int>()))
				.Returns<Member>(null);

			// Act
			try
			{
				memberDetails = new MemberDetails(mockMemberRepository.Object, mockUnitOfWork.Object);
				memberDetails.Update();
			}
			catch (NullReferenceException ex)
			{
				actualException = ex;
			}

			// Assert
			mockMemberRepository.VerifyAll();
			mockUnitOfWork.VerifyAll();

			Assert.IsNotNull(actualException);
			Assert.IsTrue(actualException.GetType() == typeof(NullReferenceException));
			Assert.AreEqual(ValidationMessages.NullReferenceException.UpdateFailed, actualException.Message);
		}

	}
}