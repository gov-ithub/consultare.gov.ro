using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ng2Net.WebApi.DTO
{
    public class ProposalDocumentDTO
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Url { get; set; }
        public string ProposalId { get; set; }
    }
}