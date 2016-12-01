using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.InterceptionExtension;
using Ng2Net.Data;
using Ng2Net.Infrastructure.Data;
using Ng2Net.Infrastructure.Logging;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ng2Net.TaskRunner.Config
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

            container.RegisterType(typeof(IRepository<>), typeof(EfRepository<>));

            return container;
        }
    }
}
