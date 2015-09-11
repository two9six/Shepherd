using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Shepherd.Web.Startup))]
namespace Shepherd.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            //ConfigureAuth(app);
        }
    }
}
