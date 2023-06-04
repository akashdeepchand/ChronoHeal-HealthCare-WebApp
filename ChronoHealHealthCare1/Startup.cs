using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ChronoHealHealthCare1.Startup))]
namespace ChronoHealHealthCare1
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
