using System.Collections.Generic;

namespace Shepherd.BusinessLogic.Infrastructure
{
	public abstract class ListEntityBase<T> where T : class
	{
		public List<T> Items { get; set; }

		protected ListEntityBase()
		{
			this.Items = new List<T>();
		}
	}
}