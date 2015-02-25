using Shepherd.BusinessLogic.Entities.Lookup.Contracts;
using SMM = Shepherd.Model.Models;

namespace Shepherd.BusinessLogic.Entities.Lookup
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