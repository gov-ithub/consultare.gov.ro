using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;

namespace Consultare.WebApi.Models
{
    public class ClaimsIdentityModel
    {
        public string Name { get; set; }
        public IEnumerable<ClaimModel> Claims { get; set; }

    }
}