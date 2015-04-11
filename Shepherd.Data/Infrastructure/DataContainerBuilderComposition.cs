using Autofac;
using Shepherd.Core.Contracts.Infrastructure;
using Shepherd.Data.Contracts.Infrastructure;
using Shepherd.Data.Repository;

namespace Shepherd.Data.Infrastructure
{
	public sealed class DataContainerBuilderComposition
		: IContainerBuilderComposition
	{
		public void Compose(ContainerBuilder builder)
		{
			builder.RegisterType<UnitOfWork>().As<IUnitOfWork>();

			builder.RegisterAssemblyTypes(typeof(PersonRepository).Assembly)
				.Where(_ => _.Name.EndsWith("Repository"))
				.AsImplementedInterfaces()
				.InstancePerRequest();
		}
	}
}