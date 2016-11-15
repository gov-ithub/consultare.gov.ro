using Ng2Net.Database;
using Ng2Net.Database.DatabaseEntities;
using Ng2Net.Database.IdentityHelpers;
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

namespace Ng2Net.WebApi.Base
{
	public class WebController : ApiController
    {
        private DatabaseContext context;
        private ApplicationUserManager _userManager;
        private static DpapiDataProtectionProvider _tokenProvider;
        private ApplicationUser _currentUser;

        public DatabaseContext DbContext {
            get
            {
                return context ?? (context = new DatabaseContext());
            }
        }

        protected ApplicationUserManager UserManager
        {
            get
            {
                if (_userManager == null)
                {
                    if (_tokenProvider == null)
                        _tokenProvider = new DpapiDataProtectionProvider();
                    _userManager = Request.GetOwinContext().GetUserManager<ApplicationUserManager>();
                    _userManager.UserTokenProvider = new DataProtectorTokenProvider<ApplicationUser>(_tokenProvider.Create("ResetPassword")) { TokenLifespan = TimeSpan.FromDays(1) };
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