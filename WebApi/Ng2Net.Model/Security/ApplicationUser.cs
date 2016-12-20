using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Ng2Net.Model.Business;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Ng2Net.Model.Security
{
    public class ApplicationUser : IdentityUser
    {
        public ApplicationUser()
        {
            this.DateCreated = DateTime.Now;
            Id = Guid.NewGuid().ToString();
        }
        [StringLength(255)]
        public string FirstName { get; set; }
        [StringLength(255)]
        public string LastName { get; set; }

        public DateTime DateCreated { get; set; }

        public string UnsubscribeToken { get; set; }

        [StringLength(255)]
        public string SubscriptionType { get; set; }

        public virtual IList<Institution> Subscriptions { get; set; }


        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager, string authenticationType)
        {
            var userIdentity = await manager.CreateIdentityAsync(this, authenticationType);
            // Add custom user claims here
            return userIdentity;
        }
    }
}
