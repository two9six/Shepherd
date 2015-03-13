using Shepherd.Domain.Entities.Lookups.Contracts;
using SMM = Shepherd.Model.Models;

namespace Shepherd.Domain.Entities.Lookups
{
	public sealed class LookupSelectListItem : ILookupSelectListItem<LookupSelectListItem>
	{
		public int LookupTypeId { get; set; }

		public string Name { get; set; }

		public bool IsDefault { get; set; }

		public LookupSelectListItem LoadChild(SMM.Lookup entity)
		{
			if (entity != null)
			{
				this.LookupTypeId = entity.Id;
				this.Name = entity.Name;
				this.IsDefault = entity.IsDefault;
			}

			return this;
		}
	}
}