using AutoMapper;
using Ng2Net.Data;
using Ng2Net.Infrastructure.Interfaces;
using Ng2Net.Infrastructure.Services;
using Ng2Net.Model.Admin;
using Ng2Net.Services.Admin;
using Ng2Net.WebApi.Base;
using Ng2Net.WebApi.DTO;
using Ng2Web.WebApi.CustomAttributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace Ng2Net.WebApi.Controllers
{
    [RoutePrefix("api/content")]
    public class HtmlContentController : BaseController
    {
        private IHtmlContentService _service;

        //refactor to di
        public HtmlContentController(IHtmlContentService service)
        {
            _service = service;
        }

        [Authentication(Claims = new string[] { "EditHtmlContent" })]
        [HttpGet]
        [Route("list")]
        public List<HtmlContentDTO> List(string filterQuery = "", int page = 0, int pageSize = 0)
        {
            var mapper = new MapperConfiguration(cfg => { cfg.CreateMap<HtmlContent, HtmlContentDTO>(); }).CreateMapper();
            return mapper.Map<List<HtmlContentDTO>>(_service.GetHtmlContents(filterQuery, page * pageSize, pageSize).ToList());
        }

        [HttpGet]
        [Route("get")]
        public Dictionary<string, string> Get()
        {
            return _service.GetHtmlContents().ToDictionary(x => x.Name, y => y.Content);
        }

        [HttpGet]
        [Route("getbyurl/{url}")]
        public HtmlContentDTO GetByUrl(string url)
        {
            var mapper = new MapperConfiguration(cfg => { cfg.CreateMap<HtmlContent, HtmlContentDTO>(); }).CreateMapper();

            return mapper.Map<HtmlContentDTO>(_service.GetByUrl(url));
        }

        [Authentication(Claims = new string[] { "EditHtmlContent" })]
        [HttpGet]
        [Route("get/{id}")]
        public HtmlContentDTO Get(string id)
        {
            var mapper = new MapperConfiguration(cfg => { cfg.CreateMap<HtmlContent, HtmlContentDTO>(); }).CreateMapper();

            return mapper.Map<HtmlContentDTO>(_service.GetHtmlContent(id));
        }


        [Authentication(Claims = new string[] { "EditHtmlContent" })]
        [HttpPost]
        [Route("save")]
        public HtmlContentDTO Save([FromBody] HtmlContentDTO model)
        {
            HtmlContent content = string.IsNullOrEmpty(model.Id) ? new HtmlContent() : _service.GetHtmlContent(model.Id);
            var mapper = new MapperConfiguration(cfg => { cfg.CreateMap<HtmlContentDTO, HtmlContent>(); }).CreateMapper();
            mapper.Map(model, content);
            content.Id = string.IsNullOrEmpty(content.Id) ? Guid.NewGuid().ToString() : content.Id;
            _service.SaveHtmlContent(content);
            mapper = new MapperConfiguration(cfg => { cfg.CreateMap<HtmlContent, HtmlContentDTO>(); }).CreateMapper();
            return mapper.Map<HtmlContentDTO>(content);
        }

        [Authentication(Claims = new string[] { "EditHtmlContent" })]
        [HttpPost]
        [Route("quicksave")]
        public bool QuickSave([FromBody] HtmlContentDTO model)
        {
            _service.QuickSaveHtmlContent(model.Name, model.Content);
            return true;
        }


        [Authentication(Claims = new string[] { "EditHtmlContent" })]
        [HttpDelete]
        [Route("{id}")]
        public object Delete(string id)
        {
            _service.DeleteHtmlContent(id);
            return null;
        }
    }
}