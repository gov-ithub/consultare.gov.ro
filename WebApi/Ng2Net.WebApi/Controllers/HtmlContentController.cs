using AutoMapper;
using Ng2Net.Core;
using Ng2Net.Database;
using Ng2Net.WebApi.Base;
using Ng2Net.WebApi.Models;
using Ng2Web.WebApi.CustomAttributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace Ng2Net.WebApi.Controllers
{
    [RoutePrefix("api/content")]
    public class HtmlContentController : WebController
    {
        
        [Authentication(Claims = new string[] {"EditHtmlContent"})]
        [HttpGet]
        [Route("list")]
        public List<HtmlContentModel> List(string filterQuery = "", int page = 0, int pageSize = 0)
        {
            Mapper.Initialize(cfg => { cfg.CreateMap<HtmlContent, HtmlContentModel>(); });
            return Mapper.Map<List<HtmlContentModel>>(HtmlContentQueries.GetHtmlContents(this.DbContext, filterQuery, page * pageSize, pageSize));
        }

        [HttpGet]
        [Route("get")]
        public Dictionary<string, string> Get()
        {
            return HtmlContentQueries.GetHtmlContents(this.DbContext).ToDictionary(x=>x.Name, y=>y.Content);
        }

        [Authentication(Claims = new string[] { "EditHtmlContent" })]
        [HttpGet]
        [Route("get/{id}")]
        public HtmlContentModel Get(string id)
        {
            Mapper.Initialize(cfg => { cfg.CreateMap<HtmlContent, HtmlContentModel>(); });

            return Mapper.Map<HtmlContentModel>(HtmlContentQueries.GetHtmlContent(DbContext, id));
        }


        [Authentication(Claims = new string[] { "EditHtmlContent" })]
        [HttpPost]
        [Route("save")]
        public HtmlContentModel Get([FromBody] HtmlContentModel model)
        {
            HtmlContent content = string.IsNullOrEmpty(model.Id) ? new HtmlContent() : HtmlContentQueries.GetHtmlContent(this.DbContext, model.Id);
            Mapper.Initialize(cfg => { cfg.CreateMap<HtmlContentModel, HtmlContent>(); });
            Mapper.Map(model, content);
            content.Id = string.IsNullOrEmpty(content.Id) ? Guid.NewGuid().ToString() : content.Id;
            HtmlContentQueries.SaveHtmlContent(content, this.DbContext);
            Mapper.Initialize(cfg => { cfg.CreateMap<HtmlContent, HtmlContentModel>(); });
            return Mapper.Map<HtmlContentModel>(content);
        }


        [Authentication(Claims = new string[] { "EditHtmlContent" })]
        [HttpDelete]
        [Route("{id}")]
        public object Delete(string id)
        {
            HtmlContentQueries.DeleteHtmlContent(this.DbContext, id);
            return null;
        }

    }
}