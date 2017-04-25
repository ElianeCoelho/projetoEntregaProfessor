using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Classificados.Startup))]
namespace Classificados
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
