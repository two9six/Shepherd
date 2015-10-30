using Shepherd.Core.Exceptions;
using Shepherd.Data.Contracts.Infrastructure;
using Shepherd.Data.Infrastructure;
using Shepherd.Domain.Contracts.Models;
using Shepherd.Domain.Extensions;
using System.Collections.Generic;

namespace Shepherd.Domain.Models
{
	public sealed class Committee
		: ICommittee
	{
		public int Id { get; set; }

		public string Name { get; set; }

		public string Description { get; set; }

		public bool IsActive { get; set; }

		public bool IsDeleted { get; set; }

		public List<ICommitteeMember> Members {get;set;}

		private readonly IUnitOfWork unitOfWork;

		public Committee()
			: this(UnitOfWork.Instance)
		{
		}

		public Committee(IUnitOfWork unitOfWork)
		{
			this.unitOfWork = unitOfWork;

			this.Members = new List<ICommitteeMember>();
		}

		public void Load()
		{
			var committeeEntity = unitOfWork.CommitteeRepository.GetById(this.Id);
			if (committeeEntity == null)
				throw new ModelNotFoundException("Committee not found.");

			this.LoadFromEntity(committeeEntity);
		}

		public void Insert()
		{
			throw new System.NotImplementedException();
		}

		public void Update()
		{
			throw new System.NotImplementedException();
		}
	}
}