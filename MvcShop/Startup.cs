using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MvcShop.Startup))]
namespace MvcShop
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
