using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;

namespace Ng2Net.WebApi.Models
{
    public class ResetPasswordModel
    {
        public string UserId { get; set; }
        public string Token { get; set; }
        public string Password { get; set; }

    }
}