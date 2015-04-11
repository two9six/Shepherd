using System.Collections.Generic;

namespace Shepherd.Domain.Contracts.Infrastructure
{
	public interface IModelListBase<T> where T : class
	{
		List<T> Items { get; set; }
		void Fetch();
	}
}