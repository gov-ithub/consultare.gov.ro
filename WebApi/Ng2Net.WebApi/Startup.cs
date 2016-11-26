using Microsoft.Owin;
using Microsoft.Owin.Security.OAuth;
using Newtonsoft.Json.Serialization;
using Ng2Net.Data;
using Ng2Net.Services;
using Ng2Net.WebApi.App_Start;
using Owin;
using System;
using System.Linq;
using System.Net.Http.Formatting;
using System.Web.Http;

[assembly: OwinStartup(typeof(Ng2Net.WebApi.Startup))]
namespace Ng2Net.WebApi
{

    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var config = new HttpConfiguration();
            log4net.Config.XmlConfigurator.Configure();
            var jsonFormatter = config.Formatters.OfType<JsonMediaTypeFormatter>().First();
            jsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();

            config.MapHttpAttributeRoutes();
            var container = UnityConfig.RegisterComponents();
            config.DependencyResolver = new UnityResolver(container);
            //WebApiConfig.Register(config);
            ConfigureOAuth(app);
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
            //investigate di here
            app.CreatePerOwinContext(()=>new DatabaseContext());
            app.CreatePerOwinContext<ApplicationUserService>(ApplicationUserService.Create);
            // Token Generation
            app.UseOAuthAuthorizationServer(OAuthServerOptions);
            app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());
            //app.UseGoogleAuthentication(new GoogleOAuth2AuthenticationOptions { ClientId = "1" });
        }

    }
}