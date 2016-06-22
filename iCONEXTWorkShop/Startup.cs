using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(iCONEXTWorkShop.Startup))]
namespace iCONEXTWorkShop
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
