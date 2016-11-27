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
    [RoutePrefix("api/categories")]
    public class CategoryController : BaseController
    {
        private ICategoryService categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            this.categoryService = categoryService;
        }
        [HttpPost]
        public ProposalCategory Add(ProposalCategory entity)
        {
            return categoryService.Add(entity);
        }
        [HttpPost]
        public void Delete(ProposalCategory entity)
        {
            categoryService.Delete(entity);
        }
        [HttpPost]
        public ProposalCategory Edit(ProposalCategory entity)
        {
            return categoryService.Edit(entity);
        }
        [HttpGet]
        [Route("get")]
        public virtual IEnumerable<ProposalCategory> Get()
        {
            return categoryService.Get();
        }
    }
}
