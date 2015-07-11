using Shepherd.Domain.Contracts.Services;
using Shepherd.Domain.Services.Models.Criteria;
using Shepherd.WebApi.DTOs.Members;
using Shepherd.WebApi.Infrastructure.Extensions;
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

		public GetMembersResponse Get()
		{
			try
			{
				var getMembersCriteria = new GetMembersCriteria
				{
					FirstName = ""
				};

				var response = _memberService.GetMembers(getMembersCriteria);

				return new GetMembersResponse();
			}
			catch (Exception ex)
			{
				throw this.HandleGeneralError<GetMembersResponse>(ex);
			}
		}

		[HttpPost]
		public AddMemberResponse Post([FromBody]AddMemberRequest request)
		{
			try
			{
				this.ValidateInput<AddMemberResponse>(request);

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
					ContactInformation = request.Member.ContactInformation.ToDomainObject(),
					Status = (Domain.Models.Member.MemberStatus)Enum.Parse(typeof(Domain.Models.Member.MemberStatus), request.Member.Status),
					Type = (Domain.Models.Member.MemberType)Enum.Parse(typeof(Domain.Models.Member.MemberType), request.Member.Type),
					Designation = (Domain.Models.Member.ChurchDesignation)Enum.Parse(typeof(Domain.Models.Member.ChurchDesignation), request.Member.Designation)
				};

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