using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Shepherd.Data.Contracts.Infrastructure
{
	public interface IRepositoryBase<T>
		where T : class
	{
		IShepherdEntities Context { get; set; }
		T Add(T entity);
		T Edit(T entity);
		T Delete(T entity);
		T GetById(int id);
		IEnumerable<T> GetAll();
		IEnumerable<T> FindBy(Expression<Func<T, bool>> predicate);
		IEnumerable<T> ExecWithStoreProcedure(string query, params object[] parameters);
	}
}