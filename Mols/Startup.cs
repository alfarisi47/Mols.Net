using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Mols.Startup))]
namespace Mols
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
