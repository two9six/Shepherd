using PagedList;
using Shepherd.Data.Infrastructure.Contracts;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace Shepherd.Data.Infrastructure
{
	public abstract class RepositoryBase<T> where T : class
	{
		private ShepherdEntities dataContext;
		private readonly IDbSet<T> dbSet;

		protected IDatabaseFactory DatabaseFactory { get; private set; }

		protected ShepherdEntities DataContext
		{
			get { return dataContext ?? (dataContext = DatabaseFactory.Get()); }
		}

		protected RepositoryBase(IDatabaseFactory databaseFactory)
		{
			this.DatabaseFactory = databaseFactory;
			dbSet = DataContext.Set<T>();
		}

		public virtual void Add(T entity)
		{
			dbSet.Add(entity);
		}

		public virtual void Update(T entity)
		{
			dbSet.Attach(entity);
			dataContext.Entry(entity).State = EntityState.Modified;
		}

		public virtual void Delete(T entity)
		{
			dbSet.Remove(entity);
		}

		public virtual void Delete(Expression<Func<T, bool>> where)
		{
			IEnumerable<T> objects = dbSet.Where<T>(where).AsEnumerable();
			foreach (T obj in objects)
			{
				dbSet.Remove(obj);
			}
		}

		public virtual T GetById(long id)
		{
			return dbSet.Find(id);
		}

		public virtual T GetById(int id)
		{
			return dbSet.Find(id);
		}

		public virtual T GetById(string id)
		{
			return dbSet.Find(id);
		}

		public virtual IEnumerable<T> GetAll()
		{
			return dbSet.ToList();
		}

		public virtual IEnumerable<T> GetMany(Expression<Func<T, bool>> where)
		{
			return dbSet.Where(where).ToList();
		}

		public virtual IPagedList<T> GetPage<TOrder>(Page page, Expression<Func<T, bool>> where, Expression<Func<T, TOrder>> order)
		{
			var results = dbSet.OrderBy(order).Where(where).GetPage(page).ToList();
			var total = dbSet.Count(where);
			return new StaticPagedList<T>(results, page.PageNumber, page.PageSize, total);
		}

		public T Get(Expression<Func<T, bool>> where)
		{
			return dbSet.Where(where).FirstOrDefault<T>();
		}
	}
}