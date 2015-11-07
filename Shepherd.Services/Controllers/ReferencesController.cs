using Shepherd.Domain.Models;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Shepherd.Services.Controllers
{
	[EnableCors(origins: "*", headers: "*", methods: "*")]
	public class ReferencesController : BaseApiController
	{
		[HttpGet]
		public IHttpActionResult GetDesignations()
		{
			return GetActionResult(delegate()
			{
				var designationList = new DesignationList();
				designationList.Load();
				return designationList;
			});
		}
	}
}