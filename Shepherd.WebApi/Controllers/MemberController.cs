using Shepherd.Domain.Contracts.Models.Members;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Shepherd.WebApi.Controllers
{
    public class MemberController : ApiController
    {

        public IMemberList MemberList { get; set; }



        public string Get()
        {
            this.MemberList.Fetch();

            return "a";
        }

    }
}
