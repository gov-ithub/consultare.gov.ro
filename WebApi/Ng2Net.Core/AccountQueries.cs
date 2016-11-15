using Ng2Net.Database;
using Ng2Net.Database.DatabaseEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ng2Net.Core
{
    public class AccountQueries
    {
        public static Dictionary<string, string> GetClaimsDictionaryByUser(ApplicationUser user, DatabaseContext context)
        {
            string[] arrRoleId = user.Roles.Select(r => r.RoleId).ToArray();
            List<RoleClaim> lstRoleClaims = context.RoleClaims.Where(c => arrRoleId.Contains(c.RoleId)).ToList();
            Dictionary<string, string> result = user.Claims.ToDictionary(x => x.ClaimType, x => x.ClaimValue);
            lstRoleClaims.ForEach(c => { try { result.Add(c.ClaimType, c.ClaimValue); } catch { } });
            return result;

        }
    }
}
