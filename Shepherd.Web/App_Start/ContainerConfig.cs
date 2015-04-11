using Autofac;
using Autofac.Integration.Mvc;
using Shepherd.Core.Infrastructure;
using Shepherd.Data.Infrastructure;
using Shepherd.Domain.Infrastructure;
using Shepherd.Web.Infrastructure;
using System.Web.Mvc;

namespace Shepherd.Web
{
	public static class ContainerConfig
	{
		public static void Build()
		{
			var builder = new ContainerBuilder();
			ContainerConfig.RunCompositions(builder);
			IoC.Container = builder.Build();
			DependencyResolver.SetResolver(new AutofacDependencyResolver(IoC.Container));
		}

		private static void RunCompositions(ContainerBuilder builder)
		{
			new CoreContainerBuilderComposition().Compose(builder);
			new DataContainerBuilderComposition().Compose(builder);
			new DomainContainerBuilderComposition().Compose(builder);
			new WebContainerBuilderComposition().Compose(builder);
		}
	}
}