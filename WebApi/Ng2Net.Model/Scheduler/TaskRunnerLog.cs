﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Ng2Net.Model.Scheduler
{
    public class TaskRunnerLog : BaseEntity
    {
        public DateTime? DateStarted { get; set; }
        public DateTime? DateEnded { get; set; }

        [StringLength(255)]
        public string JobResult { get; set;}
    }
}
