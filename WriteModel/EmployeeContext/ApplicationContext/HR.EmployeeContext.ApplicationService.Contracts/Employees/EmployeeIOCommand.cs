using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HR.Framework.Core.ApplicationService;

namespace HR.EmployeeContext.ApplicationService.Contracts.Employees
{
    public class EmployeeIOCommand :Command
    {
        public Guid EmployeeId { get; set; }
        public DateTime Date { get;  set; }
        public TimeSpan ArrivalTime { get; set; }
        public TimeSpan ExitTime { get; set; }
    }
}
