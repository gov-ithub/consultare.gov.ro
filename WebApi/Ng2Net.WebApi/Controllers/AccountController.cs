using AutoMapper;
using Ng2Net.WebApi.Base;
using Microsoft.AspNet.Identity;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using Ng2Net.WebApi.DTO;
using Ng2Net.Model.Security;
using Ng2Net.Services.Security;
using Ng2Net.Data;
using Ng2Net.Model.Scheduler;
using Ng2Net.Services.Scheduler;
using Ng2Net.Infrastructure.Services;
using Ng2Net.Infrastructure.Data;
using Ng2Net.Infrastructure.Interfaces;

namespace Ng2Net.WebApi.Controllers
{
    [RoutePrefix("api/account")]
    public class AccountController : BaseController
    {
        private IApplicationAccountService _accountService;
        private INotificationService _notificationSevice;
        //to be changed using di
        public AccountController(IApplicationAccountService accountService, INotificationService notificationService)
        {
            _accountService = accountService;
            _notificationSevice = notificationService;
        }

        [Route("register")]
        public async Task<IdentityResult> RegisterUser(UserLoginDTO userDTO)
        {
            ApplicationUser user = new ApplicationUser
            {
                UserName = userDTO.UserName,
            };

            var result = await UserManager.CreateAsync(user, userDTO.Password);
            UserManager.AddToRole(user.Id, "User");
            return result;
        }


        [Route("me")]
        public ClaimsIdentityDTO GetCurrentUser()
        {

            if (CurrentUser == null)
                return null;
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<ApplicationUser, ClaimsIdentityDTO>();
                cfg.CreateMap<RoleClaim, ClaimDTO>();
            });
            ClaimsIdentityDTO result = Mapper.Map<ClaimsIdentityDTO>(CurrentUser);
            result.Claims = _accountService.GetClaimsDictionaryByUser(CurrentUser);
            return result;
        }

        [HttpPost]
        [Route("send-reset-password")]
        public async Task<object> SendResetPassword([FromBody] ClaimsIdentityDTO userModel)
        {
            ApplicationUser user = await UserManager.FindByEmailAsync(userModel.Email);
            if (user == null)
                return new { error = true, message = "email_not_found" };
            Notification not = new Notification
            {
                Subject = "Reset your password",
                Body = "http://ng2net.start/reset-password/" + HttpContext.Current.Server.UrlEncode(user.Id) + "?token=" + HttpUtility.UrlEncode(this.UserManager.GeneratePasswordResetToken(user.Id)),
                From = "carol.braileanu@gmail.com",
                To = user.Email
            };
            this._notificationSevice.AddNotification(not);            
            return new { result = "success", message = "email_sent" };

        }

        [HttpPost]
        [Route("reset-password")]
        public async Task<object> ResetPassword([FromBody] ResetPasswordDTO resetModel)
        {
            IdentityResult result = await UserManager.ResetPasswordAsync(resetModel.UserId, resetModel.Token, resetModel.Password);
            if (result.Succeeded)
                return new { message = "password_reset" };
            else
                return new { error = true, message = "password_reset_failed" };

        }
    }
}