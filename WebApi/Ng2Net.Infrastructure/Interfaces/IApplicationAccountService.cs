using Microsoft.AspNet.Identity.EntityFramework;
using Ng2Net.Infrastructure.Interfaces;
using Ng2Net.Model.Security;
using System.Collections.Generic;
using System.Linq;

namespace Ng2Net.Infrastructure.Interfaces
{
    public interface IApplicationAccountService
    {
        Dictionary<string, string> GetClaimsDictionaryByUser(ApplicationUser user);
        ApplicationUser GetById(string id);
        IQueryable<ApplicationUser> GetUsers(string filterQuery);
        IEnumerable<ApplicationRole> GetUserRoles(string userId);
        IQueryable<ApplicationRole> GetIdentityRoles();
        void GrantUserRole(string userid, string roleid);
        void RemoveUserRole(string userid, string roleid);
        int Save();
        IApplicationUserService UserService { get; }
    }
}
