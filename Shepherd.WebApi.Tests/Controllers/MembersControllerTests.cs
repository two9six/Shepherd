using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Shepherd.Domain.Contracts.Services;
using Shepherd.Domain.Models;
using Shepherd.Domain.Services.Models.ServiceResponses;
using Shepherd.WebApi.Controllers;
using Shepherd.WebApi.DTOs.Members;
using System.Linq;

namespace Shepherd.WebApi.Tests.Controllers
{
	[TestClass]
	public class MembersControllerTests
	{
		[Ignore]
		[TestMethod]
		public void Post_WhenUsingValidData_SavesSuccessfully()
		{
			// arrange
			var mockMemberService = new Mock<IMemberService>(MockBehavior.Strict);
			mockMemberService
				.Setup<ServiceResponse>(_ => _.AddMember(It.IsAny<Member>()))
				.Returns(new ServiceResponse());

			var addMemberRequest = new AddMemberRequest
			{
				Member = new Models.Members.Member
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

		}
	}
}