﻿using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Ng2Net.Data;
using Ng2Net.Model.Security;
using System.Data.Entity;

namespace Ng2Net.Services
{
    public class ApplicationUserService : UserManager<ApplicationUser>
    {
        public ApplicationUserService(IUserStore<ApplicationUser> store): base(store)
        {
        }

        public static ApplicationUserService Create(IdentityFactoryOptions<ApplicationUserService> options, IOwinContext context)
        {
            var appDbContext = context.Get<DbContext>();
            var _service = new ApplicationUserService(new UserStore<ApplicationUser>(appDbContext));
            return _service;
        }

        
    }
}
