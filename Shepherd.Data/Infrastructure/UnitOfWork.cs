using Shepherd.Data.Infrastructure.Contracts;

namespace Shepherd.Data.Infrastructure
{
	public class UnitOfWork : IUnitOfWork
	{
		private readonly IDatabaseFactory databaseFactory;
		private ShepherdEntities dataContext;

		public UnitOfWork(IDatabaseFactory databaseFactory)
		{
			this.databaseFactory = databaseFactory;
		}

		protected ShepherdEntities DataContext
		{
			get { return dataContext ?? (dataContext = databaseFactory.Get()); }
		}

		public void Commit()
		{
			DataContext.Commit();
		}
	}
}