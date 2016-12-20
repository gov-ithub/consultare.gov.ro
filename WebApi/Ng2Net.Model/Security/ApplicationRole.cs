using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ng2Net.Model.Security
{
    public class ApplicationRole : IdentityRole
    {
        public ApplicationRole() : base() {
            this.Claims = new List<RoleClaim>();
        }

        public ApplicationRole(string name) : base(name) {
            this.Claims = new List<RoleClaim>();
        }
        public virtual List<RoleClaim> Claims { get; set; }
    }
}
