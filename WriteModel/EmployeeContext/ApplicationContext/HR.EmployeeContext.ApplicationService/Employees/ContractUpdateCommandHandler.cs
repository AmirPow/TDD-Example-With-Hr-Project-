

using System.Linq;
using HR.EmployeeContext.ApplicationService.Contracts.Employees;
using HR.EmployeeContext.Domain.Employees;
using HR.EmployeeContext.Domain.Employees.Services;
using HR.Framework.Core.ApplicationService;

namespace HR.EmployeeContext.ApplicationService.Employees
{
    public class ContractUpdateCommandHandler :ICommandHandler<EmployeeUpdateContract>
    {
    

        private readonly IEmployeeRepository employeeRepository;

        public ContractUpdateCommandHandler(IEmployeeRepository employeeRepository)
        {
            this.employeeRepository = employeeRepository;
        }

        public void Execute(EmployeeUpdateContract command)
        {
            var employee = employeeRepository.GetEmployee(command.EmployeeId);
            var curent = employee.Contracts.Single(c => c.Id == command.ContractId);
            curent.SetDate(employeeRepository,command.StartDate,command.EndDate);
            employeeRepository.Update(employee);
        }
    }
}
