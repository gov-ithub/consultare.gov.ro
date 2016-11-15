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
using Ng2Net.Core;
using Ng2Web.WebApi.CustomAttributes;

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

            var result = await UserManager.CreateAsync(user, userModel.Password);
            UserManager.AddToRole(user.Id, "User");
            return result;
        }


        [Route("me")]
        public ClaimsIdentityModel GetCurrentUser()
        {
            
            if (CurrentUser == null)
                return null;
            Mapper.Initialize(cfg => {
                cfg.CreateMap<ApplicationUser, ClaimsIdentityModel>();
                cfg.CreateMap<RoleClaim, ClaimModel>();
            });
            ClaimsIdentityModel result = Mapper.Map<ClaimsIdentityModel>(CurrentUser);
            result.Claims = AccountQueries.GetClaimsDictionaryByUser(CurrentUser, this.DbContext);
            return result;
        }

        [HttpPost]
        [Route("send-reset-password")]
        public async Task<object> SendResetPassword([FromBody] ClaimsIdentityModel userModel)
        {
            ApplicationUser user = await UserManager.FindByEmailAsync(userModel.Email);
            if (user == null)
                return new { error=true, message = "email_not_found" };
            Notification not = new Notification
            {
                Subject = "Reset your password",
                Body = "http://ng2net.start/reset-password/" + HttpContext.Current.Server.UrlEncode(user.Id) + "?token=" + HttpUtility.UrlEncode(this.UserManager.GeneratePasswordResetToken(user.Id)),
                From = "carol.braileanu@gmail.com",
                To = user.Email
            };
            this.DbContext.Notifications.Add(not);
            this.DbContext.SaveChanges();
            return new { result="success", message="email_sent" };
            
        }

        [HttpPost]
        [Route("reset-password")]
        public async Task<object> ResetPassword([FromBody] ResetPasswordModel resetModel)
        {
            IdentityResult result = await UserManager.ResetPasswordAsync(resetModel.UserId, resetModel.Token, resetModel.Password);
            if (result.Succeeded)
                return new { message = "password_reset" };
            else
                return new { error = true, message = "password_reset_failed" };

        }
    }
}