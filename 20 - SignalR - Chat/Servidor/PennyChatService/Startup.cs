using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(PennyChatService.Startup))]

namespace PennyChatService
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureMobileApp(app);
        }
    }
}