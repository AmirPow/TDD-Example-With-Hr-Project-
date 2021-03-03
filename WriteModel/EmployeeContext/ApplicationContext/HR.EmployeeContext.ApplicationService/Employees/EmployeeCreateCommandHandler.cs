

using HR.EmployeeContext.ApplicationService.Contracts.Employees;
using HR.EmployeeContext.Domain.Employees;
using HR.EmployeeContext.Domain.Employees.Services;
using HR.Framework.Core.ApplicationService;

namespace HR.EmployeeContext.ApplicationService.Employees
{
    public class EmployeeCreateCommandHandler :ICommandHandler<EmployeeCreateCommand>
    {
        private readonly INationalCodeDuplicationChecker nationalCodeDuplicationChecker;
        private readonly IShiftAcl shidAcl;
        private readonly IEmployeeRepository employeeRepository;

        public EmployeeCreateCommandHandler(INationalCodeDuplicationChecker nationalCodeDuplicationChecker,
            IShiftAcl shiftAcl,
            IEmployeeRepository employeeRepository)
        {
            this.nationalCodeDuplicationChecker = nationalCodeDuplicationChecker;
            this.shidAcl = shidAcl;
            this.employeeRepository = employeeRepository;
        }
        public void Execute(EmployeeCreateCommand command)
        {
            
            var employee = new Employee(nationalCodeDuplicationChecker,
                shidAcl,
                 command.Name,
                 command.NationalCode
               );
            employeeRepository.Create(employee);
        }
    }
}
