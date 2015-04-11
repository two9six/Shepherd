using Autofac;
using Autofac.Integration.Mvc;
using Shepherd.Core.Contracts.Infrastructure;

namespace Shepherd.Web.Infrastructure
{
	public sealed class WebContainerBuilderComposition :
		IContainerBuilderComposition
	{
		public void Compose(ContainerBuilder builder)
		{
			var assembly = typeof(WebContainerBuilderComposition).Assembly;
			builder.RegisterControllers(assembly).PropertiesAutowired();
			builder.RegisterModelBinders(assembly);
			builder.RegisterModelBinderProvider();
			builder.RegisterFilterProvider();
			//builder.RegisterType<InternalFormsAuthentication>().As<IFormsAuthentication>();
			//builder.RegisterType<ApplicationAuthentication>().As<IApplicationAuthentication>();
			//builder.RegisterInstance<ObjectCache>(MemoryCache.Default);
			//builder.RegisterType<FileSystem>().As<IFileSystem>();
			//builder.RegisterType<FileConverter>().As<IFileConverter>();
			//builder.RegisterType<ExcelExportHelper>().As<IExcelExportHelper>();
		}
	}
}