using Shepherd.Web.Models;
using System.Web.Mvc;

namespace Shepherd.Web.Controllers
{
    public class AppShellController : Controller
    {
		public ActionResult Index()
		{
			return View(new AppShellViewModel());
		}
    }
}