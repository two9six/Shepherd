using System.Collections.Generic;

namespace Shepherd.Domain.Infrastructure.Contracts
{
	public interface IListEntityBase<T> where T : class
	{
		List<T> Items { get; set; }
		void Fetch();
	}
}