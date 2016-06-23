using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(OverTime.Startup))]
namespace OverTime
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
