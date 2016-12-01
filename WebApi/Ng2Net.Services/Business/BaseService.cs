using Ng2Net.Infrastructure.Data;
using Ng2Net.Infrastructure.Interfaces;
using Ng2Net.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ng2Net.Services.Business
{
    public class BaseService<T> : IBaseService<T> where T : BaseEntity
    {
        private IRepository<T> _repository;

        public BaseService(IRepository<T> repository)
        {
            _repository = repository;
        }
        public virtual T Add(T entity)
        {
            _repository.Insert(entity);
            return _repository.GetById(entity.Id);
        }

        public virtual void Delete(T entity)
        {
            _repository.Delete(entity);
        }

        public virtual T Edit(T entity)
        {
            _repository.Update(entity);
            return _repository.GetById(entity.Id);
        }

        public virtual IEnumerable<T> Get()
        {
            return _repository.GetMany();
        }

        public virtual T GetById(string id)
        {
            return _repository.GetById(id);
        }
    }
}
