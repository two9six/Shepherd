using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Shepherd.BusinessLogic.Constants;
using Shepherd.BusinessLogic.Entities.Members;
using Shepherd.Data.Infrastructure.Contracts;
using Shepherd.Data.Repository.Contracts;
using Shepherd.Model.Models;
using Spackle;
using System;

namespace Shepherd.BusinessLogic.Tests.Entities
{
	[TestClass]
	public class MemberDetailsTests
	{
		private readonly RandomObjectGenerator generator;

		public MemberDetailsTests()
		{
			generator = new RandomObjectGenerator();
		}

		[TestMethod]
		public void PassesWhen_FetchCorrectData()
		{
			// Arrange
			var mockMemberRepository = new Mock<IMemberRepository>(MockBehavior.Strict);
			var mockUnitOfWork = new Mock<IUnitOfWork>(MockBehavior.Strict);

			var expectedMemberId = 1;
			var expectedGeneratedId = generator.Generate<string>();
			var expectedDateBabtized = generator.Generate<DateTime>();
			var expectedLastName = generator.Generate<string>();
			var expectedFirstName = generator.Generate<string>();
			var expectedMiddleName = generator.Generate<string>();
			var expectedBirthDate = generator.Generate<DateTime>();

			var member = new Member()
			{
				Id = expectedMemberId,
				GeneratedId = expectedGeneratedId,
				DateBabtized = expectedDateBabtized,
				Person = new Person()
				{
					LastName = expectedLastName,
					FirstName = expectedFirstName,
					MiddleName = expectedMiddleName,
					BirthDate = expectedBirthDate
				}
			};

			mockMemberRepository
				.Setup<Member>(_ => _.GetByIdWithPerson(It.IsAny<int>()))
				.Returns(member);

			// Act
			var memberDetails = new MemberDetails(mockMemberRepository.Object, mockUnitOfWork.Object);
			memberDetails.Fetch(expectedMemberId);

			// Assert
			mockMemberRepository.VerifyAll();
			mockUnitOfWork.VerifyAll();

			Assert.AreEqual(expectedMemberId, memberDetails.MemberId);
			Assert.AreEqual(expectedGeneratedId, memberDetails.GeneratedId);
			Assert.AreEqual(expectedDateBabtized, memberDetails.DateBabtized);
			Assert.AreEqual(expectedLastName, memberDetails.LastName);
			Assert.AreEqual(expectedFirstName, memberDetails.FirstName);
			Assert.AreEqual(expectedMiddleName, memberDetails.MiddleName);
			Assert.AreEqual(expectedBirthDate, memberDetails.BirthDate);
		}

		[TestMethod]
		public void FailsWhen_FetchInvalidMemberId()
		{
			// Arrange
			var mockMemberRepository = new Mock<IMemberRepository>(MockBehavior.Strict);
			var mockUnitOfWork = new Mock<IUnitOfWork>(MockBehavior.Strict);
			var expectedException = default(ArgumentException);

			var expectedMemberId = -1;
			MemberDetails memberDetails;

			// Act
			try
			{
				memberDetails = new MemberDetails(mockMemberRepository.Object, mockUnitOfWork.Object);
				memberDetails.Fetch(expectedMemberId);
			}
			catch(ArgumentException ex)
			{
				expectedException = ex;
			}

			// Assert
			mockMemberRepository.VerifyAll();
			mockUnitOfWork.VerifyAll();
			Assert.IsNotNull(expectedException);
			Assert.AreEqual(expectedException.Message, ValidationMessages.ArgumentExceptionInvalidMemberId);
		}

	}
}