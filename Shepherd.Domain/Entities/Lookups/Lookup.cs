using Shepherd.Domain.Constants;
using Shepherd.Domain.Entities.Lookups.Contracts;
using Shepherd.Data.Contracts;
using System;
using SMM = Shepherd.Model.Models;

namespace Shepherd.Domain.Entities.Lookups
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
				throw new ArgumentException(ValidationMessages.ArgumentException.InvalidId, Lookup.FieldLabels.LookupId);
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

		public void Create(SMM.Lookup lookup)
		{
			unitOfWork.LookupRepository.Add(lookup);
			unitOfWork.Save();
		}

		public void Update()
		{
			var lookup = unitOfWork.LookupRepository.GetById(this.LookupId);

			if (lookup == null)
			{
				throw new NullReferenceException(ValidationMessages.NullReferenceException.UpdateFailed);
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