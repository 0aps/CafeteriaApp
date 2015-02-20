using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CafeteriaApp.Startup))]
namespace CafeteriaApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
