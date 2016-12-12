using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ng2Net.Infrastructure.Interfaces
{
    public interface IBaseService<T>
    {
        IQueryable<T> Get();
        IEnumerable<T> Filter(string filterQuery, int pagNo, int pagSize);
        T Add(T entity);
        T Edit(T entity);
        void Delete(T entity);
        T GetById(string id);
        void Save();
    }
}
