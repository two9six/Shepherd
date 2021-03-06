﻿using Shepherd.Data.Contracts.Infrastructure;
using Shepherd.Data.Infrastructure;
using Shepherd.Domain.Contracts.Models.Reporting;
using Shepherd.Domain.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Shepherd.Domain.Models.Reporting
{
	public sealed class MonthlyCelebrants : IMonthlyCelebrants
	{
		public int Month { get; set; }

		public List<IMonthlyCelebrator> Celebrators { get; set; }

		private readonly IUnitOfWork unitOfWork;

		public MonthlyCelebrants()
			: this(UnitOfWork.Instance)
		{
		}

		public MonthlyCelebrants(IUnitOfWork unitOfWork)
		{
			this.unitOfWork = unitOfWork;
			this.Celebrators = new List<IMonthlyCelebrator>();
		}

		public void Load()
		{
			unitOfWork.MemberRepository
				.FindBy(_ => _.DateBaptized.Month == this.Month 
					&& _.DateBaptized.Year < DateTime.Now.Year
					&& !_.IsDeleted)
				.Select(_ => new {
					_.Id,
 					_.Person.FirstName,
					_.Person.LastName,
					_.DateBaptized,
					_.Person.Gender,
					_.LandLine,
					_.MobileNumber,
					_.Person.AddressLine1,
					_.Person.AddressLine2,
					_.Person.City
				})
				.OrderBy(_ => _.DateBaptized.Day)
				.ThenBy(_ => _.FirstName)
				.ToList()
				.ForEach(_ =>
				{
					var celebrator = new MonthlyCelebrator()
					{
						Id = _.Id,
						Name = string.Format("{0} {1}", _.FirstName, _.LastName),
						DateBaptized = _.DateBaptized,
						Age = DateTimeHelpers.ComputeAgeCelebrant(_.DateBaptized),
						Gender = _.Gender,
						Landline = _.LandLine,
						MobileNumber = _.MobileNumber,
						Address = string.Format("{0} {1} {2}", _.AddressLine1, _.AddressLine2, _.City)
					};
					this.Celebrators.Add(celebrator);
				});
		}
	}

	public sealed class MonthlyCelebrator : IMonthlyCelebrator
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public DateTime DateBaptized { get; set; }
		public int Age { get; set; }
		public string Gender { get; set; }
		public string Landline { get; set; }
		public string MobileNumber { get; set; }
		public string Address { get; set; }
	}
}