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

		[HttpGet]
		public IHttpActionResult GetNonMembers(int id)
		{
			return GetActionResult(delegate()
			{
				var committee = new Committee()
				{
					Id = id
				};
				return committee.GetNonMembers();
			});
		}

		[HttpPost]
		public IHttpActionResult AddCommitteeMember([FromBody]CommitteeMember committeeMember)
		{
			return GetActionResult(delegate()
			{
				committeeMember.Insert();
				return committeeMember;
			});
		}

		[HttpPost]
		public IHttpActionResult DeleteCommitteeMember([FromBody]CommitteeMember committeeMember)
		{
			return GetActionResult(delegate()
			{
				committeeMember.Delete();
				return committeeMember;
			});
		}
	}
}