using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using HR.EmployeeContext.ApplicationService.Contracts.Employees;
using HR.EmployeeContext.Domain.Employees;
using HR.EmployeeContext.Domain.Employees.Services;
using HR.Framework.Core.ApplicationService;

namespace HR.EmployeeContext.ApplicationService.Employees
{
    public class EmployeeAssignShiftCommandHandler : ICommandHandler<EmployeeAssignShiftCommand>
    {
        private readonly IShiftAcl shiftAcl;
        private readonly IEmployeeRepository employeeRepository;
        

        public EmployeeAssignShiftCommandHandler(IShiftAcl shiftAcl, IEmployeeRepository employeeRepository)
        {
            this.shiftAcl = shiftAcl;
            this.employeeRepository = employeeRepository;
        }
        public void Execute(EmployeeAssignShiftCommand command)
        {
            var employee = employeeRepository.GetEmployee(command.EmployeeId);
            var assign = new AssignShift(shiftAcl , command.EmployeeId,command.ShiftId, command.Index , command.StartDate);
            employee.AddAssignShift(assign);
        }
    }
 
}
