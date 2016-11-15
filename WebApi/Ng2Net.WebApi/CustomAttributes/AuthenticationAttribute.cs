using Ng2Net.Core;
using Ng2Net.WebApi.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace Ng2Web.WebApi.CustomAttributes
{
    public class AuthenticationAttribute : ActionFilterAttribute
    {
        public string[] Claims { get; set; }

        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            if (!CheckAuthentication(actionContext))
                throw new HttpResponseException(HttpStatusCode.Unauthorized);
            base.OnActionExecuting(actionContext);
        }

        public bool CheckAuthentication(HttpActionContext actionContext)
        {
            WebController controller = (WebController)actionContext.ControllerContext.Controller;
            if (controller.CurrentUser == null)
                return false;
            Dictionary<string, string> dClaims = AccountQueries.GetClaimsDictionaryByUser(controller.CurrentUser, controller.DbContext);
            bool result = true;
            this.Claims.ToList().ForEach(c =>
            {
                result = dClaims[c] == "true" && result;
            });
            return result;

        }

    }
}
