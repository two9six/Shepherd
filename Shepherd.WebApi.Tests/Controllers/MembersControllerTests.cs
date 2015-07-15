using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Shepherd.Domain.Contracts.Services;
using Shepherd.Domain.Services.MemberService.Models;
using Shepherd.WebApi.Controllers;
using Shepherd.WebApi.DTOs.Members;
using Shepherd.WebApi.Models.Members;
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
	}
}