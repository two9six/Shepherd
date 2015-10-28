using Shepherd.Data.Contracts.Infrastructure;
using Shepherd.Data.Infrastructure;
using Shepherd.Domain.Extensions;
using System.Collections.Generic;
using System.Linq;

namespace Shepherd.Domain.Models
{
	public sealed class CommitteeIndex
	{
		public List<Committee> Committees { get; set; }

		private readonly IUnitOfWork unitOfWork;

		public CommitteeIndex()
			: this(UnitOfWork.Instance)
		{
		}

		public CommitteeIndex(IUnitOfWork unitOfWork)
		{
			this.unitOfWork = unitOfWork;
			this.Committees = new List<Committee>();
		}

		public void Load()
		{
			unitOfWork.CommitteeRepository
				.GetAll()
				.OrderByDescending(_ => _.Name)
				.ToList()
				.ForEach(_ =>
				{
					var committee = new Committee();
					committee.LoadFromEntity(_);
					this.Committees.Add(committee);
				});
		}
	}
}