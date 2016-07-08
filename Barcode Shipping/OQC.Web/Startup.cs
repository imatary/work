using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(OQC.Web.Startup))]
namespace OQC.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
