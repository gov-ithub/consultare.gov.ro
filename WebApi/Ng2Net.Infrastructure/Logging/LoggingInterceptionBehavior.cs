using log4net;
using Microsoft.Practices.Unity.InterceptionExtension;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ng2Net.Infrastructure.Logging
{
    public class LoggingInterceptionBehavior : IInterceptionBehavior
    {
        private static readonly ILog logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public IEnumerable<Type> GetRequiredInterfaces()
        {
            return Type.EmptyTypes;
        }
        public bool WillExecute
        {
            get { return true; }
        }
        public IMethodReturn Invoke(IMethodInvocation input, GetNextInterceptionBehaviorDelegate getNext)
        {
            logger.Info(string.Format("Before Invoking {0}", input.MethodBase.Name));
            var result = getNext()(input, getNext);
            if (result.Exception != null)
            {
                logger.Error(string.Format("After Invoking Exception {0}", input.MethodBase.Name), result.Exception);
            }
            else
            {
                logger.Info(string.Format("After Invoking {0}", input.MethodBase.Name));
            }
            return result;
        }
    }
}
