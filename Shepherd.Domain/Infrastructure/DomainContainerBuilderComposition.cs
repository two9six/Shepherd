using Autofac;
using Shepherd.Core.Contracts.Infrastructure;
using Shepherd.Domain.Contracts.Services;
using Shepherd.Domain.Contracts.Services.Lookup;
using Shepherd.Domain.Services.Lookup;
using Shepherd.Domain.Services.MemberService;

namespace Shepherd.Domain.Infrastructure
{
	public sealed class DomainContainerBuilderComposition
		: IContainerBuilderComposition
	{
		public void Compose(ContainerBuilder builder)
		{
			builder.RegisterType<MemberService>().As<IMemberService>();
			builder.RegisterType<LookupSelectListService>().As<ILookupSelectListService>();
		}
	}
}
