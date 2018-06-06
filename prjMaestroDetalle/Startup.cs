using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(prjMaestroDetalle.Startup))]
namespace prjMaestroDetalle
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
