using System;
using System.ComponentModel.DataAnnotations;

namespace Ng2Net.Model
{
    public abstract class BaseEntity
    {
        [Key]
        public string Id { get; set; }

        public BaseEntity()
        {
            this.Id = Guid.NewGuid().ToString();
        }        
    }

}
