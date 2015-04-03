using Shepherd.Domain.Contracts.Models.Lookups;
using System.Collections.Generic;

namespace Shepherd.Domain.Models.Lookups
{
	public sealed class LookupType : ILookupType<Lookup>
	{
		public int Id { get; set; }

		public string Name { get; set; }

		public bool IsDeleted { get; set; }

		public List<Lookup> Lookups { get; set; } 
	}
}