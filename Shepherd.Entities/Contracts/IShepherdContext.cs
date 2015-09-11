using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace Shepherd.Entities.Contracts
{
	public interface IShepherdContext : IDisposable
	{
		DbSet<Designation> Designations { get; set; }
		DbSet<DesignationType> DesignationTypes { get; set; }
		DbSet<GatheringType> GatheringTypes { get; set; }
		DbSet<Member> Members { get; set; }
		DbSet<MemberStatus> MemberStatuses { get; set; }
		DbSet<Person> Persons { get; set; }

		Database Database { get; }
		DbEntityEntry Entry(object entity);
		int SaveChanges();	
		DbSet Set(Type entityType);
		DbSet<T> Set<T>() where T : class;		
	}
}