using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(EuroLeague.Startup))]
namespace EuroLeague
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
