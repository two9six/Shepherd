using Shepherd.Core.Enums;
using Shepherd.Data.Contracts.Infrastructure;
using Shepherd.Data.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Shepherd.Domain.Models.Reporting
{
	public sealed class OfficersList
	{
		public List<OfficersListItem> Officers { get; set; }

		private readonly IUnitOfWork unitOfWork;

		public OfficersList()
			: this(UnitOfWork.Instance)
		{
		}

		public OfficersList(IUnitOfWork unitOfWork)
		{
			this.unitOfWork = unitOfWork;
			this.Officers = new List<OfficersListItem>();
		}

		public void Load()
		{
			unitOfWork.MemberRepository
				.FindBy(_ => _.Designation.DesignationType.Id == (byte)DesignationTypes.Officer
					&& _.MemberStatusId == (byte)MemberStatuses.Active
					&& !_.IsDeleted)
				.Select(_ => new
				{
					_.Id,
					_.Person.FirstName,
					_.Person.LastName,
					_.DesignationId,
					_.Designation.SortOrder,
					_.DateBaptized,
					_.Person.Gender,
					_.LandLine,
					_.MobileNumber,
					_.Person.AddressLine1,
					_.Person.AddressLine2,
					_.Person.City
				})
				.OrderBy(_ => _.SortOrder)
				.ThenBy(_ => _.FirstName)
				.ToList()
				.ForEach(_ =>
				{
					var officer = new OfficersListItem()
					{
						Id = _.Id,
						Name = string.Format("{0} {1}", _.FirstName, _.LastName),
						Designation = (Designations)_.DesignationId,
						DateBaptized = _.DateBaptized,
						Gender = _.Gender,
						Landline = _.LandLine,
						MobileNumber = _.MobileNumber,
						Address = string.Format("{0} {1} {2}", _.AddressLine1, _.AddressLine2, _.City)
					};
					this.Officers.Add(officer);
				});
		}
	}

	public sealed class OfficersListItem
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public Designations Designation { get; set; }
		public DateTime DateBaptized { get; set; }
		public string Gender { get; set; }
		public string Landline { get; set; }
		public string MobileNumber { get; set; }
		public string Address { get; set; }
	}
}