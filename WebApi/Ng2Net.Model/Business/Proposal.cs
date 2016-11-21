using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Ng2Net.Model.Business
{
    public class Proposal : BaseEntity
    {
        [Required]
        [StringLength(1000)]
        public string Title { get; set; }
        public string InstitutionId { get; set; }
        public Institution Institution { get; set; }
        public string InitiatingInstitutionId { get; set; }
        public Institution InitiatingInstitution { get; set; }
        public string Description { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime? LimitDate { get; set; }
        [Required]
        [StringLength(1000)]
        public string Link { get; set; }
        [Required]
        [StringLength(255)]
        public string Email { get; set; }

        public string Observations { get; set; }
        public IList<ProposalCategory> ProposalCategories { get; set; }
    }
}