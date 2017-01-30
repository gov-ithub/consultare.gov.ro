using Newtonsoft.Json;
using Ng2Net.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace UserImport
{
    class Program
    {
        static void Main(string[] args)
        {
            DataTable dt = Utils.ExcelToDataTable(System.IO.Path.GetDirectoryName(Assembly.GetEntryAssembly().Location)
            + "\\users.xlsx");
            foreach (DataRow dr in dt.Rows)
            {
                HttpWebRequest req = (HttpWebRequest)WebRequest.Create("http://api.consultare.gov.start/api/");
                req.Method = "POST";
                string fName = dr[1].ToString().Substring(0, dr[1].ToString().LastIndexOf(" "));
                string lName = dr[1].ToString().Substring(dr[1].ToString().LastIndexOf(" "), dr[1].ToString().Length - dr[1].ToString().LastIndexOf(" "));
                var requestObj = new { email=dr[2], firstName=fName, lastName = lName, password = Guid.NewGuid().ToString(), subscriptionType = "ALL", subscriptions = new string[0] };
                Console.WriteLine(JsonConvert.SerializeObject(requestObj));
            }
            Console.ReadLine();
        }
    }
}
