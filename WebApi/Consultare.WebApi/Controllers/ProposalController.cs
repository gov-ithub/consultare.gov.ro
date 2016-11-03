using Consultare.Database;
using Consultare.Database.DatabaseEntities;
using Consultare.WebApi.Base;
using Consultare.WebApi.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using AutoMapper;

namespace Consultare.WebApi.Controllers
{
    [RoutePrefix("api/proposal")]
    public class ProposalController : WebController
    {
        /// <summary>
        /// Find a proposal in the database
        /// </summary>
        /// <param name="searchString">text search string (leave empty to get all)</param>
        /// <param name="type">"Past" or "Current"</param>
        /// <returns></returns>
        [HttpGet]
        [Route("find")]
        public List<ProposalModel> FindProposal(string searchString="", string type="")
        {
            List<Proposal> lstProposals = this.context.Proposals.ToList();
            Mapper.Initialize(cfg => {
                cfg.CreateMap<Proposal, ProposalModel>();
                cfg.CreateMap<Institution, InstitutionModel>();
            });
            return Mapper.Map<List<Proposal>, List<ProposalModel>>(lstProposals);

        }
    }
}