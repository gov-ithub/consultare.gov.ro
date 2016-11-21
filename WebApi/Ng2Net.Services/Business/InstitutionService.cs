using Ng2Net.Infrastructure.Interfaces;
using Ng2Net.Model.Business;
using Ng2Net.Infrastructure.Data;

namespace Ng2Net.Services.Business
{
    public class InstitutionService : BaseService<Institution>, IInstitutionService
    {
        public InstitutionService(IRepository<Institution> repository) : base(repository)
        {
        }
    }
}
