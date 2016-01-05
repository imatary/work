using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MeetingRoom.Web.Startup))]
namespace MeetingRoom.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
