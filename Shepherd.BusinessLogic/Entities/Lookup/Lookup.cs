using Shepherd.BusinessLogic.Constants;
using Shepherd.BusinessLogic.Entities.Lookup.Contracts;
using Shepherd.Data.Infrastructure.Contracts;
using Shepherd.Data.Repository.Contracts;
using System;
using SMM = Shepherd.Model.Models;

namespace Shepherd.BusinessLogic.Entities.Lookup
{
	public sealed class Lookup : ILookup
	{
		private readonly ILookupRepository lookupRepository;
		private readonly IUnitOfWork unitOfWork;

		public int LookupId { get; set; }

		public int LookupTypeId { get; set; }

		public string Name { get; set; }

		public bool IsDefault { get; set; }

		public bool IsDeleted { get; set; }

		public Lookup(ILookupRepository lookupRepository, IUnitOfWork unitOfWork)
		{
			this.lookupRepository = lookupRepository;
			this.unitOfWork = unitOfWork;
		}

		public void Fetch(int lookupId)
		{
			if (lookupId <= 0)
			{
				throw new ArgumentException(ValidationMessages.ArgumentException.InvalidId, Lookup.FieldLabels.LookupId);
			}

			var lookup = lookupRepository.GetById(lookupId);

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
			lookupRepository.Add(lookup);
			this.Save();
		}

		public void Update()
		{
			var lookup = lookupRepository.GetById(this.LookupId);

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

				lookupRepository.Update(lookup);
				this.Save();
			}
		}

		public void Delete(int lookupId)
		{
			var lookup = lookupRepository.GetById(lookupId);
			if (lookup != null)
			{
				lookup.IsDeleted = true;
				lookupRepository.Update(lookup);

				this.Save();
			}
		}

		public void Save()
		{
			this.unitOfWork.Commit();
		}

		public static class FieldLabels
		{
			public const string LookupId = "Lookup Id";
		}
	}
}