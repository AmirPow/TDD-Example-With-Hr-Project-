using System;
using System.Collections.Generic;
using System.Text;
using HR.Framework.Core.ApplicationService;

namespace HR.EmployeeContext.ApplicationService.Contracts.Employees
{
    public class EmployeeUpdateContract :Command
    {
        public Guid EmployeeId { get;  set; }
        public Guid ContractId { get; set; }
        public DateTime StartDate { get;  set; }
        public DateTime EndDate { get;  set; }
    }
}
