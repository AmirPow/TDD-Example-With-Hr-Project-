using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HR.EmployeeContext.ApplicationService.Contracts.Employees;
using HR.EmployeeContext.Domain.Employees.Services;
using HR.Framework.Core.ApplicationService;

namespace HR.EmployeeContext.ApplicationService.Employees
{
    public class ContractRemoveCommandHandler : ICommandHandler<EmployeeRemoveContract>
    {
        private readonly IEmployeeRepository employeeRepository;
        public ContractRemoveCommandHandler(IEmployeeRepository employeeRepository)
        {
            this.employeeRepository = employeeRepository;
        }
        public void Execute(EmployeeRemoveContract command)
        {
            var employee = employeeRepository.GetEmployee(command.EmployeeId);
            var current = employee.Contracts.Single(e=> e.Id == command.ContractId);
            employee.RemoveContract(current);
        }
    }
}
