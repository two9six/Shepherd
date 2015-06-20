using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Shepherd.WebAngular.Startup))]
namespace Shepherd.WebAngular
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
