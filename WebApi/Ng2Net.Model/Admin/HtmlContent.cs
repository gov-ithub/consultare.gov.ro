using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Ng2Net.Model.Admin
{
    public class HtmlContent : BaseEntity
    {
        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        public string Content { get; set; }

        [StringLength(255)]
        public string Url { get; set; }

        public HtmlContent()
        {
            this.Id = Guid.NewGuid().ToString();
        }
    }
}