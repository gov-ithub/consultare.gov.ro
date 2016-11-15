using Ng2Net.Database;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net.Http.Formatting;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Ng2Net.WebApi
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            var jsonFormatter = config.Formatters.OfType<JsonMediaTypeFormatter>().First();
            jsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();

            PrepareDbMigration();
        }

        private static void PrepareDbMigration()
        {
            System.Data.Entity.Database.SetInitializer<DatabaseContext>(new MigrateDatabaseToLatestVersion<DatabaseContext, Ng2Net.Database.Migrations.Configuration>());
            DatabaseContext context = new DatabaseContext();
            context.Database.Initialize(false);
            System.Data.Entity.Database.SetInitializer<DatabaseContext>(null);
        }

    }
}
