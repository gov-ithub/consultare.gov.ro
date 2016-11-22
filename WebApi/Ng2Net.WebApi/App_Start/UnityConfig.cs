using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.InterceptionExtension;
using Ng2Net.Data;
using Ng2Net.Infrastructure.Data;
using Ng2Net.Infrastructure.Interfaces;
using Ng2Net.Infrastructure.Logging;
using Ng2Net.Model.Admin;
using Ng2Net.Model.Business;
using Ng2Net.Model.Scheduler;
using Ng2Net.Model.Security;
using Ng2Net.Services.Admin;
using Ng2Net.Services.Business;
using Ng2Net.Services.Scheduler;
using Ng2Net.Services.Security;
using System.Web.Http;

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

            container.RegisterInstance<IdentityDbContext<ApplicationUser>>(new DatabaseContext());
            container.RegisterInstance<IRepository<ProposalCategory>>(new EfRepository<ProposalCategory>());
            container.RegisterInstance<IRepository<Proposal>>(new EfRepository<Proposal>());
            container.RegisterInstance<IRepository<Institution>>(new EfRepository<Institution>());
            container.RegisterInstance<IRepository<Notification>>(new EfRepository<Notification>());
            container.RegisterInstance<IRepository<HtmlContent>>(new EfRepository<HtmlContent>());
            container.RegisterType<IApplicationAccountService, ApplicationAccountService>(interceptor, behaver);
            container.RegisterType<IHtmlContentService, HtmlContentService>(interceptor, behaver);
            container.RegisterType<ICategoryService, CategoryService>(interceptor, behaver);
            container.RegisterType<INotificationService, NotificationService>(interceptor, behaver);
            container.RegisterType<IProposalService, ProposalService>(interceptor, behaver);
            container.RegisterType<IInstitutionService, InstitutionService>(interceptor, behaver);
            container.RegisterType<ApiController, ApiController>(interceptor, behaver);

            return container;
        }
    }
}                                                                                                                                                          