using AutoMapper;
using Shepherd.BusinessLogic.Entities.Members;
using Shepherd.BusinessLogic.Entities.Members.Contracts;
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