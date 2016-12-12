using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Ng2Net.Data;
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
            config.IncludeErrorDetailPolicy = IncludeErrorDetailPolicy.Always;
            config.MapHttpAttributeRoutes();           
            var jsonFormatter = config.Formatters.OfType<JsonMediaTypeFormatter>().First();
            jsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            jsonFormatter.SerializerSettings.DateFormatHandling = DateFormatHandling.IsoDateFormat;
            jsonFormatter.SerializerSettings.DateTimeZoneHandling = DateTimeZoneHandling.Unspecified;
            PrepareDbMigration();
        }

        //to be removed
        private static void PrepareDbMigration()
        {
            System.Data.Entity.Database.SetInitializer<DatabaseContext>(new MigrateDatabaseToLatestVersion<DatabaseContext, Ng2Net.Data.Migrations.Configuration>());
            DatabaseContext context = new DatabaseContext();
            context.Database.Initialize(false);
            System.Data.Entity.Database.SetInitializer<DatabaseContext>(null);
        }

    }
}
