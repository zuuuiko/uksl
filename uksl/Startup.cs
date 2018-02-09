using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(uksl.Startup))]
namespace uksl
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
