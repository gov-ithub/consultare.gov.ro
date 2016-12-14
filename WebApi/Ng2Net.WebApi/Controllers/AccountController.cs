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
using Ng2Net.Model.Business;
using System;
using System.Data.Entity;
using System.Collections.Generic;
using Ng2Net.Services.Business;
using Microsoft.AspNet.Identity.Owin;
using Ng2Net.Services;
using Ng2Web.WebApi.CustomAttributes;

namespace Ng2Net.WebApi.Controllers
{
    [RoutePrefix("api/account")]
    public class AccountController : BaseController
    {
        private IApplicationAccountService _accountService;
        private INotificationService _notificationSevice;
        private IInstitutionService _institutionService;
        public AccountController(IApplicationAccountService accountService, INotificationService notificationService, IInstitutionService institutionService)
        {
            _accountService = accountService;
            _notificationSevice = notificationService;
            _institutionService = institutionService;
        }

        [Route("save")]
        public async Task<ClaimsIdentityDTO> SaveUser(ClaimsIdentityDTO claimsDTO)
        {
            var applicationUser = string.IsNullOrEmpty(claimsDTO.Id) ? new ApplicationUser() : _accountService.GetById(claimsDTO.Id);
            var mapper = new MapperConfiguration(cfg => {
                cfg.CreateMap<ClaimsIdentityDTO, ApplicationUser>().ForMember(dest => dest.Subscriptions, opt => opt.UseValue<IList<InstitutionDTO>>(null)).ForMember(dest => dest.Claims, opt => opt.Ignore());
            }).CreateMapper();
            mapper.Map(claimsDTO, applicationUser);
            applicationUser.UserName = claimsDTO.Email;
            bool sendConfirmationEmail = false;

            IdentityResult result = null;
            if (string.IsNullOrEmpty(applicationUser.Id))
            {
                applicationUser.Id = Guid.NewGuid().ToString();
                result = await ((ApplicationUserService)_accountService.UserService).CreateAsync(applicationUser, claimsDTO.Password);
                if (!result.Succeeded) throw new Exception(result.Errors.ToString());
                ((ApplicationUserService)_accountService.UserService).AddToRole(applicationUser.Id, "User");
                sendConfirmationEmail = true;
            }

            applicationUser.Subscriptions.Clear();
            if (claimsDTO.SubscriptionType == "SELECTED")
            {
                foreach (InstitutionDTO inst in claimsDTO.Subscriptions)
                {
                    Institution currentInstitution = _institutionService.GetById(inst.Id);
                    if (currentInstitution == null) continue;
                    if (!applicationUser.Subscriptions.Contains(currentInstitution)) applicationUser.Subscriptions.Add(currentInstitution);
                }
            }

            int x = _accountService.Save();
            var resultDTO = GetDTOFromUser(applicationUser);
            if (sendConfirmationEmail)
                await this.SendConfirmEmail(resultDTO);
            return resultDTO;
        }


        [Route("me")]
        public ClaimsIdentityDTO GetCurrentUser()
        {
            if (CurrentUser == null)
                return null;
            return GetDTOFromUser(this.CurrentUser);
        }

        public ClaimsIdentityDTO GetDTOFromUser(ApplicationUser user)
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<ApplicationUser, ClaimsIdentityDTO>();
                cfg.CreateMap<RoleClaim, ClaimDTO>();
                cfg.CreateMap<Institution, InstitutionDTO>();
            });
            ClaimsIdentityDTO result = Mapper.Map<ClaimsIdentityDTO>(user);
            result.Claims = _accountService.GetClaimsDictionaryByUser(user);
            return result;
        }

        [HttpPost]
        [Route("send-reset-password")]
        public async Task<object> SendResetPassword([FromBody] ClaimsIdentityDTO userModel)
        {
            ApplicationUser user = await UserManager.FindByEmailAsync(userModel.Email);
            if (user == null)
                return new { error = true, message = "email_not_found" };
            Dictionary<string, string> replacements = new Dictionary<string, string>();
            replacements.Add("LINK", "/reset-password/" + HttpContext.Current.Server.UrlEncode(user.Id) + "?token=" + HttpUtility.UrlEncode(this.UserManager.GeneratePasswordResetToken(user.Id)));
            replacements.Add("FULLNAME", user.FirstName + " " + user.LastName);
            Notification not = _notificationSevice.ConstructNotification("email.reset-password.subject", "email.masterTemplate", "email.reset-password.body", "email.defaultFrom", replacements);
            not.To = user.Email;
            this._notificationSevice.AddNotification(not);
            return new { result = "success", message = "email_sent" };

        }


        [HttpPost]
        [Route("send-confirm-email")]
        public async Task<object> SendConfirmEmail([FromBody] ClaimsIdentityDTO userModel)
        {
            ApplicationUser user = await UserManager.FindByEmailAsync(userModel.Email);
            if (user == null)
                return new { error = true, message = "email_not_found" };

            Dictionary<string, string> replacements = new Dictionary<string, string>();
            replacements.Add("LINK", "/confirm-account/" + HttpContext.Current.Server.UrlEncode(user.Id) + "?token=" + HttpUtility.UrlEncode(this.UserManager.GenerateEmailConfirmationToken(user.Id)));
            replacements.Add("FULLNAME", user.FirstName + " " + user.LastName);
            Notification not = _notificationSevice.ConstructNotification("email.confirm-account.subject", "email.masterTemplate", "email.confirm-account.body", "email.defaultFrom", replacements);

            not.To = user.Email;
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

        [HttpPost]
        [Route("confirm-account")]
        public async Task<object> ConfirmAccount([FromBody] ResetPasswordDTO resetModel)
        {
            IdentityResult result = await UserManager.ConfirmEmailAsync(resetModel.UserId, resetModel.Token);
            if (result.Succeeded)
                return new { message = "account_confirmed" };
            else
                return new { error = true, message = "account_confirm_failed" };

        }

        [Authentication(Claims = new string[] { })]
        [HttpPost]
        [Route("unsubscribe")]
        public async Task<object> Unsubscribe()
        {
            CurrentUser.SubscriptionType = "UNSUBSCRIBED";
            CurrentUser.Subscriptions.Clear();
            IdentityResult result = await UserManager.UpdateAsync(CurrentUser);

            if (result.Succeeded)
                return new { message = "unsubscribed" };
            else
                return new { error = true, message = result.Errors };

        }

    }
}