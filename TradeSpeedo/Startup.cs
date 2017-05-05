using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TradeSpeedo.Startup))]
namespace TradeSpeedo
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
