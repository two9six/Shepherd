﻿using Shepherd.Domain.Contracts.Services;
using Shepherd.Domain.Services.MemberService.Models;
using Shepherd.WebApi.DTOs.Members;
using Shepherd.WebApi.Infrastructure.Extensions;
using Shepherd.WebApi.Models.Members;
using System;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Shepherd.WebApi.Controllers
{
	[EnableCors(origins: "*", headers: "*", methods: "*")]
	public class MembersController : ApiController
	{
		private readonly IMemberService _memberService;

		public MembersController(IMemberService memberService)
		{
			_memberService = memberService;
		}

		public GetMembersResponse Get(string name = "", string churchId = "")
		{
			try
			{
				var response = _memberService.GetMembers(name, churchId);

				return new GetMembersResponse()
				{
					Members = response.Members.Select(_=> Member.Parse(_)).ToList()
				};
			}
			catch (Exception ex)
			{
				throw this.HandleGeneralError<GetMembersResponse>(ex);
			}
		}

		[HttpPost]
		public AddMemberResponse Post([FromBody]AddMemberRequest request)
		{
			try
			{
				this.ValidateInput<AddMemberResponse>(request);

				var member = request.Member.ToDomainObject();

				var serviceResponse = _memberService.AddMember(member);

				return new AddMemberResponse
				{
					MemberId = serviceResponse.Member.Id,
					Message = string.Format(MembersController.Messages.PostMemberSuccess, member.FirstName, member.LastName)
				};
			}
			catch(Exception ex)
			{
				throw this.HandleGeneralError<AddMemberResponse>(ex);
			}
		}

		public static class Messages
		{
			public const string PostMemberSuccess = "{0} {1} has been added.";
		}

	}
}