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
        [Route("delete")]
        public void Delete(string id)
        {
            instService.Delete(instService.GetById(id));
        }

        [HttpPost]
        [Route("save")]
        public Institution Save(Institution entity)
        {
            instService.GetById(entity.Id);
            var mapper = new MapperConfiguration(cfg => { cfg.CreateMap<InstitutionDTO, Institution>(); }).CreateMapper();
            var result = mapper.Map<Institution>(entity);
            if (string.IsNullOrEmpty(result.Id))
            {
                result.Id = Guid.NewGuid().ToString();
                return instService.Add(result);
            }
            else
            {
                return instService.Edit(result);
            }
        }

        [HttpGet]
        [Route("get")]
        public virtual InstitutionDTO Get(string id)
        {
            var mapper = new MapperConfiguration(cfg => { cfg.CreateMap<Institution, InstitutionDTO>(); }).CreateMapper();
            return mapper.Map<InstitutionDTO>(instService.GetById(id));
        }

        [HttpGet]
        [Route("find")]
        public virtual IEnumerable<InstitutionDTO> Find([FromUri]string pageNo, [FromUri]string pageSize, [FromUri]string filterQuery = null)
        {
            var mapper = new MapperConfiguration(cfg => { cfg.CreateMap<Institution, InstitutionDTO>(); }).CreateMapper();
<<<<<<< HEAD
            var pagNoInt = Int32.Parse(pageNo);
            var pagSizeInt = Int32.Parse(pageSize);
            return mapper.Map<IEnumerable<InstitutionDTO>>(instService.Filter(filterQuery, pagNoInt, pagSizeInt));
=======
            return mapper.Map<IEnumerable<InstitutionDTO>>(instService.Get().OrderBy(i=>i.Name));
>>>>>>> 103647bb2df94bc1192a26de3db7ac45a7e67b30
        }
    }
}
