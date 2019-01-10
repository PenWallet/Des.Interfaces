using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(DardosServer.Startup))]

namespace DardosServer
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.MapSignalR();
        }
    }
}