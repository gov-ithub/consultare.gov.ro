using Ng2Net.Model.Security;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Ng2Net.Model.Business
{
    public class Institution : BaseEntity
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public string Url { get; set; }
        public virtual IList<Proposal> Proposals { get; set; }
        public virtual IList<ApplicationUser> SubscribedUsers { get; set; }
    }
}