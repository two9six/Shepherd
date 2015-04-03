using PagedList;
using Shepherd.Data.Contracts;
using Shepherd.Data.Contracts.Infrastructure;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace Shepherd.Data.Infrastructure
{
	public abstract class RepositoryBase<T> 
		: IRepositoryBase<T> where T : class
	{
		public IShepherdEntities Context { get; set; }

		public virtual T Add(T entity)
		{
			return this.Context.Set<T>().Add(entity);
		}

		public virtual T Edit(T entity)
		{
			// TODO: Check which approach is better
			//var attachedEntity = dbSet.Attach(entity);
			//databaseContext.Entry(entity).State = EntityState.Modified;
			//return attachedEntity;

			this.Context.Entry(entity).State = EntityState.Modified;
			return entity;
		}

		public virtual T Delete(T entity)
		{
			return this.Context.Set<T>().Remove(entity);
		}

		public void Delete(Expression<Func<T, bool>> where)
		{
			IEnumerable<T> objects = this.Context.Set<T>().Where<T>(where).AsEnumerable();
			foreach (T obj in objects)
			{
				this.Context.Set<T>().Remove(obj);
			}
		}

		public T GetById(int id)
		{
			return this.Context.Set<T>().Find(id);
		}

		public IEnumerable<T> GetAll()
		{
			return this.Context.Set<T>().ToList();
		}

		public IEnumerable<T> FindBy(Expression<Func<T, bool>> predicate)
		{
			return this.Context.Set<T>().Where(predicate);
		}

		public IEnumerable<T> ExecWithStoreProcedure(string query, params object[] parameters)
		{
			return this.Context.Database.SqlQuery<T>(query, parameters);
		}

		public IPagedList<T> GetPage<TOrder>(Page page, Expression<Func<T, bool>> where, Expression<Func<T, TOrder>> order)
		{
			var results = this.Context.Set<T>().OrderBy(order).Where(where).GetPage(page).ToList();
			var total = this.Context.Set<T>().Count(where);
			return new StaticPagedList<T>(results, page.PageNumber, page.PageSize, total);
		}
	}
}