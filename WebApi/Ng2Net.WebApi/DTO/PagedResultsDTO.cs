using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ng2Net.WebApi.DTO
{
    public class PagedResultsDTO<T>
    {
        public IEnumerable<T> Results { get; set; }
        public int TotalResults { get; set; }

        public static PagedResultsDTO<T> GetPagedResultsDTO(IQueryable<T> query, int pageNo, int pageSize)
        {
            PagedResultsDTO<T> result = new PagedResultsDTO<T>();
            result.Results = query.Skip(pageNo * pageSize).Take(pageSize).ToList();
            result.TotalResults = query.Count();
            return result;
        }
    }
}