using Ng2Net.Infrastructure.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ng2Net.Model.Business
{
    public class Institution : BaseEntity
    {        
        public string Name { get; set; }
        public string Type { get; set; }

    }
}