using Shepherd.Data.Contracts.Infrastructure;
using Shepherd.Model.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Shepherd.Data.Infrastructure
{
	public class ShepherdEntities : DbContext, IShepherdEntities
	{
		public ShepherdEntities()
			: base("ShepherdEntities")
		{
			this.Configuration.LazyLoadingEnabled = false;
			Database.SetInitializer<ShepherdEntities>(null);
		}

		public IDbSet<Person> People { get; set; }
		public IDbSet<Member> Members { get; set; }
		public IDbSet<LookupType> LookupTypes { get; set; }
		public IDbSet<Lookup> Lookups { get; set; }

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);


			modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

			modelBuilder.Entity<Person>().ToTable("Person");
			modelBuilder.Entity<Member>().ToTable("Member");
			modelBuilder.Entity<LookupType>().ToTable("LookupType");
			modelBuilder.Entity<Lookup>().ToTable("Lookup");
		}
	}
}