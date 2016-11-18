using Ng2Net.Infrastrucure.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ng2Net.TaskRunner.Interfaces
{
    public interface IServiceTask
    {
        void Run(string settings);
    }
}
