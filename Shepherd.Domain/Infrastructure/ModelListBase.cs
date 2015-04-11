using System.Collections.Generic;

namespace Shepherd.Domain.Infrastructure
{
	public abstract class ModelListBase<T> where T : class
	{
		public List<T> Items { get; set; }

		public virtual void Fetch() { }

		protected ModelListBase()
		{
			this.Items = new List<T>();
		}
	}
}