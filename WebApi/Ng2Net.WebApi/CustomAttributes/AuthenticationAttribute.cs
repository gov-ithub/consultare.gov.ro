using Ng2Net.Data;
using Ng2Net.Services.Security;
using Ng2Net.WebApi.Base;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace Ng2Web.WebApi.CustomAttributes
{
    public class AuthenticationAttribute : ActionFilterAttribute
    {
        public string[] Claims { get; set; }
        private ApplicationAccountService _accountService;

        public AuthenticationAttribute()
        {
            _accountService = new ApplicationAccountService(new DatabaseContext());
        }

        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            if (!CheckAuthentication(actionContext))
                throw new HttpResponseException(HttpStatusCode.Unauthorized);
            base.OnActionExecuting(actionContext);
        }

        public bool CheckAuthentication(HttpActionContext actionContext)
        {
            BaseController controller = (BaseController)actionContext.ControllerContext.Controller;
            if (controller.CurrentUser == null)
                return false;
            Dictionary<string, string> dClaims = _accountService.GetClaimsDictionaryByUser(controller.CurrentUser);
            bool result = true;
            this.Claims.ToList().ForEach(c =>
            {
                result = dClaims[c] == "true" && result;
            });
            return result;

        }

    }
}
