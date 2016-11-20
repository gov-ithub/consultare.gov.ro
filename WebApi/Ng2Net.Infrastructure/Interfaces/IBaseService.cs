using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ng2Net.Infrastructure.Interfaces
{
    public interface IBaseService<T>
    {
        IEnumerable<T> Get();
        T Add(T entity);
        T Edit(T entity);
        void Delete(T entity);
    }
}
