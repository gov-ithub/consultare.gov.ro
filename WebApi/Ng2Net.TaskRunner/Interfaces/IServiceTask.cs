using Ng2Net.Core;
using Ng2Net.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ng2Net.TaskRunner.Interfaces
{
    public interface IServiceTask
    {
        void Run(DatabaseContext context, Logging logger, string settings);
    }
}
