using Shepherd.Data.Contracts.Infrastructure;
using Shepherd.Data.Infrastructure;
using System.Collections.Generic;
using System.Linq;

namespace Shepherd.Domain.Models
{
	public sealed class DesignationList
	{
		public List<Designation> Designations { get; set; }

		private readonly IUnitOfWork unitOfWork;

		public DesignationList()
			: this(UnitOfWork.Instance)
		{
		}

		public DesignationList(IUnitOfWork unitOfWork)
		{
			this.unitOfWork = unitOfWork;
			this.Designations = new List<Designation>();
		}

		public void Load()
		{
			unitOfWork.DesignationRepository
				.GetAll()
				.ToList()
				.ForEach(_ =>
				{
					var designation = new Designation()
					{
						Id = _.Id,
						DesignationTypeId = _.DesignationTypeId,
						Name = _.Name,
						SortOrder = _.SortOrder
					};
					this.Designations.Add(designation);
				});
		}
	}

	public sealed class Designation
	{
		public int Id { get; set; }
		public int DesignationTypeId { get; set; }
		public string Name { get; set; }
		public byte SortOrder { get; set; }
	}
}