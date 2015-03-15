using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Shepherd.Data.Contracts;
using Shepherd.Data.Repository.Contracts;
using Shepherd.Domain.Constants;
using Shepherd.Domain.Entities.Members;
using Shepherd.Model.Models;
using Shepherd.Testing;
using Spackle;
using System;

namespace Shepherd.Domain.Tests.Entities
{
	[TestClass]
	public class MemberDetailsTests
	{
		[TestMethod]
		public void Fetch_Passes_WhenCorrectData()
		{
			// Arrange
			var generator = new RandomObjectGenerator();

			var expectedMember = EntityCreator.Create<Member>(_ =>
			{
				_.Id = 1;
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

			var mockMemberRepository = new Mock<IMemberRepository>(MockBehavior.Strict);
			mockMemberRepository
				.Setup<Member>(_ => _.GetByIdWithPerson(It.IsAny<int>()))
				.Returns(expectedMember);

			var mockUnitOfWork = new Mock<IUnitOfWork>(MockBehavior.Strict);
			mockUnitOfWork
				.SetupGet<IMemberRepository>(_ => _.MemberRepository)
				.Returns(mockMemberRepository.Object);

			// Act
			var memberDetails = new MemberDetails(mockUnitOfWork.Object);
			memberDetails.Fetch(expectedMember.Id);

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
		public void Fetch_Fails_WhenInvalidMemberId()
		{
			// Arrange
			var generator = new RandomObjectGenerator();
			var mockUnitOfWork = new Mock<IUnitOfWork>(MockBehavior.Strict);
			var actualException = default(ArgumentException);
			var invalidMemberId = -1;
			
			// Act
			try
			{
				var memberDetails = new MemberDetails(mockUnitOfWork.Object);
				memberDetails.Fetch(invalidMemberId);
				Assert.Fail("Argument exception should have been thrown");
			}
			catch (ArgumentException ex)
			{
				actualException = ex;
			}

			// Assert
			mockUnitOfWork.VerifyAll();

			Assert.IsNotNull(actualException);
			Assert.IsTrue(actualException.GetType() == typeof(ArgumentException), "Exception is not ArgumentException type");
			Assert.AreEqual(new ArgumentException(GenericValidationMessages.ArgumentException.InvalidId, MemberDetails.MemberLabels.MemberId).Message,
				actualException.Message);
		}

		[TestMethod]
		public void Update_Passes_WhenCorrectData()
		{
			// Arrange
			var generator = new RandomObjectGenerator();
			var savedMember = new Member();
			var expectedMember = EntityCreator.Create<Member>(_ =>
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

			var mockMemberRepository = new Mock<IMemberRepository>(MockBehavior.Strict);
			mockMemberRepository
				.Setup<Member>(_ => _.GetByIdWithPerson(It.IsAny<int>()))
				.Returns(expectedMember);
			mockMemberRepository
				.Setup(_ => _.Edit(It.IsAny<Member>()))
				.Callback<Member>((member) =>
				{
					savedMember = member;
				})
				.Returns(new Member());

			var mockUnitOfWork = new Mock<IUnitOfWork>(MockBehavior.Strict);
			mockUnitOfWork
				.SetupGet<IMemberRepository>(_ => _.MemberRepository)
				.Returns(mockMemberRepository.Object);

			var memberDetails = new MemberDetails(mockUnitOfWork.Object)
			{
				MemberId = expectedMember.Id,
				GeneratedId = expectedMember.GeneratedId,
				DateBabtized = expectedMember.DateBabtized,
				LastName = expectedMember.Person.LastName,
				FirstName = expectedMember.Person.FirstName,
				MiddleName = expectedMember.Person.MiddleName,
				BirthDate = expectedMember.Person.BirthDate
			};
	
			var isMemberUpdated = false;
			var expectedSaveValues = generator.Generate<int>();

			mockUnitOfWork
				.Setup(_ => _.Save())
				.Returns(expectedSaveValues)
				.Callback(() =>
				{
					isMemberUpdated = true;
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
			Assert.IsTrue(isMemberUpdated);
		}

		[Ignore]
		[TestMethod]
		public void Update_Fails_WhenMemberEntityIsNull()
		{
			// Arrange
			var mockMemberRepository = new Mock<IMemberRepository>(MockBehavior.Strict);
			mockMemberRepository
				.Setup<Member>(_ => _.GetByIdWithPerson(It.IsAny<int>()))
				.Returns<Member>(null);

			var mockUnitOfWork = new Mock<IUnitOfWork>(MockBehavior.Strict);
			mockUnitOfWork
				.SetupGet(_ => _.MemberRepository)
				.Returns(mockMemberRepository.Object);

			// Act
			MemberDetails memberDetails = new MemberDetails(mockUnitOfWork.Object);
			var actualValidationResults = memberDetails.Update();

			// Assert
			mockMemberRepository.VerifyAll();
			mockUnitOfWork.VerifyAll();

			//Assert.IsNotNull(actualValidationResults
			//	.Single(_ => _.MemberName == MemberDetails.MemberLabels.MemberId
			//		&& _.Message == MemberDetails.ValidationMessages.MemberIdMemberNull));
		}

		[Ignore]
		[TestMethod]
		public void Update_Fails_WhenPersonEntityIsNull()
		{
			// Arrange
			var generator = new RandomObjectGenerator();

			var memberEntity = EntityCreator.Create<Member>(_ =>
			{
				_.Id = generator.Generate<int>();
				_.GeneratedId = generator.Generate<string>();
				_.DateBabtized = generator.Generate<DateTime>();
				_.Person = null;
			});

			var mockMemberRepository = new Mock<IMemberRepository>(MockBehavior.Strict);
			mockMemberRepository
				.Setup<Member>(_ => _.GetByIdWithPerson(It.IsAny<int>()))
				.Returns(memberEntity);

			var mockUnitOfWork = new Mock<IUnitOfWork>(MockBehavior.Strict);
			mockUnitOfWork
				.SetupGet(_ => _.MemberRepository)
				.Returns(mockMemberRepository.Object);

			// Act
			MemberDetails memberDetails = new MemberDetails(mockUnitOfWork.Object);
			var actualValidationResults = memberDetails.Update();

			// Assert
			mockMemberRepository.VerifyAll();
			mockUnitOfWork.VerifyAll();

			//Assert.IsNotNull(actualValidationResults
			//	.Single(_ => _.MemberName == MemberDetails.MemberLabels.MemberId
			//		&& _.Message == MemberDetails.ValidationMessages.MemberIdPersonNull));
		}
	}
}