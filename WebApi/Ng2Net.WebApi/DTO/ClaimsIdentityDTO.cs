using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ng2Net.WebApi.DTO
{
    public class ClaimsIdentityDTO

    {

        public string Id { get; set; }

        public string UserName { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public Dictionary<string, string> Claims { get; set; }

    }
}