using System.Collections.Generic;

namespace Shepherd.BusinessLogic.Infrastructure.Contracts
{
	public interface IListEntityBase<T> where T : class
	{
		List<T> Items { get; set; }
	}
}