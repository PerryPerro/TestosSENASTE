using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Testos.Startup))]
namespace Testos
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
