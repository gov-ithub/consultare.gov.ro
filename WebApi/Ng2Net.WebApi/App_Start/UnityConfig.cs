using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.InterceptionExtension;
using Ng2Net.Data;
using Ng2Net.Infrastructure.Data;
using Ng2Net.Infrastructure.Interfaces;
using Ng2Net.Infrastructure.Logging;
using Ng2Net.Model.Business;
using Ng2Net.Model.Security;
using Ng2Net.Services.Admin;
using Ng2Net.Services.Business;
using Ng2Net.Services.Scheduler;
using Ng2Net.Services.Security;
using Ng2Net.WebApi.Controllers;
using System;
using System.Data.Common;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Web.Http;
using Unity.WebApi;

namespace Ng2Net.WebApi
{
    public static class UnityConfig
    {
        public static IUnityContainer RegisterComponents()
        {
            var container = new UnityContainer();
            container.AddNewExtension<Interception>();

            var interceptor = new Interceptor<InterfaceInterceptor>();
            var behaver = new InterceptionBehavior<LoggingInterceptionBehavior>();
            
            container.RegisterType<DbContext, DatabaseContext>(new HierarchicalLifetimeManager());
            container.RegisterType<IdentityDbContext<ApplicationUser>, DatabaseContext>(new PerResolveLifetimeManager());            

            container.RegisterType(typeof(IRepository<>), typeof(EfRepository<>));


            container.RegisterType<IInstitutionService, InstitutionService>(interceptor, behaver);
            container.RegisterType<IHtmlContentService, HtmlContentService>(interceptor, behaver);
            container.RegisterType<INotificationService, NotificationService>(interceptor, behaver);
            container.RegisterType<IProposalService, ProposalService>(interceptor, behaver);
            container.RegisterType<IApplicationAccountService, ApplicationAccountService>(interceptor, behaver);
            container.RegisterType<INotificationService, NotificationService>(interceptor, behaver);

            return container;
        }        
    }
}
