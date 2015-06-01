using Shepherd.Data.Contracts.Infrastructure;
using Shepherd.Domain.Constants;
using Shepherd.Domain.Contracts.Models.Lookups;
using System;
using SE = Shepherd.Entities;

namespace Shepherd.Domain.Models.Lookups
{
	public sealed class Lookup : ILookup
	{
		private readonly IUnitOfWork unitOfWork;

		public int LookupId { get; set; }

		public int LookupTypeId { get; set; }

		public string Name { get; set; }

		public bool IsDefault { get; set; }

		public bool IsDeleted { get; set; }

		public Lookup(IUnitOfWork unitOfWork)
		{
			this.unitOfWork = unitOfWork;
		}

		public void Fetch(int lookupId)
		{
			if (lookupId <= 0)
			{
				throw new ArgumentException(GenericValidationMessages.ArgumentException.InvalidId, Lookup.FieldLabels.LookupId);
			}

			var lookup = unitOfWork.LookupRepository.GetById(lookupId);

			if (lookup != null)
			{
				this.LookupId = lookup.Id;
				this.Name = lookup.Name;
				this.IsDefault = lookup.IsDefault;
				this.IsDeleted = lookup.IsDeleted;
			}
		}

		public void Create()
		{

		}

		public void Add()
		{
			var lookUp = new SE.Lookup
			{
				 LookupTypeId = this.LookupTypeId,
				 Name = this.Name,
				 IsDefault = this.IsDefault,
				 IsDeleted = this.IsDeleted
			};

			unitOfWork.LookupRepository.Add(lookUp);
			unitOfWork.Save();

			this.LookupId = lookUp.Id;
		}

		public void Update()
		{
			var lookup = unitOfWork.LookupRepository.GetById(this.LookupId);

			if (lookup == null)
			{
				throw new NullReferenceException(GenericValidationMessages.NullReferenceException.UpdateFailed);
			}
			else
			{
				lookup.LookupTypeId = this.LookupTypeId;
				lookup.Name = this.Name;
				lookup.IsDefault = this.IsDefault;
				lookup.IsDeleted = this.IsDeleted;

				unitOfWork.LookupRepository.Edit(lookup);
				unitOfWork.Save();
			}
		}

		public void Delete(int lookupId)
		{
			var lookup = unitOfWork.LookupRepository.GetById(lookupId);
			if (lookup != null)
			{
				lookup.IsDeleted = true;
				unitOfWork.LookupRepository.Edit(lookup);
				unitOfWork.Save();
			}
		}

		public static class FieldLabels
		{
			public const string LookupId = "Lookup Id";
		}
	}
}