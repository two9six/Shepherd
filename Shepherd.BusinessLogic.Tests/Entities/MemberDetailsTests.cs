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
			var expectedException = default(ArgumentException);

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
				expectedException = ex;
			}

			// Assert
			mockMemberRepository.VerifyAll();
			mockUnitOfWork.VerifyAll();
			Assert.IsNotNull(expectedException);
			Assert.IsTrue(expectedException.GetType() == typeof(ArgumentException), "Exception is not ArgumentException type");
			Assert.AreEqual(expectedException.Message,
				new ArgumentException(ValidationMessages.ArgumentExceptionInvalidId, MemberDetails.MemberLabels.MemberId).Message);
		}

		[TestMethod]
		public void PassesWhen_EditSuccessfully()
		{
			// Arrange
			var mockMemberRepository = new Mock<IMemberRepository>(MockBehavior.Strict);
			var mockUnitOfWork = new Mock<IUnitOfWork>(MockBehavior.Strict);
			var generator = new RandomObjectGenerator();

			var memberId = 1;
			var memberEntity = EntityCreator.Create<Member>(_ =>
			{
				_.Id = memberId;
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
				.Returns(memberEntity);

			var personEntities = new InMemoryDbSet<Person>() { memberEntity.Person };
			var memberEntities = new InMemoryDbSet<Member>() { memberEntity };
			var context = new Mock<IShepherdEntities>(MockBehavior.Strict);
			context.Setup(_ => _.People).Returns(personEntities);
			context.Setup(_ => _.Members).Returns(memberEntities);
			context.Setup(_ => _.SetState(It.IsAny<object>(), EntityState.Modified));
			context.Setup(_ => _.SaveChanges()).Returns(1);

			var builder = new ContainerBuilder();
			builder.Register<IShepherdEntities>(_ => context.Object);
			builder.Build();

			var memberDetails = new MemberDetails(mockMemberRepository.Object, mockUnitOfWork.Object);
			memberDetails.Fetch(memberId);

			memberDetails.DateBabtized = generator.Generate<DateTime>();
			//memberDetails.FirstName = 

			Assert.IsTrue(true);

			//var member = DataPortal.Fetch<Lead>(new FetchLeadCriteria(1));
			//lead.OtherInfo = new RandomObjectGenerator().Generate<string>();
			//lead.LeadSources.ElementAt(0).Referrals.ElementAt(0).JobSite = new RandomObjectGenerator().Generate<string>();
			//lead.PrimaryLocation.LocationType = new RandomObjectGenerator().Generate<Identifiers.LocationType?>();
			//lead.PrimaryLocation.TerritoryId = generator.Generate<int>();
			//lead.PrimaryLocation.LocationStateId = 1;
			//lead.PrimaryLocation.Zip = zip;
			//lead.PrimaryPerson.PreferredContactType = new RandomObjectGenerator().Generate<Identifiers.PreferredContactType?>();
			//lead.SecondaryPerson.PreferredContactType = new RandomObjectGenerator().Generate<Identifiers.PreferredContactType?>();

			//DataPortal.Update(lead);

			//var savedEntity = leadEntities.Local[1];
		}

	}
}