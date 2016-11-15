using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ng2Net.WebApi.Models
{
    public class ProposalModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int InstitutionId { get; set; }
        public InstitutionModel Institution { get; set; }
        public int InitiatingInstitutionId { get; set; }
        public InstitutionModel InitiatingInstitution { get; set; }
        public string Description { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime? LimitDate { get; set; }

        public string Link { get; set; }
        public string Email { get; set; }

        public string Observations { get; set; }

    }
}