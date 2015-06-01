using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace Shepherd.Entities.Contracts
{
	public interface IShepherdContext : IDisposable
	{
		DbSet<Lookup> Lookups { get; set; }
		DbSet<LookupType> LookupTypes { get; set; }
		DbSet<Member> Members { get; set; }
		DbSet<Person> People { get; set; }

		Database Database { get; }
		DbEntityEntry Entry(object entity);
		int SaveChanges();	
		DbSet Set(Type entityType);
		DbSet<T> Set<T>() where T : class;
		
	}
}