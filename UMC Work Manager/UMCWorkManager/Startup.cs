using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(UMCWorkManager.Startup))]
namespace UMCWorkManager
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
