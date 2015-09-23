using Shepherd.Data.Contracts.Infrastructure;
using Shepherd.Data.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Shepherd.Domain.Models.Reporting
{
	public sealed class MonthlyCelebrants
	{
		public int Month { get; set; }

		public List<MonthlyCelebrator> Celebrators { get; set; }

		private readonly IUnitOfWork unitOfWork;

		public MonthlyCelebrants()
			: this(UnitOfWork.Instance)
		{
		}

		public MonthlyCelebrants(IUnitOfWork unitOfWork)
		{
			this.unitOfWork = unitOfWork;
			this.Celebrators = new List<MonthlyCelebrator>();
		}

		public void Load()
		{
			unitOfWork.MemberRepository
				.FindBy(_ => _.DateBaptized.Month == this.Month)
				.Select(_ => new {
					_.Id,
 					_.Person.FirstName,
					_.Person.LastName,
					_.DateBaptized
				})
				.OrderBy(_ => _.DateBaptized.Day)
				.ToList()
				.ForEach(_ =>
				{
					var celebrator = new MonthlyCelebrator()
					{
						Id = _.Id,
						Name = string.Format("{0} {1}", _.FirstName, _.LastName),
						DateBaptized = _.DateBaptized
					};
					this.Celebrators.Add(celebrator);
				});
		}
	}

	public sealed class MonthlyCelebrator
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public DateTime DateBaptized { get; set; }
	}
}