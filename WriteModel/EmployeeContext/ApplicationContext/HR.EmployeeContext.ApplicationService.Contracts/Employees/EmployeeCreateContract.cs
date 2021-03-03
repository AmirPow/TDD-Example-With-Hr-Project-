using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HR.Framework.Core.ApplicationService;

namespace HR.EmployeeContext.ApplicationService.Contracts.Employees
{
    public class EmployeeCreateContract :Command
    {
        public Guid EmployeeId { get;  set; }
        public DateTime StartDate { get;  set; }
        public DateTime EndDate { get;  set; }
    }
}
