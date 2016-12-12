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
        private IInstitutionService institutionService;

        public ProposalsController(IProposalService proposalService, IInstitutionService institutionService)
        {
            this.proposalService = proposalService;
            this.institutionService = institutionService;
        }

        [HttpPost]
        public Proposal Add(Proposal entity)
        {
            return proposalService.Add(entity);
        }

        [HttpDelete]
        [Route("{id}")]
        public void Delete(string id)
        {
            var proposal = proposalService.GetById(id);
            proposalService.Delete(proposal);
            proposalService.Save();
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
        [Route("get/{id}")]
        public virtual ProposalDTO GetById(string id)
        {
            var mapper = new MapperConfiguration(cfg => {
                cfg.CreateMap<Proposal, ProposalDTO>();
                cfg.CreateMap<Institution, InstitutionDTO>();
            }).CreateMapper();

            return mapper.Map<ProposalDTO>(proposalService.GetById(id));
        }

        [HttpGet]
        [Route("find")]
        public virtual PagedResultsDTO<ProposalDTO> Find(string filterQuery = "", string institutionId = "", bool futureOnly = false, string sortField= "limitDate", string sortDirection="desc", int pageNo = 0, int pageSize = 0)
        {
            if (pageSize <= 0)
                return null;

            var mapper = new MapperConfiguration(cfg => {
                cfg.CreateMap<PagedResultsDTO<Proposal>, PagedResultsDTO<ProposalDTO>>();
                cfg.CreateMap<Proposal, ProposalDTO>();
                cfg.CreateMap<Institution, InstitutionDTO>();
            }).CreateMapper();

            var query = proposalService.Get().Where(p => p.Title.ToLower().Contains(filterQuery) && (string.IsNullOrEmpty(institutionId) || p.InstitutionId == institutionId) && (!futureOnly || p.LimitDate>DateTime.Now));

            switch (sortField)
            {
                case "startDate":
                    query = sortDirection == "asc" ? query.OrderBy(p => p.StartDate) : query.OrderByDescending(p => p.StartDate);
                    break;
                case "limitDate":
                    query = sortDirection == "desc" ? query.OrderBy(p => p.LimitDate) : query.OrderByDescending(p => p.LimitDate);
                    break;
            }

            var result = PagedResultsDTO<Proposal>.GetPagedResultsDTO(query, pageNo, pageSize);
            return mapper.Map<PagedResultsDTO<ProposalDTO>>(result);
        }

        [HttpPost]
        [Route("save")]
        public virtual ProposalDTO Save([FromBody]ProposalDTO model)
        {
            Proposal proposal = string.IsNullOrEmpty(model.Id) ? new Proposal() : proposalService.GetById(model.Id);
            var mapper = new MapperConfiguration(cfg => { cfg.CreateMap<ProposalDTO, Proposal>();
                cfg.CreateMap<InstitutionDTO, Institution>();
            }).CreateMapper();
            mapper.Map(model, proposal);
            proposal.Institution = this.institutionService.GetById(proposal.Institution.Id);

            if (string.IsNullOrEmpty(proposal.Id))
            {
                proposal.Id = string.IsNullOrEmpty(proposal.Id) ? Guid.NewGuid().ToString() : proposal.Id;
                proposalService.Add(proposal);
            }

            proposalService.Save();
            mapper = new MapperConfiguration(cfg => { cfg.CreateMap<Proposal, ProposalDTO>();
                cfg.CreateMap<Institution, InstitutionDTO>();
            }).CreateMapper();
            return mapper.Map<ProposalDTO>(proposal);

        }
    }
}
