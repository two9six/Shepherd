using Shepherd.BusinessLogic.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Shepherd.Web.Controllers
{
	public class HomeController : Controller
	{
		public ActionResult Index()
		{
			var member = new Member();
			member.Fetch(1);
			ViewBag.MemberName = member.FirstName + " " + member.LastName;
			return View();
		}

		public ActionResult About()
		{
			ViewBag.Message = "Your application description page.";

			return View();
		}

		public ActionResult Contact()
		{
			ViewBag.Message = "Your contact page.";

			return View();
		}
	}
}