using Shepherd.Data.Contracts.Infrastructure;
using Shepherd.Data.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Shepherd.Domain.Models.Reporting
{
	public sealed class NewlyBaptizedBrethren
	{
		public int MonthThreshold { get; set; }

		public List<NewlyBaptizedMember> Members { get; set; }

		private readonly IUnitOfWork unitOfWork;

		public NewlyBaptizedBrethren()
			: this(UnitOfWork.Instance)
		{
		}

		public NewlyBaptizedBrethren(IUnitOfWork unitOfWork)
		{
			this.unitOfWork = unitOfWork;
			this.Members = new List<NewlyBaptizedMember>();
		}

		public void Load()
		{
			var threshold = DateTime.Now.AddMonths(this.MonthThreshold * -1);
			var dateThreshold = new DateTime(threshold.Year, threshold.Month, 1, 0, 0, 0);
			unitOfWork.MemberRepository
				.FindBy(_ => _.DateBaptized >= dateThreshold && !_.IsDeleted)
				.Select(_ => new
				{
					_.Id,
					_.Person.FirstName,
					_.Person.LastName,
					_.DateBaptized,
					_.Person.Gender
				})
				.OrderByDescending(_ => _.DateBaptized)
				.ThenBy(_ => _.FirstName)
				.ToList()
				.ForEach(_ =>
				{
					var member = new NewlyBaptizedMember()
					{
						Id = _.Id,
						Name = string.Format("{0} {1}", _.FirstName, _.LastName),
						DateBaptized = _.DateBaptized,
						Gender = _.Gender
					};
					this.Members.Add(member);
				});
		}
	}

	public sealed class NewlyBaptizedMember
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public DateTime DateBaptized { get; set; }
		public string Gender { get; set; }
	}
}