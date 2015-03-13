using Shepherd.Domain.Entities.Lookups.Contracts;
using System.Collections.Generic;

namespace Shepherd.Domain.Entities.Lookups
{
	public sealed class LookupType : ILookupType<Lookup>
	{
		public int Id { get; set; }

		public string Name { get; set; }

		public bool IsDeleted { get; set; }

		public List<Lookup> Lookups { get; set; } 
	}
}