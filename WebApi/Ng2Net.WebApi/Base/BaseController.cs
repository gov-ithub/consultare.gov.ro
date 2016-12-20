using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using Microsoft.Owin.Security.DataProtection;
using System.Security.Claims;
using Ng2Net.Services;
using Ng2Net.Model.Security;

namespace Ng2Net.WebApi.Base
{
	public class BaseController : ApiController
    {        
        private ApplicationUserService _userManager;
        private static IDataProtector _dataProtector;
        private ApplicationUser _currentUser;
        
        protected ApplicationUserService UserManager
        {
            get
            {

                if (_userManager == null)
                {
                    if (_dataProtector == null)
                    {
                        var _tokenProvider = new DpapiDataProtectionProvider();
                        _dataProtector = _tokenProvider.Create("ConfirmEmail", "ResetPassword");
                    }

                    _userManager = Request.GetOwinContext().GetUserManager<ApplicationUserService>();
                    _userManager.UserTokenProvider = new DataProtectorTokenProvider<ApplicationUser>(_dataProtector) { TokenLifespan = TimeSpan.FromDays(1) };
                }
                return _userManager;
            }
        }

        public ApplicationUser CurrentUser {
            get {
                if (_currentUser == null)
                {
                    ClaimsIdentity cl = (ClaimsIdentity)User.Identity;
                    this._currentUser = UserManager.FindById(cl.GetUserId());
                }

                return _currentUser;
            }
        }
    }
}