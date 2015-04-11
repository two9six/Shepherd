using System.Web.Mvc;

namespace Shepherd.Web.Controllers
{
    public class HomeController : CoreController
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}