using PagedList;
using Shepherd.Data.Contracts;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Shepherd.Data.Infrastructure.Contracts
{
	public interface IRepositoryBase<T>
		where T : class
	{
		IShepherdEntities Context { get; set; }
		T Add(T entity);
		T Edit(T entity);
		T Delete(T entity);
		void Delete(Expression<Func<T, bool>> where);
		T GetById(int id);
		IEnumerable<T> GetAll();
		IEnumerable<T> FindBy(Expression<Func<T, bool>> predicate);
		IEnumerable<T> ExecWithStoreProcedure(string query, params object[] parameters);
		IPagedList<T> GetPage<TOrder>(Page page, Expression<Func<T, bool>> where, Expression<Func<T, TOrder>> order);
	}
}