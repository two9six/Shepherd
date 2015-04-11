using Shepherd.Domain.Contracts.Models.Members;
using Shepherd.Domain.Contracts.Services.Lookup;
using Shepherd.Domain.Enums;
using Shepherd.Web.Models.Members;
using Shepherd.Web.ViewModels;
using System.Collections.Generic;
using System.Web.Mvc;
using Shepherd.Web.Extensions;

namespace Shepherd.Web.Controllers
{
	public class MembersController : CoreController
	{
		private readonly IMemberDetails memberDetails;
		private readonly IMemberList memberList;
		private readonly ILookupSelectListService lookupSelectListService;

		public MembersController(IMemberDetails memberDetails, IMemberList memberList, ILookupSelectListService lookupSelectListService)
		{
			this.memberDetails = memberDetails;
			this.memberList = memberList;
			this.lookupSelectListService = lookupSelectListService;
		}

		public ViewResult Index()
		{
			var viewModel = new MemberListModel(memberList);
			viewModel.Generate();
			ViewBag.MemberType = lookupSelectListService.GetSelectList(LookupTypes.MemberType).ToSelectList();

			return View(viewModel);
		}

		[HttpPost]
		public ActionResult Index(MemberListModel model)
		{
			var viewModel = new MemberListModel(memberList);
			viewModel.Generate();

			return View(viewModel);
		}

		public ViewResult Details(int id)
		{
			this.memberDetails.Fetch(id);
			var viewModel = new MemberDetailsViewModel();
			viewModel.MapFromBusinessEntity(this.memberDetails);

			return View(viewModel);
		}

		[HttpPost]
		public ActionResult Update(MemberDetailsViewModel viewModel)
		{
			if (ModelState.IsValid)
			{
				viewModel.MapToBusinessEntity(this.memberDetails);
				this.memberDetails.Update();
			}

			return RedirectToAction("Details", new { id = viewModel.MemberId });
		}

		[HttpGet]
		public ViewResult Add()
		{
			return View(new MemberDetailsViewModel());
		}

		public static class Actions
		{
			public const string Index = "Index";
			public const string Details = "Details";
		}
	}
}