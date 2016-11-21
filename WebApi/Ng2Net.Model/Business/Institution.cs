using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Ng2Net.Model.Business
{
    public class Institution : BaseEntity
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public string Url { get; set; }
        public IList<Proposal> Proposals { get; set; }
    }
}