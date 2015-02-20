using System.Collections.Generic;

namespace Shepherd.Model.Models
{
	public class LookupType
	{
		public int Id { get; set; }

		public string Name { get; set; }

		public bool IsDeleted { get; set; }

		public virtual ICollection<Lookup> Lookups { get; set; }
	}
}