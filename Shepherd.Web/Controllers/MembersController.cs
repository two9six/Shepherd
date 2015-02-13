using AutoMapper;
using Shepherd.BusinessLogic.Entities;
using Shepherd.BusinessLogic.Entities.Contracts;
using Shepherd.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Shepherd.Web.Controllers
{
	public class MembersController : Controller
	{
		private readonly IMemberDetails memberDetails;

		public MembersController(IMemberDetails memberDetails)
		{
			this.memberDetails = memberDetails;
		}

		public ViewResult Index()
		{
			return View();
		}

		public ViewResult Details(int id)
		{
			this.memberDetails.Fetch(id);

			var viewModel = Mapper.Map<MemberDetailsViewModel>(memberDetails);

			return View(viewModel);
		}

		[HttpPost]
		public ActionResult Update(MemberDetailsViewModel viewModel)
		{
			var memberDetails = Mapper.Map<MemberDetails>(viewModel);

			if (ModelState.IsValid)
			{
				//this.memberDetails.EditMember()
			}

			return RedirectToAction("Details", new { id = viewModel.MemberId });
		}
	}
}