using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HR.EmployeeContext.ApplicationService.Contracts.Employees;
using HR.EmployeeContext.Domain.Employees;
using HR.EmployeeContext.Domain.Employees.Services;
using HR.Framework.Core.ApplicationService;
using Microsoft.VisualBasic;

namespace HR.EmployeeContext.ApplicationService.Employees
{
    public class EmployeeIOCommandHandler : ICommandHandler<EmployeeIOCommand>
    {
        private readonly IEmployeeRepository employeeRepository;
        private readonly IShiftAcl shiftAcl;

        public EmployeeIOCommandHandler(IEmployeeRepository employeeRepository , IShiftAcl shiftAcl)
        {
            this.employeeRepository = employeeRepository;
            this.shiftAcl = shiftAcl;
        }
        public void Execute(EmployeeIOCommand command)
        {
            var employee = employeeRepository.GetEmployee(command.EmployeeId);
            var assignShift = employee.AssignShifts.Single(c => c.EmployeeId == command.EmployeeId);
            var shiftSegmentInfo = shiftAcl.GetShiftSegmentDto(assignShift.ShiftId);
            var IO = new IO(employeeRepository,command.EmployeeId, command.Date, command.ArrivalTime, command.ExitTime);
            employee.AddIO(IO);
        }
    }
}
