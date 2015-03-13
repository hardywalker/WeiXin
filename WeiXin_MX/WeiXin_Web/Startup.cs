using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WeiXin_Web.Startup))]
namespace WeiXin_Web
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
