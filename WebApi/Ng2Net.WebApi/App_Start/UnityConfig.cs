using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.InterceptionExtension;
using Ng2Net.Data;
using Ng2Net.Infrastructure.Data;
using Ng2Net.Infrastructure.Interfaces;
using Ng2Net.Infrastructure.Logging;
using Ng2Net.Infrastructure.Services;
using Ng2Net.Model;
using Ng2Net.Model.Admin;
using Ng2Net.Model.Business;
using Ng2Net.Model.Scheduler;
using Ng2Net.Model.Security;
using Ng2Net.Services.Admin;
using Ng2Net.Services.Business;
using Ng2Net.Services.Scheduler;
using Ng2Net.Services.Security;
using System.Web.Http;
using Unity.WebApi;

namespace Ng2Net.WebApi
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();
            container.AddNewExtension<Interception>();

            var interceptor = new Interceptor<InterfaceInterceptor>();
            var behaver = new InterceptionBehavior<LoggingInterceptionBehavior>();

            container
                .RegisterType<IRepository<BaseEntity>, EfRepository<BaseEntity>>(interceptor, behaver)
                .RegisterType<IdentityDbContext<ApplicationUser>, DatabaseContext>(interceptor, behaver)
                .RegisterType<IApplicationAccountService, ApplicationAccountService>(interceptor, behaver)
                .RegisterType<IHtmlContentService, HtmlContentService>(interceptor, behaver)
                .RegisterType<INotificationService, NotificationService>(interceptor, behaver)
                .RegisterType<IProposalService, ProposalService>(interceptor, behaver)
                .RegisterType<IInstitutionService, InstitutionService>(interceptor, behaver)
                .RegisterType<ICategoryService, CategoryService>(interceptor, behaver);

            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}                                                                                                                                                          