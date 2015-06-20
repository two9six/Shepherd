using Shepherd.Domain.Contracts.Services;
using Shepherd.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Shepherd.WebApi.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class MemberController : ApiController
    {

        private readonly IMemberService _memberService;

        public MemberController(IMemberService memberService) {
            _memberService = memberService;
        }

        public string Get()
        {
            return "a";
        }

        [HttpPost]
        public HttpResponseMessage AddMember(Member member)
        {

            _memberService.AddMember(member);

            var response = new HttpResponseMessage(HttpStatusCode.OK);
            response.Content = new StringContent(member.Id.ToString());
            return response;
        }

    }
}
