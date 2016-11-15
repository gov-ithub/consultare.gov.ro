using Ng2Net.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ng2Net.Core
{
    public class HtmlContentQueries
    {
        public static IQueryable<HtmlContent> GetHtmlContents(DatabaseContext context, string filterQuery = null, int start=0, int count=0)
        {
            var result = context.HtmlContents.Where(c => string.IsNullOrEmpty(filterQuery) || c.Name.Contains(filterQuery) || c.Content.Contains(filterQuery)).OrderBy(c=>c.Name);
            if (count > 0)
                result = result.Skip(start - 1).Take(count).OrderBy(x => true);
            return result;
        }

        public static HtmlContent GetHtmlContent(DatabaseContext context, string id)
        {
            return context.HtmlContents.FirstOrDefault(c => c.Id == id);
        }

        public static HtmlContent SaveHtmlContent(HtmlContent content, DatabaseContext context)
        {
            if (context.Entry(content).State == System.Data.Entity.EntityState.Detached)
                context.HtmlContents.Add(content);
            context.SaveChanges();
            return content;
        }

        public static void DeleteHtmlContent(DatabaseContext context, string id)
        {
            context.HtmlContents.Remove(GetHtmlContent(context, id));
            context.SaveChanges();
        }
    }
}
