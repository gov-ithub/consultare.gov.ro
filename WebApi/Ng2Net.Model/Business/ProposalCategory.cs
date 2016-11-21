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
        [Required]
        [StringLength(255)]
        public string Name { get; set; }
        [Required]
        [StringLength(255)]
        public string Url { get; set; }
        public IList<Proposal> Proposals { get; set; }
    }
}
