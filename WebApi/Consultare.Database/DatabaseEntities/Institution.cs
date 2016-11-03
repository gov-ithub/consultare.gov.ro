using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consultare.Database.DatabaseEntities
{
    public class Institution
    {
        public int Id { get; set; }
        [StringLength(255)]
        public string Name { get; set; }
        public string Type { get; set; }
    }
}
