using Autofac;
using Autofac.Integration.Mvc;
using Shepherd.BusinessLogic.Entities;
using Shepherd.BusinessLogic.Entities.Contracts;
using Shepherd.Data.Infrastructure;
using Shepherd.Data.Infrastructure.Contracts;
using Shepherd.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace Shepherd.Web
{
	public static class Bootstrapper
	{
		public static void Run()
		{
			Bootstrapper.SetAutofacContainer();			
		}

		private static void SetAutofacContainer()
		{
			var builder = new ContainerBuilder();
			builder.RegisterControllers(Assembly.GetExecutingAssembly());

			builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerRequest();
			builder.RegisterType<DatabaseFactory>().As<IDatabaseFactory>().InstancePerRequest();

			builder.RegisterType<MemberDetails>().As<IMemberDetails>().InstancePerRequest();

			builder.RegisterAssemblyTypes(typeof(PersonRepository).Assembly)
				.Where(_ => _.Name.EndsWith("Repository"))
				.AsImplementedInterfaces()
				.InstancePerRequest();

			// builder.RegisterAssemblyTypes(typeof(GoalService).Assembly)
			//.Where(t => t.Name.EndsWith("Service"))
			//.AsImplementedInterfaces().InstancePerHttpRequest();

			//builder.Register(c => new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new SocialGoalEntities())))
			//	.As<UserManager<ApplicationUser>>().InstancePerHttpRequest();

			builder.RegisterFilterProvider();
			IContainer container = builder.Build();
			DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
		}
	}
}