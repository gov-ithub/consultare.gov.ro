using Microsoft.Owin;
using Microsoft.Owin.Security.OAuth;
using Microsoft.Practices.Unity;
using Newtonsoft.Json.Serialization;
using Ng2Net.Data;
using Ng2Net.Services;
using Owin;
using System;
using System.Data.Entity;
using System.Linq;
using System.Net.Http.Formatting;
using System.Web.Http;
using Unity.WebApi;

[assembly: OwinStartup(typeof(Ng2Net.WebApi.Startup))]
namespace Ng2Net.WebApi
{

    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            log4net.Config.XmlConfigurator.Configure();
            var config = new HttpConfiguration();

	        var container = UnityConfig.RegisterComponents();
            config.DependencyResolver = new UnityDependencyResolver(container);            
	        WebApiConfig.Register(config);            
            ConfigureOAuth(app, container);
            app.UseWebApi(config);
        }


        private void ConfigureOAuth(IAppBuilder app, IUnityContainer container)
        {
            app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);
            OAuthAuthorizationServerOptions OAuthServerOptions = new OAuthAuthorizationServerOptions()
            {
                AllowInsecureHttp = true,
                TokenEndpointPath = new PathString("/api/token"),
                AccessTokenExpireTimeSpan = TimeSpan.FromDays(1),
                Provider = new SimpleAuthorizationServerProvider(),
                
            };
            //investigate di here
            app.CreatePerOwinContext(() => container.Resolve<DbContext>());
            app.CreatePerOwinContext<ApplicationUserService>(ApplicationUserService.Create);
            // Token Generation
            app.UseOAuthAuthorizationServer(OAuthServerOptions);
            app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());
            //app.UseGoogleAuthentication(new GoogleOAuth2AuthenticationOptions { ClientId = "1" });
        }

    }
}
