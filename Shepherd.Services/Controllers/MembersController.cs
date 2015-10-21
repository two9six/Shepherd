using Shepherd.Domain.Models;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Net.Http.Formatting;
using System.Net;
using Shepherd.Domain.Models.Reporting;
using System;

namespace Shepherd.Services.Controllers
{
	[EnableCors(origins: "*", headers: "*", methods: "*")]
	public class MembersController : BaseApiController
	{
		[HttpGet]
		public IHttpActionResult Get()
		{
			return GetActionResult(delegate()
			{
				var membersIndex = new MembersIndex();
				membersIndex.Load();

				return membersIndex;
			});
		}

        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            return GetActionResult(delegate() { 
                
                var membersDetail = new MembersDetail()
                {
                    Id = id
                };
                membersDetail.Load();
                return membersDetail.Member;
            });
        }

		[HttpPost]
        public IHttpActionResult Post([FromBody]Member member)
		{
            return GetActionResult(delegate()
            {
                member.Insert();
                return member;
            });
		}

        [HttpPut]
        public IHttpActionResult Put([FromBody]Member member)
        {
            return GetActionResult(delegate() {
                member.Update();
                return member;
            });
        }

		[HttpGet]
		public IHttpActionResult GetMonthlyCelebrants(int month)
		{
			return GetActionResult(delegate()
			{
				var monthlyCelebrants = new MonthlyCelebrants()
				{
					Month = month
				};
				monthlyCelebrants.Load();
				return monthlyCelebrants.Celebrators;
			});
		}

		[HttpGet]
		public IHttpActionResult GetNewlyBaptized(int monthThreshold)
		{
			return GetActionResult(delegate()
			{
				var newlyBaptizedBrethren = new NewlyBaptizedBrethren()
				{
					MonthThreshold = monthThreshold
				};
				newlyBaptizedBrethren.Load();
				return newlyBaptizedBrethren.Members;
			});
		}

	}
}