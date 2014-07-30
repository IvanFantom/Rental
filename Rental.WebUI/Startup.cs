using Microsoft.Owin;
using Owin;
using Startup = Rental.WebUI.Startup;

[assembly: OwinStartup(typeof(Startup))]
namespace Rental.WebUI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
