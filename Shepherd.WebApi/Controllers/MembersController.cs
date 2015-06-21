using Shepherd.Domain.Contracts.Services;
using Shepherd.WebApi.Infrastructure.Extensions;
using Shepherd.WebApi.Models;
using System;
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

		public string Get()
		{
			return "a";
		}

		[HttpPost]
		public AddMemberResponse Post([FromBody]AddMemberRequest request)
		{
			try
			{
				// TODO: We should deserializing the request back to domain object
				var member = request.Member;

				_memberService.AddMember(member);

				return new AddMemberResponse
				{
					MemberId = member.Id,
					Message = string.Format("{0} {1} has been added.", member.FirstName, member.LastName)
				};
			}
			catch(Exception ex)
			{
				throw this.HandleGeneralError<AddMemberResponse>(ex);
			}
		}

	}
}