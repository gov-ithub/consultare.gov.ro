using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.IO;
using System.Configuration;
using System.Reflection;

namespace Ng2Net.Infrastrucure.Logging
{
    public class Logging
    {
        public Logging()
        {
            if (logWriters == null)
                logWriters = new Dictionary<string, StreamWriter>();
        }

        
        private static Dictionary<string, StreamWriter> logWriters { get; set; }

        public string LogFileName { get; set; }

        public string Reference { get; set; }

        public void LogMessage(string message)
        {
            if (string.IsNullOrEmpty(this.Reference))
                this.Reference = Guid.NewGuid().ToString();
            LogMessage(message, this.Reference);
        }
        public void LogMessageLine(string message)
        {
            LogMessage(message + "\r\n");
        }
        private StreamWriter GetStreamWriter()
        {
            FileInfo fiCurrentAssembly = new FileInfo(HttpContext.Current == null ? Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + ConfigurationManager.AppSettings["LogPath"] : HttpContext.Current.Server.MapPath(ConfigurationManager.AppSettings["LogPath"]));
            if (string.IsNullOrEmpty(this.LogFileName))
                this.LogFileName = Path.GetDirectoryName(fiCurrentAssembly.FullName) + "\\logs-" + DateTime.Now.ToString("yyyyMMdd") + ".txt";

            if (logWriters.ContainsKey(this.LogFileName))
                return logWriters[this.LogFileName];

            FileInfo fiLogFile = new FileInfo(this.LogFileName);
            if (!Directory.Exists(Path.GetDirectoryName(fiCurrentAssembly.FullName)))
                Directory.CreateDirectory(Path.GetDirectoryName(fiCurrentAssembly.FullName));
            StreamWriter logWriter = fiLogFile.Exists ? fiLogFile.AppendText() : fiLogFile.CreateText();
            logWriters.Add(fiLogFile.FullName, logWriter);
            return logWriter;
        }

        public void LogMessage(string message, string reference)
        {
            StreamWriter sw = GetStreamWriter();
            foreach (string line in message.Split("\n".ToCharArray(), StringSplitOptions.RemoveEmptyEntries))
                sw.Write(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + " | " + reference + " | " + line);
            sw.Flush();
        }

        public string LogException(Exception ex)
        {
            return LogException(ex, null);
        }

        public string LogException(Exception ex, HttpContext ctx)
        {
            string shortMessage = ex.Message;
            string reference = Guid.NewGuid().ToString();
            Exception exc = ex;
            while (exc.InnerException != null)
            {
                exc = exc.InnerException;
                shortMessage += " : " + exc.Message;
            }

            string message = "===================================================\r\n" + shortMessage + "\r\n===================================================\r\n" + exc.StackTrace;
            if (ctx != null)
            {
                message += "\r\n===================================================\r\n";
                foreach (string s in ctx.Request.ServerVariables)
                {
                    if (!s.Contains("VIEWSTATE"))
                        message += s + ": " + ctx.Request.ServerVariables[s] + "\r\n";  
                }
            }
            LogMessage(message, reference);
            LogMessage("\r\n\r\n", reference);
            return reference;
        }
    }
}
