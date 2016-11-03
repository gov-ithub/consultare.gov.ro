using Consultare.Database;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.OAuth;
using System.Net;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Consultare.WebApi
{
    public class SimpleAuthorizationServerProvider : OAuthAuthorizationServerProvider
    {
        private UserManager<IdentityUser> _userManager;
        private DatabaseContext _context;

        public SimpleAuthorizationServerProvider()
        {
            this._context = new DatabaseContext();
            this._userManager = new UserManager<IdentityUser>(new UserStore<IdentityUser>(_context));
        }

        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
        }


        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {


            IdentityUser user = await this._userManager.FindAsync(context.UserName, context.Password);

            if (user == null)
            {
                context.SetError("invalid_grant", "The user name or password is incorrect.");
                return;
            }

            var identity = new ClaimsIdentity(context.Options.AuthenticationType);
            identity.AddClaim(new Claim(ClaimTypes.Name, context.UserName));
            identity.AddClaims(_userManager.GetClaims(user.Id));
            AuthenticationManager.(new AuthenticationProperties
            {
                IsPersistent = true
            }, identity);
            context.Validated(identity);

        }
    }
}