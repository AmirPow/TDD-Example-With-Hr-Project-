using System;
using System.Collections.Generic;
using System.Text;
using HR.Framework.Core.ApplicationService;

namespace HR.EmployeeContext.ApplicationService.Contracts.Employees
{
    public class EmployeeDeleteCommand :Command
    {
        public Guid EmployeeId { get; set; }

    }
}
