using Consultare.Database;
using Consultare.WebApi.Base;
using Consultare.WebApi.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace Consultare.WebApi.Controllers
{
    [RoutePrefix("api/account")]
    public class AccountController : WebController
    {
        [Authorize]
        [Route("register")]
        public async Task<IdentityResult> RegisterUser(UserModel userModel)
        {
            IdentityUser user = new IdentityUser {
                UserName = userModel.UserName,
            };

            var result = await this.userManager.CreateAsync(user, userModel.Password);
            return result;
        }
    }
}