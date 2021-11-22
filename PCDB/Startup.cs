using Microsoft.Owin;
using Microsoft.Owin.Security.OAuth;
using Owin;
using PCDB.App_Start;
using PCDB.Providers;
using System.Web.Http;

[assembly: OwinStartupAttribute(typeof(PCDB.Startup))]
namespace PCDB
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            ConfigureOAuth(app);
        }

        public void ConfigureOAuth(IAppBuilder app)
        {
            OAuthAuthorizationServerOptions OAuthServerOptions = new OAuthAuthorizationServerOptions()
            {
                AllowInsecureHttp = true,
                TokenEndpointPath = new PathString("/login"),
                AccessTokenExpireTimeSpan = System.TimeSpan.FromDays(14),
                Provider = new SimpleAuthorizationServerProvider()
            };

            // Token generation
            app.UseOAuthAuthorizationServer(OAuthServerOptions);
            app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());
        }
    }
}
