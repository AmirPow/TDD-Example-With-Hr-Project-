

using HR.EmployeeContext.ApplicationService.Contracts.Employees;
using HR.EmployeeContext.Domain.Employees;
using HR.EmployeeContext.Domain.Employees.Services;
using HR.Framework.Core.ApplicationService;

namespace HR.EmployeeContext.ApplicationService.Employees
{
    public class EmployeeDeleteCommandHandler :ICommandHandler<EmployeeDeleteCommand>
    {
        
       
        private readonly IEmployeeRepository employeeRepository;

        public EmployeeDeleteCommandHandler(IEmployeeRepository employeeRepository)
        {
            this.employeeRepository = employeeRepository;
        }

        
        public void Execute(EmployeeDeleteCommand command)
        {
            var emp = employeeRepository.GetEmployee(command.EmployeeId);
            employeeRepository.Remove(emp);
        }
    }
}
