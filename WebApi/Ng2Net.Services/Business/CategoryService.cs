using Ng2Net.Infrastructure.Interfaces;
using Ng2Net.Model.Business;
using Ng2Net.Infrastructure.Data;

namespace Ng2Net.Services.Business
{
    public class CategoryService : BaseService<ProposalCategory>, ICategoryService
    {
        public CategoryService(IRepository<ProposalCategory> repository) : base(repository)
        {
        }
    }
}
