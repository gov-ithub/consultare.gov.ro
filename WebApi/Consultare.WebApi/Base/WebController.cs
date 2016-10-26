using Consultare.Database;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace Consultare.WebApi.Base
{
	public class WebController : ApiController
    {
        protected DatabaseContext context;
        protected UserManager<IdentityUser> userManager;
        public WebController()
        {
            this.context = new DatabaseContext();
            this.userManager = new UserManager<IdentityUser>(new UserStore<IdentityUser>(context));
        }
    }
}