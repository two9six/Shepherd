using Shepherd.Domain.Contracts.Models.Members;
using Shepherd.Domain.Contracts.Services.Lookup;
using Shepherd.Domain.Enums;
using Shepherd.Web.Attributes;
using Shepherd.Web.Extensions;
using Shepherd.Web.Models.Members;
using Shepherd.Web.ViewModels;
using System.Web.Mvc;

namespace Shepherd.Web.Controllers
{
	public class MembersController : CoreController
	{
		public ViewResult Index()
		{
			var viewModel = new MemberListModel(this.MemberList);
			viewModel.Generate();
			ViewBag.MemberType = this.LookupSelectListService.GetSelectList(LookupTypes.MemberType).ToSelectList();

			return View(viewModel);
		}

		[HttpPost]
		public ActionResult Index(MemberListModel model)
		{
			var viewModel = new MemberListModel(this.MemberList);
			viewModel.Generate();

			return View(viewModel);
		}

		public ViewResult Details(int id)
		{
			this.MemberDetails.Fetch(id);
			var viewModel = new MemberDetailsViewModel();
			viewModel.MapFromBusinessEntity(this.MemberDetails);

			return View(viewModel);
		}

		[HttpPost]
		public ActionResult Update(MemberDetailsViewModel viewModel)
		{
			if (ModelState.IsValid)
			{
				viewModel.MapToBusinessEntity(this.MemberDetails);
				this.MemberDetails.Update();
			}

			return RedirectToAction("Details", new { id = viewModel.MemberId });
		}

		[HttpGet]
		public ViewResult Add()
		{
			return View(new MemberDetailsViewModel());
		}

		[Dependency]
		public IMemberDetails MemberDetails { get; set; }

		[Dependency]
		public IMemberList MemberList { get; set; }

		[Dependency]
		public ILookupSelectListService LookupSelectListService { get; set; }

		public static class Actions
		{
			public const string Index = "Index";
			public const string Details = "Details";
		}
	}
}