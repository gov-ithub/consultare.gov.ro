using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consultare.Database.DatabaseEntities
{
    public class Proposal
    {
        public int Id { get; set; }
        [StringLength(1000)]
        public string Title { get; set; }
        public int InstitutionId { get; set; }
        [ForeignKey("InstitutionId")]
        public Institution Institution { get; set; }
        public int MinisteryId { get; set; }
        [ForeignKey("MinisteryId")]
        public Ministery Ministery { get; set; }
        [StringLength(2000)]
        public string Description { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime? LimitDate { get; set; }

        [StringLength(1000)]
        public string Link { get; set; }
        [StringLength(255)]
        public string Email { get; set; }
    }
}
