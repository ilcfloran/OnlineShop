using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(OnlineShop.Web.Startup))]
namespace OnlineShop.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
