using Autofac;
using Shepherd.Core.Contracts.Infrastructure;
using Shepherd.Domain.Contracts.Models;
using Shepherd.Domain.Models;

namespace Shepherd.Domain.Infrastructure
{
	public sealed class DomainContainerBuilderComposition
		: IContainerBuilderComposition
	{
		public void Compose(ContainerBuilder builder)
		{
			builder.RegisterType<Member>().As<IMember>();
		}
	}
}