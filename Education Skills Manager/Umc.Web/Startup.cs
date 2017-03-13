using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Umc.Web.Startup))]
namespace Umc.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
