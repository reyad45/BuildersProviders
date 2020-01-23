using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BPS.Startup))]
namespace BPS
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
