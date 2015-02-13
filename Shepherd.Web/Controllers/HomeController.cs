using Shepherd.BusinessLogic.Entities;
using Shepherd.BusinessLogic.Entities.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Shepherd.Web.Controllers
{
    public class HomeController : Controller
    {
		private readonly IMemberDetails memberDetails;

		public HomeController(IMemberDetails memberDetails)
		{
			this.memberDetails = memberDetails;
		}

        public ActionResult Index()
        {
			this.memberDetails.Fetch(1);
			ViewBag.MemberName = this.memberDetails.FirstName + " " + this.memberDetails.LastName;
            return View();
        }
    }
}