using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ng2Net.Model.Business
{
    public class ProposalCategory : BaseEntity
    {
        public string Name { get; set; }
        public string Url { get; set; }
    }
}
