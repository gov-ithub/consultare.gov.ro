using Ng2Net.Database;
using Ng2Net.Database.DatabaseEntities;
using Ng2Net.Database.IdentityHelpers;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.OAuth;
using System.Net;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Ng2Net.WebApi
{
    public class SimpleAuthorizationServerProvider : OAuthAuthorizationServerProvider
    {
        private ApplicationUserManager _userManager;

        public SimpleAuthorizationServerProvider()
        {
        }

        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
        }

        
        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            this._userManager = context.OwinContext.GetUserManager<ApplicationUserManager>();

            ApplicationUser user = await _userManager.FindAsync(context.UserName, context.Password);

            if (user == null)
            {
                context.SetError("invalid_grant", "User name sau parola invalida");
                return;
            }

            ClaimsIdentity oAuthIdentity = await user.GenerateUserIdentityAsync(_userManager, "JWT");

            var ticket = new AuthenticationTicket(oAuthIdentity, null);

            context.Validated(ticket);

        }
    }
}