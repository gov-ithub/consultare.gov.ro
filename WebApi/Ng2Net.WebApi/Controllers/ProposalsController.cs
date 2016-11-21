using Ng2Net.Infrastructure.Interfaces;
using Ng2Net.Model.Business;
using Ng2Net.WebApi.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Ng2Net.WebApi.Controllers
{
    [RoutePrefix("api/proposals")]
    public class ProposalsController : BaseController
    {
        private IProposalService proposalService;

        public ProposalsController(IProposalService proposalService)
        {
            this.proposalService = proposalService;
        }

        public Proposal Add(Proposal entity)
        {
            return proposalService.Add(entity);
        }

        public void Delete(Proposal entity)
        {
            proposalService.Delete(entity);
        }

        public Proposal Edit(Proposal entity)
        {
            return proposalService.Edit(entity);
        }

        public virtual IEnumerable<Proposal> Get()
        {
            return proposalService.Get();
        }
    }
}
