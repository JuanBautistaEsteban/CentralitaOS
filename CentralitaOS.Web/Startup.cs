using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CentralitaOS.Web.Startup))]
namespace CentralitaOS.Web
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
