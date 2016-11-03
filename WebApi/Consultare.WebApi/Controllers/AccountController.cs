using AutoMapper;
using Consultare.Database;
using Consultare.WebApi.Base;
using Consultare.WebApi.Models;
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

namespace Consultare.WebApi.Controllers
{
    [RoutePrefix("api/account")]
    public class AccountController : WebController
    {
        [Route("register")]
        public async Task<IdentityResult> RegisterUser(UserModel userModel)
        {
            IdentityUser user = new IdentityUser {
                UserName = userModel.UserName,
            };
            user.Claims.Add(new IdentityUserClaim { ClaimType = ClaimTypes.Role, ClaimValue = "User" });

            var result = await this.userManager.CreateAsync(user, userModel.Password);
            return result;
        }



        [Authorize]
        [Route("me")]
        public ClaimsIdentityModel GetCurrentUser()
        {
            
            ClaimsIdentity cl = (ClaimsIdentity)User.Identity;
            Mapper.Initialize(cfg => {
                cfg.CreateMap<ClaimsIdentity, ClaimsIdentityModel>();
                cfg.CreateMap<Claim, ClaimModel>();
            });
            return Mapper.Map<ClaimsIdentityModel>(cl);
        }

    }
}