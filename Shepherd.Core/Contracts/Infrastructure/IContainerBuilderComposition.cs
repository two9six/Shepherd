using Autofac;

namespace Shepherd.Core.Contracts.Infrastructure
{
	public interface IContainerBuilderComposition
	{
		void Compose(ContainerBuilder builder);
	}
}