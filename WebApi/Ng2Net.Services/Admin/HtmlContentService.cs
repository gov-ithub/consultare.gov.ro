using Ng2Net.Infrastructure.Data;
using Ng2Net.Infrastructure.Interfaces;
using Ng2Net.Model.Admin;
using System.Linq;

namespace Ng2Net.Services.Admin
{
    public class HtmlContentService : IHtmlContentService
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

        public HtmlContent GetByName(string name)
        {
            return _repository.Get(c => c.Name == name);
        }

        public bool QuickSaveHtmlContent(string name, string content)
        {
            HtmlContent contentPart = _repository.Get(c => c.Name == name);
            if (contentPart == null) {
                contentPart = new HtmlContent() { Name = name, Content = content };
                _repository.Insert(contentPart);
            }
            contentPart.Content = content;
            _repository.Save();
            return true;
        }

        public HtmlContent GetByUrl(string url)
        {
            return _repository.GetMany().FirstOrDefault(o=>o.Url == url);
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
