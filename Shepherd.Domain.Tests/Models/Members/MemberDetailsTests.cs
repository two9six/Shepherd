using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Shepherd.Data.Contracts.Infrastructure;
using Shepherd.Data.Contracts.Repository;
using Shepherd.Domain.Constants;
using Shepherd.Domain.Models.Members;
using Shepherd.Testing;
using Spackle;
using System;
using System.Linq;
using SE = Shepherd.Entities;

namespace Shepherd.Domain.Tests.Models.Members
{
	[TestClass]
	public class MemberDetailsTests
	{
		//[TestMethod]
		//public void Fetch_UsingValidMemberId_GeneratesCorrectData()
		//{
		//	// Arrange
		//	var generator = new RandomObjectGenerator();

		//	var expectedMember = EntityCreator.Create<Member>(_ =>
		//	{
		//		_.Id = 1;
		//		_.GeneratedId = generator.Generate<string>();
		//		_.DateBabtized = generator.Generate<DateTime>();
		//		_.Person = EntityCreator.Create<Person>(__ =>
		//		{
		//			__.LastName = generator.Generate<string>();
		//			__.FirstName = generator.Generate<string>();
		//			__.MiddleName = generator.Generate<string>();
		//			__.BirthDate = generator.Generate<DateTime>();
		//		});
		//	});

		//	var mockMemberRepository = new Mock<IMemberRepository>(MockBehavior.Strict);
		//	mockMemberRepository
		//		.Setup<Member>(_ => _.GetByIdWithPerson(It.IsAny<int>()))
		//		.Returns(expectedMember);

		//	var mockUnitOfWork = new Mock<IUnitOfWork>(MockBehavior.Strict);
		//	mockUnitOfWork
		//		.SetupGet<IMemberRepository>(_ => _.MemberRepository)
		//		.Returns(mockMemberRepository.Object);

		//	// Act
		//	var memberDetails = new MemberDetails(mockUnitOfWork.Object);
		//	memberDetails.GeneratedId = generator.Generate<string>();
		//	memberDetails.Fetch(expectedMember.Id);

		//	// Assert
		//	mockMemberRepository.VerifyAll();
		//	mockUnitOfWork.VerifyAll();

		//	Assert.AreEqual(expectedMember.Id, memberDetails.MemberId);
		//	Assert.AreEqual(expectedMember.GeneratedId, memberDetails.GeneratedId);
		//	Assert.AreEqual(expectedMember.DateBabtized, memberDetails.DateBabtized);
		//	Assert.AreEqual(expectedMember.Person.LastName, memberDetails.LastName);
		//	Assert.AreEqual(expectedMember.Person.FirstName, memberDetails.FirstName);
		//	Assert.AreEqual(expectedMember.Person.MiddleName, memberDetails.MiddleName);
		//	Assert.AreEqual(expectedMember.Person.BirthDate, memberDetails.BirthDate);
		//}

		[TestMethod]
		public void Fetch_UsingNegativeMemberId_ThrowsArgumentException()
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
			Assert.IsInstanceOfType(actualException, typeof(ArgumentException), "Exception is not ArgumentException type");
			Assert.AreEqual(new ArgumentException(GenericValidationMessages.ArgumentException.InvalidId, MemberDetails.MemberLabels.MemberId).Message,
				actualException.Message);
		}

