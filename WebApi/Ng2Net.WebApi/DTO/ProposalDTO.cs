using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ng2Net.WebApi.DTO
{
    public class ProposalDTO
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string InstitutionId { get; set; }
        public virtual InstitutionDTO Institution { get; set; }
        public string InitiatingInstitutionId { get; set; }
        public virtual InstitutionDTO InitiatingInstitution { get; set; }
        public string Description { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public DateTime? LimitDate { get; set; }

        public string Link { get; set; }
        public string Email { get; set; }

        public string Observations { get; set; }
        public virtual List<ProposalDocumentDTO> ProposalDocuments { get; set; }

    }
}