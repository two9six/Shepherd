using Shepherd.Domain.Models;
using System.Web.Http;
using System.Web.Http.Cors;

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

		[HttpPost]
		public IHttpActionResult Post([FromBody]Member member)
		{
			return GetActionResult(delegate()
			{
				member.Insert();
				return member;
			});
		}
	}
}