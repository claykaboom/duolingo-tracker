using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(duolingo_tracker.Startup))]
namespace duolingo_tracker
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
