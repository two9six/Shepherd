using Shepherd.Model.Models;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace Shepherd.Data.Contracts
{
	public interface IShepherdEntities
	{
		IDbSet<Person> People { get; set; }
		IDbSet<Member> Members { get; set; }

		Database Database { get; }
		DbEntityEntry Entry(object entity);
		int SaveChanges();
		void SetState(object entity, EntityState state);
	}
}