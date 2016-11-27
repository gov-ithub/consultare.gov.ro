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

        [HttpPost]
        public Proposal Add(Proposal entity)
        {
            return proposalService.Add(entity);
        }

        [HttpPost]
        public void Delete(Proposal entity)
        {
            proposalService.Delete(entity);
        }

        [HttpPost]
        public Proposal Edit(Proposal entity)
        {
            return proposalService.Edit(entity);
        }

        [HttpGet]
        [Route("get")]
        public virtual IEnumerable<Proposal> Get()
        {
            return proposalService.Get();
        }

        [HttpGet]
        [Route("list")]
        public IEnumerable<Proposal> List(string filterQuery = "", int page = 0, int pageSize = 0)
        {
            return new List<Proposal>();
        }
    }
}
