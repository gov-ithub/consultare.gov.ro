using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.InterceptionExtension;
using Ng2Net.Data;
using Ng2Net.Infrastructure.Interfaces;
using Ng2Net.Infrastructure.Logging;
using Ng2Net.Infrastructure.Services;
using Ng2Net.Model.Admin;
using Ng2Net.Model.Business;
using Ng2Net.Model.Scheduler;
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

            container
                .RegisterType<IApplicationAccountService, ApplicationAccountService>(new Interceptor<InterfaceInterceptor>(), new InterceptionBehavior<LoggingInterceptionBehavior>())
                .RegisterType<IHtmlContentService, HtmlContentService>(new Interceptor<InterfaceInterceptor>(), new InterceptionBehavior<LoggingInterceptionBehavior>(), new InjectionFactory(c => ServiceFactory.Create<IHtmlContentService, EfRepository<HtmlContent>>()))
                .RegisterType<INotificationService, NotificationService>(new Interceptor<InterfaceInterceptor>(), new InterceptionBehavior<LoggingInterceptionBehavior>(), new InjectionFactory(c => ServiceFactory.Create<INotificationService, EfRepository<Notification>>()))
                .RegisterType<IProposalService, ProposalService>(new Interceptor<InterfaceInterceptor>(), new InterceptionBehavior<LoggingInterceptionBehavior>(), new InjectionFactory(c => ServiceFactory.Create<IProposalService, EfRepository<Proposal>>()))
                .RegisterType<IInstitutionService, InstitutionService>(new Interceptor<InterfaceInterceptor>(), new InterceptionBehavior<LoggingInterceptionBehavior>(), new InjectionFactory(c => ServiceFactory.Create<IInstitutionService, EfRepository<Institution>>()))
                .RegisterType<ICategoryService, CategoryService>(new Interceptor<InterfaceInterceptor>(), new InterceptionBehavior<LoggingInterceptionBehavior>(), new InjectionFactory(c => ServiceFactory.Create<ICategoryService, EfRepository<ProposalCategory>>()));

            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}                                                                                                                                                          