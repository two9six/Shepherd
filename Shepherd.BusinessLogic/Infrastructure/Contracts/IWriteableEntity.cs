using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shepherd.BusinessLogic.Infrastructure.Contracts
{
	public interface IWriteableEntity<T> where T : class
	{
		void Create(T entity);
		void Edit(T entity);
		void Delete(int id);
		void Save();
		T Fetch(int id);
	}
}