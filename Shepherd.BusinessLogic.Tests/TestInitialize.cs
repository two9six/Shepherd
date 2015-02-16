using Autofac;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shepherd.BusinessLogic.Entities.Members;
using Shepherd.BusinessLogic.Entities.Members.Contracts;
using Shepherd.Data.Infrastructure;
using Shepherd.Data.Infrastructure.Contracts;
using Shepherd.Data.Repository;

namespace Shepherd.BusinessLogic.Tests
{
	[TestClass]
	public sealed class TestInitialize
	{
		[AssemblyInitialize]
		public static void AssembleInitialize(TestContext context)
		{
			var builder = new ContainerBuilder();

			builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerRequest();
			builder.RegisterType<DatabaseFactory>().As<IDatabaseFactory>().InstancePerRequest();

			builder.RegisterType<MemberDetails>().As<IMemberDetails>().InstancePerRequest();
			builder.RegisterType<MemberList>().As<IMemberList>().InstancePerRequest();

			builder.RegisterAssemblyTypes(typeof(PersonRepository).Assembly)
				.Where(_ => _.Name.EndsWith("Repository"))
				.AsImplementedInterfaces()
				.InstancePerRequest();

			IContainer container = builder.Build();
			container.BeginLifetimeScope();
		}
	}
}
