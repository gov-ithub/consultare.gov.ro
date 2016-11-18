using Ng2Net.Infrastructure.Data;
using Ng2Net.Model.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ng2Net.Services.Admin
{
    public class HtmlContentService
    {
        private IRepository<HtmlContent> _repository;

        public HtmlContentService(IRepository<HtmlContent> repository)
        {
            _repository = repository;
        }

        public IQueryable<HtmlContent> GetHtmlContents(string filterQuery = null, int start = 0, int count = 0)
        {
            var result = _repository.GetMany(c => string.IsNullOrEmpty(filterQuery) || c.Name.Contains(filterQuery) || c.Content.Contains(filterQuery)).OrderBy(c => c.Name);
            if (count > 0)
                result = result.Skip(start - 1).Take(count).OrderBy(x => true);
            return result;
        }

        public HtmlContent GetHtmlContent(string id)
        {
            return _repository.GetById(id);
        }

        public HtmlContent SaveHtmlContent(HtmlContent content)
        {
            if (_repository.IsNew(content))
                _repository.Insert(content);
            else
                _repository.Update(content);

            _repository.Save();
            return content;
        }

        public void DeleteHtmlContent(string id)
        {
            _repository.Delete(this.GetHtmlContent(id));
            _repository.Save();
        }
    }
}
