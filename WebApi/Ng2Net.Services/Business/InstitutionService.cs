using Ng2Net.Infrastructure.Interfaces;
using Ng2Net.Model.Business;
using Ng2Net.Infrastructure.Data;
using System.Linq;
using System.Collections.Generic;

namespace Ng2Net.Services.Business
{
    public class InstitutionService : BaseService<Institution>, IInstitutionService
    {
        public InstitutionService(IRepository<Institution> repository) : base(repository)
        {
        }

        public override IEnumerable<Institution> Filter(string filterQuery, int pagNo, int pagSize)
        {
            List<Institution> list = null;
            if (string.IsNullOrEmpty(filterQuery))
                list = _repository.GetMany().OrderBy(i => i.Name).ToList();
            else
                list = _repository.GetMany(i => i.Name.StartsWith(filterQuery)).OrderBy(i=>i.Name).ToList();

            var count = pagSize;
            if (list.Count < (pagNo + 1) * pagSize)
                count = list.Count % pagSize;

            return list.GetRange(pagNo * pagSize, count);
        }
    }
}
