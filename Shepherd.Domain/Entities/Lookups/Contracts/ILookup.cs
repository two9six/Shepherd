namespace Shepherd.Domain.Entities.Lookups.Contracts
{
	public interface ILookup
	{
		int LookupId { get; set; }

		int LookupTypeId { get; set; }

		string Name { get; set; }

		bool IsDefault { get; set; }

		bool IsDeleted { get; set; }
	}
}