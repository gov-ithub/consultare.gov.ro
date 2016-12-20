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
        protected IRepository<T> _repository;

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

        public virtual IQueryable<T> Get()
        {
            return _repository.GetMany();
        }

        public virtual IEnumerable<T> Filter(string filterQuery, int pagNo, int pagSize)
        {
            return _repository.GetMany();
        }

        public virtual T GetById(string id)
        {
            return _repository.GetById(id);
        }

        public virtual void Save()
        {
            _repository.Save();
        }
    }
}
