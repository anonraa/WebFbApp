using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebFbApp.Startup))]
namespace WebFbApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
