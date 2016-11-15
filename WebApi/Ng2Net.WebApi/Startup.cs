using Ng2Net.Database;
using Ng2Net.Database.IdentityHelpers;
using Microsoft.Owin;
using Microsoft.Owin.Security.OAuth;
using Owin;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;
using Microsoft.Owin.Security.Google;

[assembly: OwinStartup(typeof(Ng2Net.WebApi.Startup))]
namespace Ng2Net.WebApi
{

    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureOAuth(app);
            HttpConfiguration config = new HttpConfiguration();

            WebApiConfig.Register(config);
            app.UseWebApi(config);
        }


        private void ConfigureOAuth(IAppBuilder app)
        {
            app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);
            OAuthAuthorizationServerOptions OAuthServerOptions = new OAuthAuthorizationServerOptions()
            {
                AllowInsecureHttp = true,
                TokenEndpointPath = new PathString("/api/token"),
                AccessTokenExpireTimeSpan = TimeSpan.FromDays(1),
                Provider = new SimpleAuthorizationServerProvider(),
                
            };
            app.CreatePerOwinContext(()=>new DatabaseContext());
            app.CreatePerOwinContext<ApplicationUserManager>(ApplicationUserManager.Create);
            // Token Generation
            app.UseOAuthAuthorizationServer(OAuthServerOptions);
            app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());
            //app.UseGoogleAuthentication(new GoogleOAuth2AuthenticationOptions { ClientId = "1" });
        }

    }
}