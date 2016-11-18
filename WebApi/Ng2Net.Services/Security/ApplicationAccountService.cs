using Microsoft.AspNet.Identity.EntityFramework;
using Ng2Net.Data;
using Ng2Net.Model.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ng2Net.Services.Security
{
    public class ApplicationAccountService
    {
        private IdentityDbContext<ApplicationUser> _context;

        public ApplicationAccountService(IdentityDbContext<ApplicationUser> context)
        {
            _context = context;
        }

        public Dictionary<string, string> GetClaimsDictionaryByUser(ApplicationUser user)
        {
            string[] arrRoleId = user.Roles.Select(r => r.RoleId).ToArray();
            List<RoleClaim> lstRoleClaims = _context.Set<RoleClaim>().Where(c => arrRoleId.Contains(c.RoleId)).ToList();
            Dictionary<string, string> result = user.Claims.ToDictionary(x => x.ClaimType, x => x.ClaimValue);
            lstRoleClaims.ForEach(c => { try { result.Add(c.ClaimType, c.ClaimValue); } catch { } });
            return result;
        }
    }
}
