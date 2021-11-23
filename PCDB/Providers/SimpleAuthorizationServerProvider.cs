using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.OAuth;
using PCDB.Models;
using PCDB.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;

namespace PCDB.Providers
{
    public class SimpleAuthorizationServerProvider : OAuthAuthorizationServerProvider
    {
        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            context.OwinContext.Request.Headers.Add("Access-Control-Allow-Origin", new[] { "*" });

            using (AuthRepository _repo = new AuthRepository())
            {
                var user = _repo.FindUser(context.UserName, context.Password);
                if (user == null)
                {
                    context.SetError("Invalid Authentication", "The username or password is incorrect");
                    return;
                }
                
                var identity = new ClaimsIdentity(context.Options.AuthenticationType);
                //identity.AddClaim(new Claim("Name", context.UserName));
                //identity.AddClaim(new Claim("Role", "WebApiUser"));

                identity.AddClaim(new Claim(ClaimTypes.Name, user.UserName));
                foreach (var role in _repo.GetRoles(user.UserName))
                {
                    identity.AddClaim(new Claim(ClaimTypes.Role, role));
                }

                AuthenticationTicket ticket = new AuthenticationTicket(identity, new AuthenticationProperties());
                context.Response.Cookies.Append("Token", context.Options.AccessTokenFormat.Protect(ticket));

                context.Validated(identity);
            }
        }
    }
}