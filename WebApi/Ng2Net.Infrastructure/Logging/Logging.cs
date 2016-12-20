using System;
using System.Web;
using System.Reflection;
using log4net;

namespace Ng2Net.Infrastrucure.Logging
{
    public class Logging
    {
        private static readonly ILog logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public static void LogMessage(string message)
        {
            logger.Info(message);
        }

        public static void LogException(Exception ex)
        {
            LogHttpException(ex, null);
        }

        public static void LogHttpException(Exception ex, HttpContext ctx)
        {
            var message = String.Empty;
            if (ctx != null)
            {
                foreach (string s in ctx.Request.ServerVariables)
                {
                    if (!s.Contains("VIEWSTATE"))
                        message += s + ": " + ctx.Request.ServerVariables[s] + "\r\n";  
                }
            }
            logger.Error(message, ex);
        }
    }
}
