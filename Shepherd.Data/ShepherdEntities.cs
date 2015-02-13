using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shepherd.Model.Models;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using Shepherd.Data.Configuration;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Shepherd.Data
{
	public class ShepherdEntities : DbContext
	{
		public ShepherdEntities()
			: base("ShepherdEntities")
		{
			Database.SetInitializer<ShepherdEntities>(null);
		}

		public DbSet<Person> People { get; set; }
		public DbSet<Member> Members { get; set; }

		public virtual void Commit()
		{
			base.SaveChanges();
		}

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);


			modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

			modelBuilder.Entity<Person>().ToTable("Person");
			modelBuilder.Entity<Member>().ToTable("Member");

			modelBuilder.Configurations.Add(new PersonConfiguration());
			modelBuilder.Configurations.Add(new MemberConfiguration());
		}

	}
}