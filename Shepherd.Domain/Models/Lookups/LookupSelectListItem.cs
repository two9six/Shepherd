using Shepherd.Domain.Contracts.Models.Lookups;
using SE = Shepherd.Entities;

namespace Shepherd.Domain.Models.Lookups
{
	public sealed class LookupSelectListItem : ILookupSelectListItem<LookupSelectListItem>
	{
		public int LookupTypeId { get; set; }

		public string Name { get; set; }

		public bool IsDefault { get; set; }

		public LookupSelectListItem FetchChild(SE.Lookup entity)
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