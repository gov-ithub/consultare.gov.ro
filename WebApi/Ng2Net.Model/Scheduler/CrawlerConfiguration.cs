using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ng2Net.Model.Scheduler
{
    public class CrawlerConfiguration : BaseEntity
    {
        public string InstitutionId { get; set; }
        public string Url { get; set; }
        public string XsltConfig { get; set; }
        public bool Active { get; set; }       
    }
}
