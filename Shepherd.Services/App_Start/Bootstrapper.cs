using Autofac;
using Autofac.Integration.WebApi;
using Shepherd.Core.Infrastructure;
using Shepherd.Data.Infrastructure;
using Shepherd.Domain.Infrastructure;
using System.Reflection;
using System.Web.Http;

namespace Shepherd.Services.App_Start
{
    public static class Bootstrapper
    {
        public static void Run()
        {
            SetAutofacWebApi();
        }

        private static void SetAutofacWebApi()
        {
            var configuration = GlobalConfiguration.Configuration;
            var builder = new ContainerBuilder();

            new CoreContainerBuilderComposition().Compose(builder);
            new DataContainerBuilderComposition().Compose(builder);
            new DomainContainerBuilderComposition().Compose(builder);

            builder.RegisterApiControllers(Assembly.GetExecutingAssembly()).PropertiesAutowired();

            var container = builder.Build();

            configuration.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }

    }
}