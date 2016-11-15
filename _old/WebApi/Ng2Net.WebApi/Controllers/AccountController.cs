using AutoMapper;
using Ng2Net.Database;
using Ng2Net.Database.DatabaseEntities;
using Ng2Net.WebApi.Base;
using Ng2Net.WebApi.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.Owin;

namespace Ng2Net.WebApi.Controllers
{
    [RoutePrefix("api/account")]
    public class AccountController : WebController
    {
        [Route("register")]
        public async Task<IdentityResult> RegisterUser(UserModel userModel)
        {
            ApplicationUser user = new ApplicationUser {
                UserName = userModel.UserName,
            };

            var result = await this.UserManager.CreateAsync(user, userModel.Password);
            UserManager.AddToRole(user.Id, "User");
            return result;
        }


        [Route("me")]
        public ClaimsIdentityModel GetCurrentUser()
        {
            
            ClaimsIdentity cl = (ClaimsIdentity)User.Identity;
            ApplicationUser user = this.UserManager.FindById(cl.GetUserId());
            if (user == null)
                return null;
            Mapper.Initialize(cfg => {
                cfg.CreateMap<ApplicationUser, ClaimsIdentityModel>();
                cfg.CreateMap<RoleClaim, ClaimModel>();
            });
            ClaimsIdentityModel result = Mapper.Map<ClaimsIdentityModel>(user);
            string[] arrRoleId = user.Roles.Select(r => r.RoleId).ToArray();
            List<RoleClaim> lstRoleClaims = DbContext.RoleClaims.Where(c => arrRoleId.Contains(c.RoleId)).ToList();
            result.Claims = user.Claims.ToDictionary(x=>x.ClaimType, x=>x.ClaimValue);
            lstRoleClaims.ForEach(c=> { try { result.Claims.Add(c.ClaimType, c.ClaimValue); } catch { } });
            return result;
        }

    }
}