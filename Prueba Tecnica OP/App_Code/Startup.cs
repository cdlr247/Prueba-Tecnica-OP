using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Prueba_Tecnica_OP.Startup))]
namespace Prueba_Tecnica_OP
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
