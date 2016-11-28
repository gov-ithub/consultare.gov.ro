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

        [HttpPost]
        [Route("add")]
        public Institution Add(InstitutionDTO entity)
        {
            Mapper.Initialize(cfg => { cfg.CreateMap<InstitutionDTO, Institution>(); });
            return instService.Add(Mapper.Map<Institution>(entity));
        }

        [HttpPost]
        public void Delete(InstitutionDTO entity)
        {
            instService.Delete(instService.GetById(entity.Id));
        }

        [HttpPost]
        public Institution Edit(InstitutionDTO entity)
        {
            instService.GetById(entity.Id);
            Mapper.Initialize(cfg => { cfg.CreateMap<InstitutionDTO, Institution>(); });
            var result = Mapper.Map<Institution>(entity);
            if (string.IsNullOrEmpty(result.Id))
                result.Id = Guid.NewGuid().ToString();
            return instService.Edit(result);
        }

        [HttpGet]
        [Route("get")]
        public virtual IEnumerable<InstitutionDTO> Get()
        {
            Mapper.Initialize(cfg => { cfg.CreateMap<Institution, InstitutionDTO>(); });
            return Mapper.Map<IEnumerable<InstitutionDTO>>(instService.Get());
        }
    }
}
