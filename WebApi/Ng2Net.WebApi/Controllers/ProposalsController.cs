using AutoMapper;
using Ng2Net.Infrastructure.Interfaces;
using Ng2Net.Model.Business;
using Ng2Net.WebApi.Base;
using Ng2Net.WebApi.DTO;
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
        [Route("find")]
        public virtual PagedResultsDTO<ProposalDTO> Find(string filterQuery = "", int pageNo = 0, int pageSize = 0)
        {
            if (pageSize <= 0)
                return null;

            var mapper = new MapperConfiguration(cfg => {
                cfg.CreateMap<PagedResultsDTO<Proposal>, PagedResultsDTO<ProposalDTO>>();
                cfg.CreateMap<Proposal, ProposalDTO>();
                cfg.CreateMap<Institution, InstitutionDTO>();
            }).CreateMapper();

            var query = proposalService.Get().Where(p => p.Title.ToLower().Contains(filterQuery)).OrderByDescending(p => p.StartDate);
            var result = PagedResultsDTO<Proposal>.GetPagedResultsDTO(query, pageNo, pageSize);
            return mapper.Map<PagedResultsDTO<ProposalDTO>>(result);
        }
    }
}
