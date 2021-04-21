using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(LexMVC.Startup))]
namespace LexMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
