using Ng2Net.Infrastructure.Interfaces;
using Ng2Net.Model.Business;
using Ng2Net.Infrastructure.Data;

namespace Ng2Net.Services.Business
{
    public class ProposalService : BaseService<Proposal>, IProposalService
    {
        public ProposalService(IRepository<Proposal> repository) : base(repository)
        {
        }


    }
}
