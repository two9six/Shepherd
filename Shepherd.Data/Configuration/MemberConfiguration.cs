using Shepherd.Model.Models;
using System.Data.Entity.ModelConfiguration;

namespace Shepherd.Data.Configuration
{
	internal sealed class MemberConfiguration : EntityTypeConfiguration<Member>
	{
		public MemberConfiguration()
        {
			this.Property(_ => _.DateCreated).IsOptional();
			this.Property(_ => _.DateUpdated).IsOptional();
			this.Property(_ => _.IsDeleted).IsRequired();
        }
	}
}