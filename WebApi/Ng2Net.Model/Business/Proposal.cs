using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ng2Net.Model.Business
{
    public class Proposal : BaseEntity
    {
        [Required]
        [Column(TypeName="nvarchar(max)")]
        public string Title { get; set; }
        public string InstitutionId { get; set; }
        public virtual Institution Institution { get; set; }
        public string Description { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public DateTime? LimitDate { get; set; }
        [StringLength(1000)]
        public string Link { get; set; }
        [StringLength(1000)]
        public string Email { get; set; }
        public string Documents { get; set; }
        public string Observations { get; set; }
        public bool Archived { get; set; }
        public virtual List<ProposalDocument> ProposalDocuments { get; set; }
    }
}