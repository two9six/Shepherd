using Shepherd.Domain.Models;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Net.Http.Formatting;
using System.Net;

namespace Shepherd.Services.Controllers
{
	[EnableCors(origins: "*", headers: "*", methods: "*")]
	public class MembersController : BaseApiController
	{
		[HttpGet]
		public IHttpActionResult Get(string name = "", string churchId = "")
		{
			return GetActionResult(delegate()
			{
				var membersIndex = new MembersIndex()
				{
					Name = name,
					ChurchId = churchId
				};

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
                return membersDetail;
            });
        }

		[HttpPost]
        public string Post([FromBody]AddMember member)
		{
            return "a";
            //return GetActionResult(delegate()
            //{
            //    member.Insert();
            //    return member;
            //});
		}

        [HttpPut]
        public IHttpActionResult Put([FromBody]Member member)
        {
            return GetActionResult(delegate() {
                member.Update();
                return member;
            });
        }

	}
}