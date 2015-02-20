namespace Shepherd.Model.Models
{
	public class Lookup
	{
		public int Id { get; set; }

		public int LookupTypeId { get; set; }

		public string Name { get; set; }

		public bool IsDefault { get; set; }

		public bool IsDeleted { get; set; }

		public virtual LookupType LookupType { get; set; }
	}
}