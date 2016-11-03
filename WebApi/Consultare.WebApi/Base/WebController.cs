using Consultare.Database;
using Consultare.Database.IdentityHelpers;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace Consultare.WebApi.Base
{
	public class WebController : ApiController
    {
        protected DatabaseContext context;
        private ApplicationUserManager _userManager;
        public WebController()
        {
            this.context = new DatabaseContext();
        }

        protected ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? (_userManager = Request.GetOwinContext().GetUserManager<ApplicationUserManager>());
            }
        }
    }
}