using System.Collections.Generic;

namespace Shepherd.BusinessLogic.Entities.Lookup.Contracts
{
	public interface ILookupType<T> where T : ILookup
	{
		int Id { get; set; }

		string Name { get; set; }

		bool IsDeleted { get; set; }

		List<T> Lookups { get; set; }
	}
}