using Autofac;
using Shepherd.Core.Contracts.Infrastructure;
using Shepherd.Domain.Contracts.Models.Members;
using Shepherd.Domain.Contracts.Services.Lookup;
using Shepherd.Domain.Models.Members;
using Shepherd.Domain.Services.Lookup;

namespace Shepherd.Domain.Infrastructure
{
	public sealed class DomainContainerBuilderComposition
		: IContainerBuilderComposition
	{
		public void Compose(ContainerBuilder builder)
		{
			builder.RegisterType<MemberDetails>().As<IMemberDetails>();
			builder.RegisterType<MemberList>().As<IMemberList>();
			builder.RegisterType<LookupSelectListService>().As<ILookupSelectListService>();
		}
	}
}
