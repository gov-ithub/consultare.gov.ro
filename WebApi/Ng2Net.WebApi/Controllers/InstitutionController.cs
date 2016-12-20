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
    [RoutePrefix("api/institutions")]
    public class InstitutionController : BaseController
    {
        private IInstitutionService instService;

        public InstitutionController(IInstitutionService instService)
        {
            this.instService = instService;
        }

        [HttpDelete]
        [Route("{id}/{destinationInstitutionId}")]
        public object Delete(string id, string destinationInstitutionId = null)
        {
            var inst = instService.GetById(id);
            if (!string.IsNullOrEmpty(destinationInstitutionId))
            {
                var destInstitution = instService.GetById(destinationInstitutionId);
                inst.Proposals.ToList().ForEach(i => i.Institution = destInstitution);
            }
            instService.Delete(inst);
            instService.Save();
            return new { };
        }

        [HttpPost]
        [Route("save")]
        public InstitutionDTO Save(InstitutionDTO entityDTO)
        {
            var mapper = new MapperConfiguration(cfg => { cfg.CreateMap<InstitutionDTO, Institution>(); }).CreateMapper();

            Institution result = string.IsNullOrEmpty(entityDTO.Id) ? new Institution() : instService.GetById(entityDTO.Id);
            mapper.Map<InstitutionDTO, Institution>(entityDTO, result);
            if (string.IsNullOrEmpty(entityDTO.Id))
            {
                result.Id = Guid.NewGuid().ToString();
                instService.Add(result);
            }
            instService.Save();
            mapper = new MapperConfiguration(cfg => { cfg.CreateMap<Institution, InstitutionDTO>(); }).CreateMapper();
            return mapper.Map<InstitutionDTO>(result);
        }

        [HttpGet]
        [Route("get")]
        public virtual InstitutionDTO Get(string id)
        {
            var mapper = new MapperConfiguration(cfg => { cfg.CreateMap<Institution, InstitutionDTO>(); }).CreateMapper();
            return mapper.Map<InstitutionDTO>(instService.GetById(id));
        }

        [HttpGet]
        [Route("get")]
        public virtual IEnumerable<InstitutionDTO> Get()
        {
            var mapper = new MapperConfiguration(cfg => { cfg.CreateMap<Institution, InstitutionDTO>(); }).CreateMapper();
            return mapper.Map<IEnumerable<InstitutionDTO>>(instService.Get()).OrderBy(p=>p.Name);
        }

        [HttpGet]
        [Route("find")]
        public virtual IEnumerable<InstitutionDTO> Find([FromUri]string pageNo, [FromUri]string pageSize, [FromUri]string filterQuery = null)
        {
            var mapper = new MapperConfiguration(cfg => { cfg.CreateMap<Institution, InstitutionDTO>(); }).CreateMapper();

            var pagNoInt = Int32.Parse(pageNo);
            var pagSizeInt = Int32.Parse(pageSize);
            return mapper.Map<IEnumerable<InstitutionDTO>>(instService.Filter(filterQuery, pagNoInt, pagSizeInt));

        }
    }
}
