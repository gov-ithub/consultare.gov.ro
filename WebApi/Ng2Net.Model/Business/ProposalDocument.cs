using Ng2Net.Model.Security;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ng2Net.Model.Business
{
    public class ProposalDocument : BaseEntity
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public string Url { get; set; }
        [ForeignKey("ProposalId")]
        public virtual Proposal Proposal { get; set; }
        public string ProposalId { get; set; }
    }
}