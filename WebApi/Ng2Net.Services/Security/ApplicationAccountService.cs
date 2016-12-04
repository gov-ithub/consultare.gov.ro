using Microsoft.AspNet.Identity.EntityFramework;
using Ng2Net.Data;
using Ng2Net.Infrastructure.Interfaces;
using Ng2Net.Model.Security;
using Ng2Net.Services.Business;
using System.Collections.Generic;
using System.Linq;

namespace Ng2Net.Services.Security
{
    public class ApplicationAccountService : IApplicationAccountService
    {
        private DatabaseContext _context;
        private IApplicationUserService _applicationUserService;

        public ApplicationAccountService(DatabaseContext context)
        {
            _context = context;
            _applicationUserService = new ApplicationUserService(new UserStore<ApplicationUser>(_context));
        }

        public Dictionary<string, string> GetClaimsDictionaryByUser(ApplicationUser user)
        {
            string[] arrRoleId = user.Roles.Select(r => r.RoleId).ToArray();
            List<RoleClaim> lstRoleClaims = _context.Set<RoleClaim>().Where(c => arrRoleId.Contains(c.RoleId)).ToList();
            Dictionary<string, string> result = user.Claims.ToDictionary(x => x.ClaimType, x => x.ClaimValue);
            lstRoleClaims.ForEach(c => { try { result.Add(c.ClaimType, c.ClaimValue); } catch { } });
            return result;
        }

        public IApplicationUserService UserService
        {
            get { return _applicationUserService; }
        }

        public ApplicationUser GetById(string id)
        {
            return _context.Users.FirstOrDefault(u=>u.Id == id);
        }

        public int Save()
        {
            return _context.SaveChanges();
        }
    }
}
