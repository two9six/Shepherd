using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shepherd.Model.Models;
using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity.Infrastructure;

namespace Shepherd.Data
{
	public class ShepherdEntities : IdentityDbContext<ApplicationUser>
	{

		public ShepherdEntities()
			: base("ShepherdEntities")
		{
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
			modelBuilder.Conventions.Remove<IncludeMetadataConvention>();
		}

	}
}
