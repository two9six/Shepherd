using Shepherd.Core.Enums;
using Shepherd.Data.Contracts.Infrastructure;
using Shepherd.Data.Infrastructure;
using Shepherd.Domain.Contracts.Models;
using System.Collections.Generic;
using System.Linq;

namespace Shepherd.Domain.Models
{
	public sealed class MembersIndex
		: IMembersIndex
	{
		public string ChurchId { get; set; }

		public string Name { get; set; }

		public List<Member> Members { get; set; }

		private readonly IUnitOfWork unitOfWork;

		public MembersIndex()
			: this(UnitOfWork.Instance)
		{
		}

		public MembersIndex(IUnitOfWork unitOfWork)
		{
			this.unitOfWork = unitOfWork;
		}

		public void Load()
		{
			this.Members = unitOfWork.MemberRepository
							.FindBy(_ =>
								(_.Person.FirstName.Contains(this.Name) || _.Person.LastName.Contains(this.Name))
								&& _.ChurchId.Contains(this.ChurchId))
							.OrderByDescending(_ => _.DateCreated)
							.Select(_ => new Member()
							{
								Id = _.Id,
								ChurchId = _.ChurchId,
								FirstName = _.Person.FirstName,
								LastName = _.Person.LastName,
								MiddleName = _.Person.MiddleName,
								BirthDate = _.Person.BirthDate,
								PlaceOfBirth = _.Person.PlaceOfBirth,
								Gender = _.Person.Gender,
								Citizenship = _.Person.Citizenship,
								Address = new Address()
								{
									AddressLine1 = _.Person.AddressLine1,
									AddressLine2 = _.Person.AddressLine2,
									City = _.Person.City,
									StateProvince = _.Person.StateProvince,
									Country = _.Person.Country
								},
								Baptizer = new Baptizer()
								{
									Id = _.BaptizedById
								},
								MaritalStatus = _.MaritalStatus,
								SpouseName = _.SpouseName,
								ContactInformation = new ContactInformation()
								{
									LandLine = _.LandLine,
									MobileNumber = _.MobileNumber,
									Email = _.Email
								},
								Status = (MemberStatus)_.StatusId,
								Type = (MemberType)_.TypeId,
								Designation = (ChurchDesignation)_.DesignationId,
								CreatedBy = _.CreatedBy,
								DateCreated = _.DateCreated,
								ModifiedBy = _.ModifiedBy,
								DateModified = _.DateModified
							}).ToList();
		}
	}
}