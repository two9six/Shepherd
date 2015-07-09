using Shepherd.Domain.Contracts.Services;
using Shepherd.WebApi.Infrastructure.Extensions;
using Shepherd.WebApi.Models.Members;
using System;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Shepherd.WebApi.Controllers
{
	[EnableCors(origins: "*", headers: "*", methods: "*")]
	public class MembersController : ApiController
	{

		private readonly IMemberService _memberService;

		public MembersController(IMemberService memberService)
		{
			_memberService = memberService;
		}

		public string Get()
		{
			return "a";
		}

		[HttpPost]
		public AddMemberResponse Post([FromBody]AddMemberRequest request)
		{
			try
			{
				var member = new Domain.Models.Member()
				{
					ChurchId = request.Member.ChurchId,
					FirstName = request.Member.FirstName,
					LastName = request.Member.LastName,
					MiddleName = request.Member.MiddleName,
					BirthDate = request.Member.BirthDate,
					PlaceOfBirth = request.Member.PlaceOfBirth,
					Gender = request.Member.Gender,
					Citizenship = request.Member.Citizenship,
					Address = request.Member.Address.ToDomainObject(),
					DateBaptized = request.Member.DateBaptized,
					Baptizer = request.Member.Baptizer.ToDomainObject(),
					MaritalStatus = request.Member.MaritalStatus,
					SpouseName = request.Member.SpouseName,
					ContactInformation = request.Member.ContactInformation.ToDomainObject()
				};

				// TODO: Convert Status, Types and Designation

				_memberService.AddMember(member);

				return new AddMemberResponse
				{
					MemberId = member.Id,
					Message = string.Format("{0} {1} has been added.", member.FirstName, member.LastName)
				};
			}
			catch(Exception ex)
			{
				throw this.HandleGeneralError<AddMemberResponse>(ex);
			}
		}

	}
}