﻿using AutoMapper;
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
            Mapper.Initialize(cfg => { cfg.CreateMap<HtmlContent, HtmlContentDTO>(); });
            return Mapper.Map<List<HtmlContentDTO>>(_service.GetHtmlContents(filterQuery, page * pageSize, pageSize));
        }

        [HttpGet]
        [Route("get")]
        public Dictionary<string, string> Get()
        {
            return _service.GetHtmlContents().ToDictionary(x => x.Name, y => y.Content);
        }

        [Authentication(Claims = new string[] { "EditHtmlContent" })]
        [HttpGet]
        [Route("get/{id}")]
        public HtmlContentDTO Get(string id)
        {
            Mapper.Initialize(cfg => { cfg.CreateMap<HtmlContent, HtmlContentDTO>(); });

            return Mapper.Map<HtmlContentDTO>(_service.GetHtmlContent(id));
        }


        [Authentication(Claims = new string[] { "EditHtmlContent" })]
        [HttpPost]
        [Route("save")]
        public HtmlContentDTO Get([FromBody] HtmlContentDTO model)
        {
            HtmlContent content = string.IsNullOrEmpty(model.Id) ? new HtmlContent() : _service.GetHtmlContent(model.Id);
            Mapper.Initialize(cfg => { cfg.CreateMap<HtmlContentDTO, HtmlContent>(); });
            Mapper.Map(model, content);
            content.Id = string.IsNullOrEmpty(content.Id) ? Guid.NewGuid().ToString() : content.Id;
            _service.SaveHtmlContent(content);
            Mapper.Initialize(cfg => { cfg.CreateMap<HtmlContent, HtmlContentDTO>(); });
            return Mapper.Map<HtmlContentDTO>(content);
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