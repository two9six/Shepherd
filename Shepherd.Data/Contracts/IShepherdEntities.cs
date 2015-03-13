using Shepherd.Model.Models;
using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace Shepherd.Data.Contracts
{
	public interface IShepherdEntities: IDisposable
	{
		IDbSet<Person> People { get; set; }
		IDbSet<Member> Members { get; set; }
		IDbSet<LookupType> LookupTypes { get; set; }
		IDbSet<Lookup> Lookups { get; set; }

		DbSet<T> Set<T>() where T : class;
		DbEntityEntry Entry(object entity);
		Database Database { get; }
		int SaveChanges();
	}
}
