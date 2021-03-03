using System;
using System.Collections.Generic;
using System.Text;
using HR.Framework.Core.ApplicationService;

namespace HR.EmployeeContext.ApplicationService.Contracts.Employees
{
    public class EmployeeUpdateCommand :Command
    {
        public Guid EmployeeId { get; set; }
        public string NationalCode { get;  set; }
        public string Name { get;  set; }
  
    }
}