		[TestMethod]
		public void Update_UsingValidData_ExecuteUnitOfWorkSaveMethod()
		{
			// Arrange
			var generator = new RandomObjectGenerator();
			var savedMember = new SE.Member();
			var expectedMember = EntityCreator.Create<SE.Member>(_ =>
			{
				_.Id = generator.Generate<int>();
				_.ChurchId = generator.Generate<string>();
				_.DateBabtized = generator.Generate<DateTime>();
				_.Person = EntityCreator.Create<SE.Person>(__ =>
				{
					__.LastName = generator.Generate<string>();
					__.FirstName = generator.Generate<string>();
					__.MiddleName = generator.Generate<string>();
					__.BirthDate = generator.Generate<DateTime>();
				});
			});

			var mockMemberRepository = new Mock<IMemberRepository>(MockBehavior.Strict);
			mockMemberRepository
				.Setup<SE.Member>(_ => _.GetByIdWithPerson(It.IsAny<int>()))
				.Returns(expectedMember);
			mockMemberRepository
				.Setup(_ => _.Edit(It.IsAny<SE.Member>()))
				.Callback<SE.Member>((member) =>
				{
					savedMember = member;
				})
				.Returns(new SE.Member());

			var mockUnitOfWork = new Mock<IUnitOfWork>(MockBehavior.Strict);
			mockUnitOfWork
				.SetupGet<IMemberRepository>(_ => _.MemberRepository)
				.Returns(mockMemberRepository.Object);

			var memberDetails = new MemberDetails(mockUnitOfWork.Object)
			{
				MemberId = expectedMember.Id,
				ChurchId = expectedMember.ChurchId,
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
			memberDetails.ChurchId = generator.Generate<string>();
			memberDetails.DateBabtized = generator.Generate<DateTime>();
			memberDetails.Update();

			// Assert
			mockMemberRepository.VerifyAll();
			mockUnitOfWork.VerifyAll();

			Assert.AreEqual(memberDetails.FirstName, savedMember.Person.FirstName);
			Assert.AreEqual(memberDetails.ChurchId, savedMember.ChurchId);
			Assert.AreEqual(memberDetails.DateBabtized, savedMember.DateBabtized);
			Assert.IsTrue(isMemberUpdated);
		}

		[TestMethod]
		public void Update_UsingNonExistingMember_ReturnsValidationError()
		{
			// Arrange
			var generator = new RandomObjectGenerator();
			var mockMemberRepository = new Mock<IMemberRepository>(MockBehavior.Strict);
			mockMemberRepository
				.Setup<SE.Member>(_ => _.GetByIdWithPerson(It.IsAny<int>()))
				.Returns<SE.Member>(null);

			var mockUnitOfWork = new Mock<IUnitOfWork>(MockBehavior.Strict);
			mockUnitOfWork
				.SetupGet(_ => _.MemberRepository)
				.Returns(mockMemberRepository.Object);

			// Act
			MemberDetails memberDetails = new MemberDetails(mockUnitOfWork.Object);
			memberDetails.ChurchId = generator.Generate<string>();
			memberDetails.FirstName = generator.Generate<string>();
			memberDetails.LastName = generator.Generate<string>();
			var actualProcessResults = memberDetails.Update();

			// Assert
			mockMemberRepository.VerifyAll();
			mockUnitOfWork.VerifyAll();

			Assert.IsNotNull(actualProcessResults.ValidationResults
				.Single(_ => _.MemberName == MemberDetails.MemberLabels.MemberId
					&& _.Message == MemberDetails.ValidationMessages.MemberIdMemberNull));
		}

		[TestMethod]
		public void Update_UsingNonExistingPerson_ReturnsValidationError()
		{
			// Arrange
			var generator = new RandomObjectGenerator();

			var memberEntity = EntityCreator.Create<SE.Member>(_ =>
			{
				_.Id = generator.Generate<int>();
				_.ChurchId = generator.Generate<string>();
				_.DateBabtized = generator.Generate<DateTime>();
				_.Person = null;
			});

			var mockMemberRepository = new Mock<IMemberRepository>(MockBehavior.Strict);
			mockMemberRepository
				.Setup<SE.Member>(_ => _.GetByIdWithPerson(It.IsAny<int>()))
				.Returns(memberEntity);

			var mockUnitOfWork = new Mock<IUnitOfWork>(MockBehavior.Strict);
			mockUnitOfWork
				.SetupGet(_ => _.MemberRepository)
				.Returns(mockMemberRepository.Object);

			// Act
			MemberDetails memberDetails = new MemberDetails(mockUnitOfWork.Object);
			memberDetails.ChurchId = generator.Generate<string>();
			memberDetails.FirstName = generator.Generate<string>();
			memberDetails.LastName = generator.Generate<string>();
			var actualProcessResult = memberDetails.Update();

			// Assert
			mockMemberRepository.VerifyAll();
			mockUnitOfWork.VerifyAll();

			Assert.IsNotNull(actualProcessResult.ValidationResults
				.Single(_ => _.MemberName == MemberDetails.MemberLabels.MemberId
					&& _.Message == MemberDetails.ValidationMessages.MemberIdPersonNull));
		}
	}
}