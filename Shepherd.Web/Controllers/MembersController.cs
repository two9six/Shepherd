using Shepherd.Domain.Entities.Members;
using Shepherd.Domain.Entities.Members.Contracts;
using Shepherd.Web.ViewModels;
using System.Web.Mvc;

namespace Shepherd.Web.Controllers
{
	public class MembersController : Controller
	{
		private readonly IMemberDetails memberDetails;
		private readonly IMemberList memberList;

		public MembersController(IMemberDetails memberDetails, IMemberList memberList)
		{
			this.memberDetails = memberDetails;
			this.memberList = memberList;
		}

		public ViewResult Index()
		{
			this.memberList.Fetch();

			return View(this.memberList);
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
	}
}