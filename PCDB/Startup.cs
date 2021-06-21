using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PCDB.Startup))]
namespace PCDB
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
