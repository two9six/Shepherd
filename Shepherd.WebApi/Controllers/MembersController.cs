using Shepherd.Domain.Contracts.Services;
using Shepherd.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using Shepherd.WebApi.Infrastructure.Extensions;
using Shepherd.WebApi.Models;

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
		public HttpResponseMessage Post([FromBody]AddMemberRequest request)
		{
			try
			{
				_memberService.AddMember(request.Member);

				var response = new HttpResponseMessage(HttpStatusCode.OK);
				response.Content = new StringContent(request.Member.Id.ToString());
				return response;
			}
			catch(Exception ex)
			{
				throw this.HandleGeneralError<AddMemberResponse>(ex);
			}
		}

	}
}