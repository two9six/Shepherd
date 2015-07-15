using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Shepherd.Domain.Contracts.Services;
using Shepherd.Domain.Services.MemberService.Models;
using Shepherd.WebApi.Controllers;
using Shepherd.WebApi.DTOs.Members;
using Shepherd.WebApi.Models.Members;
using Shepherd.WebApi.Tests.Helpers;
using Spackle;
using System;
using System.Linq;

namespace Shepherd.WebApi.Tests.Controllers
{
	[TestClass]
	public class MembersControllerTests
	{
		[TestMethod]
		public void Post_WhenUsingValidData_SavesSuccessfully()
		{
			// arrange
			var generator = new RandomObjectGenerator();
			var expectedMember = new Domain.Models.Member { Id = Math.Abs(generator.Generate<int>()) };

			var mockMemberService = new Mock<IMemberService>(MockBehavior.Strict);
			mockMemberService
				.Setup<AddMemberServiceResponse>(_ => _.AddMember(It.IsAny<Domain.Models.Member>()))
				.Returns(new AddMemberServiceResponse { Member = expectedMember });

			var addMemberRequest = new AddMemberRequest
			{
				Member = new Member()
				{
					Status = ((int)Domain.Models.Member.MemberStatus.Active).ToString(),
					Type = ((int)Domain.Models.Member.MemberType.Member).ToString(),
					Designation = ((int)Domain.Models.Member.ChurchDesignation.Member).ToString(),
				}
			};

			var membersController = new MembersController(mockMemberService.Object);

			// act
			var result = membersController.Post(addMemberRequest);

			// assert
			mockMemberService.VerifyAll();
			Assert.AreEqual(0, result.Errors.Count());
			Assert.AreEqual(expectedMember.Id, result.MemberId);
		}

		[TestMethod]
		public void Get_WhenUsingValidDomainObject_ConvertToDTOSuccessfully()
		{
			// arrange
			var generator = new RandomObjectGenerator();
			var expectedItems = 1;
			var domainMembers = DomainMemberCreator.CreateCompleteMembers(expectedItems);

			var mockMemberService = new Mock<IMemberService>(MockBehavior.Strict);
			mockMemberService
				.Setup<GetMembersServiceResponse>(_ => _.GetMembers(It.IsAny<string>(), It.IsAny<string>()))
				.Returns(new GetMembersServiceResponse { Members = domainMembers });

			var membersController = new MembersController(mockMemberService.Object);

			// act
			var result = membersController.Get(string.Empty, string.Empty);

			// assert
			mockMemberService.VerifyAll();
			Assert.AreEqual(0, result.Errors.Count());
			Assert.AreEqual(domainMembers.Count(), result.Members.Count());
			Assert.AreEqual(domainMembers.ElementAt(0).Id, result.Members.ElementAt(0).Id);
			Assert.AreEqual(domainMembers.ElementAt(0).ChurchId, result.Members.ElementAt(0).ChurchId);
			Assert.AreEqual(domainMembers.ElementAt(0).FirstName, result.Members.ElementAt(0).FirstName);
			Assert.AreEqual(domainMembers.ElementAt(0).LastName, result.Members.ElementAt(0).LastName);
			Assert.AreEqual(domainMembers.ElementAt(0).MiddleName, result.Members.ElementAt(0).MiddleName);
			Assert.IsNotNull(result.Members.ElementAt(0).BirthDate);
			Assert.AreEqual(domainMembers.ElementAt(0).BirthDate, result.Members.ElementAt(0).BirthDate);
			Assert.AreEqual(domainMembers.ElementAt(0).PlaceOfBirth , result.Members.ElementAt(0).PlaceOfBirth);
			Assert.AreEqual(domainMembers.ElementAt(0).Gender, result.Members.ElementAt(0).Gender);
			Assert.AreEqual(domainMembers.ElementAt(0).Citizenship, result.Members.ElementAt(0).Citizenship);
			Assert.IsNotNull(result.Members.ElementAt(0).Address);
			Assert.AreEqual(domainMembers.ElementAt(0).Address.AddressLine1, result.Members.ElementAt(0).Address.AddressLine1);
			Assert.AreEqual(domainMembers.ElementAt(0).Address.AddressLine2, result.Members.ElementAt(0).Address.AddressLine2);
			Assert.AreEqual(domainMembers.ElementAt(0).Address.City, result.Members.ElementAt(0).Address.City);
			Assert.AreEqual(domainMembers.ElementAt(0).Address.StateProvince, result.Members.ElementAt(0).Address.StateProvince);
			Assert.AreEqual(domainMembers.ElementAt(0).Address.Country, result.Members.ElementAt(0).Address.Country);
			Assert.IsNotNull(result.Members.ElementAt(0).DateBaptized);
			Assert.AreEqual(domainMembers.ElementAt(0).DateBaptized, result.Members.ElementAt(0).DateBaptized);
			Assert.IsNotNull(result.Members.ElementAt(0).Baptizer);
			Assert.AreEqual(domainMembers.ElementAt(0).Baptizer.Id, result.Members.ElementAt(0).Baptizer.Id);
			Assert.AreEqual(domainMembers.ElementAt(0).MaritalStatus, result.Members.ElementAt(0).MaritalStatus);
			Assert.AreEqual(domainMembers.ElementAt(0).SpouseName, result.Members.ElementAt(0).SpouseName);
			Assert.IsNotNull(result.Members.ElementAt(0).ContactInformation);
			Assert.AreEqual(domainMembers.ElementAt(0).ContactInformation.LandLine, result.Members.ElementAt(0).ContactInformation.LandLine);
			Assert.AreEqual(domainMembers.ElementAt(0).ContactInformation.MobileNumber, result.Members.ElementAt(0).ContactInformation.MobileNumber);
			Assert.AreEqual(domainMembers.ElementAt(0).ContactInformation.Email, result.Members.ElementAt(0).ContactInformation.Email);
			Assert.AreEqual(domainMembers.ElementAt(0).Status.ToString(), result.Members.ElementAt(0).Status);
			Assert.AreEqual(domainMembers.ElementAt(0).Type.ToString(), result.Members.ElementAt(0).Type);
			Assert.AreEqual(domainMembers.ElementAt(0).Designation.ToString(), result.Members.ElementAt(0).Designation);
			Assert.AreEqual(domainMembers.ElementAt(0).CreatedBy, result.Members.ElementAt(0).CreatedBy);
			Assert.AreEqual(domainMembers.ElementAt(0).DateCreated, result.Members.ElementAt(0).DateCreated);
			Assert.AreEqual(domainMembers.ElementAt(0).ModifiedBy, result.Members.ElementAt(0).ModifiedBy);
			Assert.AreEqual(domainMembers.ElementAt(0).DateModified, result.Members.ElementAt(0).DateModified);
		}
	}
}