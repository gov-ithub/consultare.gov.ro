using System;
using System.Collections;
using System.Collections.Generic;

namespace Ng2Net.Model.Business
{
    public class Proposal : BaseEntity
    {        
        public string Title { get; set; }
        public int InstitutionId { get; set; }
        public Institution Institution { get; set; }
        public int InitiatingInstitutionId { get; set; }
        public Institution InitiatingInstitution { get; set; }
        public string Description { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime? LimitDate { get; set; }

        public string Link { get; set; }
        public string Email { get; set; }

        public string Observations { get; set; }
        public IList<ProposalCategory> ProposalCategories { get; set; }
    }
}