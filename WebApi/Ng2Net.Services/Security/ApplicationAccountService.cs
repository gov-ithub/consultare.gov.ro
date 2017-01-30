using Microsoft.AspNet.Identity.EntityFramework;
using Ng2Net.Data;
using Ng2Net.Infrastructure.Interfaces;
using Ng2Net.Model.Security;
using Ng2Net.Services.Business;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Data.Entity.Infrastructure;

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

        public IEnumerable<ApplicationRole> GetUserRoles(string userId)
        {
            var user = _context.Users.Include("Roles").FirstOrDefault(u => u.Id == userId);

            var roles = _context.ApplicationRoles.ToList().Where(r => user.Roles.Select(a => a.RoleId).ToArray().Contains(r.Id));

            return roles;
        }

        public IQueryable<ApplicationRole> GetIdentityRoles()
        {
            return _context.ApplicationRoles;
        }

        public IQueryable<ApplicationUser> GetUsers(string filterQuery)
        {
            if(string.IsNullOrEmpty(filterQuery))
                return _context.Users;

            return _context.Users.Where(u => u.UserName.Contains(filterQuery));
        }

        public void GrantUserRole(string userid, string roleid)
        {
            var user = _context.Users.Include("Roles").First(u => u.Id == userid);
            var role = _context.Roles.First(r => r.Id == roleid);

            if (user == null || role == null)
                return;

            if (user.Roles.Any(r => r.RoleId == role.Id))
                return;

            user.Roles.Add(new IdentityUserRole { UserId = user.Id, RoleId = role.Id });
            this.Save();

        }

        public void RemoveUserRole(string userid, string roleid)
        {
            var user = _context.Users.Include("Roles").First(u => u.Id == userid);

            if (user == null)
                return;

            var userRole = user.Roles.First(r => r.RoleId == roleid);
            if (userRole != null)
            {
                user.Roles.Remove(userRole);
                this.Save();
            }
        }

        public int Save()
        {
            var changedEntries = _context.ChangeTracker.Entries();
            changedEntries = changedEntries.Where(e => new EntityState[] { /*EntityState.Added*,*/ EntityState.Modified/*, EntityState.Deleted*/ }.Contains(e.State));
            changedEntries = changedEntries.Where(e => typeof(ApplicationUser).IsAssignableFrom(e.Entity.GetType())).ToList();

            foreach (var user in changedEntries)
            {
                RunRules(user);
            }

            return _context.SaveChanges();
        }

        private void RunRules(DbEntityEntry user)
        {
            ApplicationUser applicationUser = ((ApplicationUser)user.Entity);
            if (user.OriginalValues["Email"].ToString() != applicationUser.Email)
            {
                applicationUser.EmailConfirmed = false;
                applicationUser.UserName = applicationUser.Email;
            }

        }
    }
}
