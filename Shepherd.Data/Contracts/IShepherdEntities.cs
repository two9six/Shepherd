using Shepherd.Model.Models;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace Shepherd.Data.Contracts
{
	public interface IShepherdEntities
	{
		DbSet<Person> People { get; set; }
		DbSet<Member> Members { get; set; }

		Database Database { get; }
		DbEntityEntry Entry(object entity);
	}
}