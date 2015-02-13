using Shepherd.Model.Models;
using System.Data.Entity.ModelConfiguration;

namespace Shepherd.Data.Configuration
{
	internal sealed class PersonConfiguration : EntityTypeConfiguration<Person>
	{
		public PersonConfiguration()
		{
			this.Property(_ => _.FirstName).IsRequired().HasMaxLength(100);
			this.Property(_ => _.LastName).IsRequired().HasMaxLength(100);
			this.Property(_ => _.MiddleName).IsOptional().HasMaxLength(100);
			this.Property(_ => _.BirthDate).IsRequired();
			this.Property(_ => _.DateCreated).IsOptional();
			this.Property(_ => _.DateUpdated).IsOptional();
			this.Property(_ => _.IsDeleted).IsRequired();
		}
	}
}