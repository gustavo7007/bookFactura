using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FacturacionCloud.Startup))]
namespace FacturacionCloud
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
