using Shepherd.Data.Infrastructure.Contracts;

namespace Shepherd.Data.Infrastructure
{
	public class DatabaseFactory : Disposable, IDatabaseFactory
	{
		private ShepherdEntities dataContext;

		public ShepherdEntities Get()
		{
			return dataContext ?? (dataContext = new ShepherdEntities());
		}

		protected override void DisposeCore()
		{
			if (dataContext != null)
			{
				dataContext.Dispose();
			}
		}
	}
}