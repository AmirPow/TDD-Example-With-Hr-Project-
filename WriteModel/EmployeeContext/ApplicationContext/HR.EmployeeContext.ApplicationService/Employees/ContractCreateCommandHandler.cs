using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using HR.EmployeeContext.ApplicationService.Contracts.Employees;
using HR.EmployeeContext.Domain.Employees;
using HR.EmployeeContext.Domain.Employees.Services;
using HR.Framework.Core.ApplicationService;

namespace HR.EmployeeContext.ApplicationService.Employees
{
    class ContractCreateCommandHandler : ICommandHandler<EmployeeCreateContract>
    {
        private readonly IEmployeeRepository employeeRepository;

        public ContractCreateCommandHandler(IEmployeeRepository employeeRepository)
        {
            this.employeeRepository = employeeRepository;
        }
        public void Execute(EmployeeCreateContract command)
        {
            var employee = employeeRepository.GetEmployee(command.EmployeeId);
            var contract = new Contract( employeeRepository, command.EmployeeId, command.StartDate, command.EndDate);
            employee.AddContract(contract);
        }
    }
}
