using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SellAndBuy.Web.Startup))]
namespace SellAndBuy.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
