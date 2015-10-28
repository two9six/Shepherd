using Shepherd.Domain.Models.Reporting;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Shepherd.Services.Controllers
{
	[EnableCors(origins: "*", headers: "*", methods: "*")]
	public class ReportsController : BaseApiController
	{
		[HttpGet]
		public IHttpActionResult GetOfficersList()
		{
			return GetActionResult(delegate()
			{
				var officersList = new OfficersList();
				officersList.Load();
				return officersList.Officers;
			});
		}
	}
}