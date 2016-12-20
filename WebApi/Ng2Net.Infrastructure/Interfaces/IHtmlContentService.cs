using Ng2Net.Model.Admin;
using System.Linq;

namespace Ng2Net.Infrastructure.Interfaces
{
    public interface IHtmlContentService
    {
        IQueryable<HtmlContent> GetHtmlContents(string filterQuery = null, int start = 0, int count = 0);
        HtmlContent GetHtmlContent(string id);
        HtmlContent SaveHtmlContent(HtmlContent content);
        void DeleteHtmlContent(string id);
        HtmlContent GetByUrl(string url);
        bool QuickSaveHtmlContent(string name, string content);
        HtmlContent GetByName(string name);
    }
}
