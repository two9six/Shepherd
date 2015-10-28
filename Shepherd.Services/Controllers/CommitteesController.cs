using Shepherd.Domain.Models;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Shepherd.Services.Controllers
{
	[EnableCors(origins: "*", headers: "*", methods: "*")]
	public class CommitteesController : BaseApiController
	{
		[HttpGet]
		public IHttpActionResult Get()
		{
			return GetActionResult(delegate()
			{
				var committeeIndex = new CommitteeIndex();
				committeeIndex.Load();

				return committeeIndex;
			});
		}

		//[HttpGet]
		//public IHttpActionResult Get(int id)
		//{
		//	return GetActionResult(delegate() { 
                
		//		var membersDetail = new MembersDetail()
		//		{
		//			Id = id
		//		};
		//		membersDetail.Load();
		//		return membersDetail.Member;
		//	});
		//}

		//[HttpPost]
		//public IHttpActionResult Post([FromBody]Member member)
		//{
		//	return GetActionResult(delegate()
		//	{
		//		member.Insert();
		//		return member;
		//	});
		//}

		//[HttpPut]
		//public IHttpActionResult Put([FromBody]Member member)
		//{
		//	return GetActionResult(delegate() {
		//		member.Update();
		//		return member;
		//	});
		//}

	}
}