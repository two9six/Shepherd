using Autofac;
using Autofac.Integration.Mvc;
using Shepherd.BusinessLogic.Entities;
using Shepherd.BusinessLogic.Entities.Members;
using Shepherd.BusinessLogic.Entities.Members.Contracts;
using Shepherd.Data.Infrastructure;
using Shepherd.Data.Infrastructure.Contracts;
using Shepherd.Data.Repository;
using Shepherd.Web.Mappings;
using System.Reflection;
using System.Web.Mvc;

namespace Shepherd.Web
{
	public static class Bootstrapper
	{
		public static void Run()
		{
			Bootstrapper.SetAutofacContainer();

			AutoMapperConfiguration.Configure();
		}

		private static void SetAutofacContainer()
		{
			var builder = new ContainerBuilder();
			builder.RegisterControllers(Assembly.GetExecutingAssembly());

			builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerRequest();
			builder.RegisterType<DatabaseFactory>().As<IDatabaseFactory>().InstancePerRequest();

			builder.RegisterType<MemberDetails>().As<IMemberDetails>().InstancePerRequest();
			builder.RegisterType<MemberList>().As<IMemberList>().InstancePerRequest();

			builder.RegisterAssemblyTypes(typeof(PersonRepository).Assembly)
				.Where(_ => _.Name.EndsWith("Repository"))
				.AsImplementedInterfaces()
				.InstancePerRequest();

			builder.RegisterFilterProvider();
			IContainer container = builder.Build();
			DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
		}
	}
}