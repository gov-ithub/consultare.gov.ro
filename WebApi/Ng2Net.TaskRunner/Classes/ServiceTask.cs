using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Ng2Web.TaskRunner.Classes
{
    public class ServiceTask
    {
        [XmlAttribute]
        public string Name { get; set; }
        [XmlAttribute]
        public string ExecuteAssembly { get; set; }
        [XmlAttribute]
        public string ExecuteModule { get; set; }
        [XmlAttribute]
        public int Frequency { get; set; }
        [XmlAttribute]
        public string CurrentChannel { get; set; }
        [XmlText]
        public string Settings { get; set; }

        public dynamic SettingsObject
        {
            get {
                return JsonConvert.DeserializeObject(this.Settings);
            }
        }

        public static List<ServiceTask> GetTasks()
        {
            List<ServiceTask> tasks = new List<ServiceTask>();
            //tasks.Add(new ServiceTask { CurrentChannel = "x1", ExecuteAssembly = "2", ExecuteModule = "3", Frequency = 4, Name = "5" });
            XmlSerializer serializer2 = new XmlSerializer(typeof(List<ServiceTask>));
            var stringwriter = new System.IO.StringWriter();
            serializer2.Serialize(stringwriter, tasks);
            string s = stringwriter.ToString();

            using (StringReader sr = new StringReader(File.ReadAllText(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\Config\\Tasks.config")))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(List<ServiceTask>));
                tasks = (List<ServiceTask>)serializer.Deserialize(sr);
            }
            return tasks;
        }
    }
}
