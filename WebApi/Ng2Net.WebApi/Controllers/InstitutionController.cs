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
    [RoutePrefix("/api/institutions")]
    public class InstitutionController : BaseController
    {
        private IInstitutionService instService;

        public InstitutionController(IInstitutionService instService)
        {
            this.instService = instService;
        }

        public Institution Add(Institution entity)
        {
            return instService.Add(entity);
        }

        public void Delete(Institution entity)
        {
            instService.Delete(entity);
        }

        public Institution Edit(Institution entity)
        {
            return instService.Edit(entity);
        }

        public virtual IEnumerable<Institution> Get()
        {
            return instService.Get();
        }
    }
}
