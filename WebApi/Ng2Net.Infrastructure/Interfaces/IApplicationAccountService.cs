using Ng2Net.Infrastructure.Interfaces;
using Ng2Net.Model.Security;
using System.Collections.Generic;

namespace Ng2Net.Infrastructure.Interfaces
{
    public interface IApplicationAccountService
    {
        Dictionary<string, string> GetClaimsDictionaryByUser(ApplicationUser user);
        ApplicationUser GetById(string id);
        int Save();
        IApplicationUserService UserService { get; }
    }
}
