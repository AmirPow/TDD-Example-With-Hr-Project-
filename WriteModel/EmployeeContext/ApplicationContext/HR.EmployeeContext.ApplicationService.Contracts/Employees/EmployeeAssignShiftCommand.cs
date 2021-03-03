using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HR.Framework.Core.ApplicationService;

namespace HR.EmployeeContext.ApplicationService.Contracts.Employees
{
    public class EmployeeAssignShiftCommand : Command
    {
        public int Index { get;  set; }
        public Guid EmployeeId { get;  set; }
        public Guid ShiftId { get;  set; }
        public DateTime StartDate { get;  set; }
    }
}
